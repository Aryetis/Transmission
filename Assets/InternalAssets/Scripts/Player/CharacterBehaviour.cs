using UnityEngine;

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
		SetRigidbodyVelocity(motionVector);
	}

	private void SetRigidbodyVelocity(Vector3 vel)
	{
		characterRigidbody.velocity = vel;
	}
}
