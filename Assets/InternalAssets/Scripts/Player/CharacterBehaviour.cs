using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class CharacterBehaviour : MonoBehaviour {

	private static CharacterBehaviour _instance;
	public static CharacterBehaviour Instance
	{
		get { return _instance; }
	}

	public Vector2 leftStickAxis;
	public float characterSpeed = 8f;
	public float characterSpeedLerpRate = 8f;
	public Vector3 motionVector;

	public CameraBehaviour cameraBehaviour;

	public List<LightSpot> offroadAnchors = new List<LightSpot>();
	public float offroadThresold = 2f;
	[Range(0f, 1f)]
	public float offroadLerp = 0f;
	[Range(-1f, 1f)]
	public float offroadDot = 0f;
	public AnimationCurve offroadDotCurve = AnimationCurve.Linear(0, 0, 1, 1);

	// Cache
	private float fixedDeltaTime;
	[HideInInspector] public Transform characterTransform;
	private Rigidbody _characterRigidbody;
	private Rigidbody characterRigidbody
	{
		get
		{
			if (!_characterRigidbody)
				_characterRigidbody = GetComponent<Rigidbody>();

			return _characterRigidbody;
		}
	}
	private CapsuleCollider _characterCollider;
	private CapsuleCollider characterCollider
	{
		get
		{
			if (!_characterCollider)
				_characterCollider = GetComponent<CapsuleCollider>();

			return _characterCollider;
		}
	}

	private void Awake()
	{
		if (_instance != null)
		{
			Debug.LogError("Two CharacterBehaviour detected. Removing one of them.");
			Destroy(this);
		}
		else
		{
			_instance = this;
		}

		EarlyCacheData();

	}

	private void Start()
	{
		cameraBehaviour = CameraBehaviour.Instance;
	}

	private void Update()
	{
		GetInputs();
	}

	private void FixedUpdate()
	{
		FixedCacheData();

		Motion();

		OffroadStatus();
	}

	private void EarlyCacheData()
	{
		characterTransform = transform;
	}

	private void FixedCacheData ()
	{
		fixedDeltaTime = Time.fixedDeltaTime;
	}

	private void GetInputs()
	{
		leftStickAxis = new Vector2(Input.GetAxis("LeftStickX"), -Input.GetAxis("LeftStickY"));
		if (leftStickAxis.magnitude > 1f)
			leftStickAxis = leftStickAxis.normalized;
	}

	private void Motion()
	{
		motionVector = Vector3.Lerp(
			motionVector,
			cameraBehaviour.yRotationGroup.rotation * new Vector3(leftStickAxis.x, 0f, leftStickAxis.y) * characterSpeed,
			fixedDeltaTime * characterSpeedLerpRate);

		SetRigidbodyVelocity(motionVector * offroadDot);
	}

	private void SetRigidbodyVelocity(Vector3 vel)
	{
		characterRigidbody.velocity = vel;
	}

	private void OffroadStatus ()
	{
		if (offroadAnchors.Count == 0)
		{
			offroadLerp = 0f;
			offroadDot = 1f;
		}
		else
		{
			List<float> offroadLerps = new List<float>();
			int closestSpot = 0;

			for (int i = 0; i < offroadAnchors.Count; i++)
			{
				LightSpot spot = offroadAnchors[i];

				offroadLerps.Add(Mathf.InverseLerp(spot.spotRadius - offroadThresold, spot.spotRadius,
					Vector3.Distance(characterTransform.position, spot.transform.position) - characterCollider.radius));

				if (i == 0)
					closestSpot = 0;
				else if (offroadLerps[i] < offroadLerps[closestSpot])
					closestSpot = i;
			}

			offroadLerp = offroadLerps[closestSpot];
			float offroadDotValue = offroadDotCurve.Evaluate(Vector3.Dot(motionVector.normalized, (offroadAnchors[closestSpot].transform.position - transform.position).normalized));

			offroadDot = Mathf.InverseLerp(1f, offroadDotValue, offroadLerp);
		}

		CameraBehaviour.Instance.SetOffroadFX(offroadLerp);

	}

	public void AddOffroadAnchor (LightSpot spot)
	{
		offroadAnchors.Add(spot);
	}

	public void RemoveOffroadAnchor (LightSpot spot)
	{
		if (offroadAnchors.Count == 1)
			return;

		offroadAnchors.Remove(spot);
	}
}
