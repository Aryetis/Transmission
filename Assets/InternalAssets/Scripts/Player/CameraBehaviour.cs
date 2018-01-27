using UnityEngine;

[ExecuteInEditMode]
public class CameraBehaviour : MonoBehaviour {

	private static CameraBehaviour _instance;
	public static CameraBehaviour Instance
	{
		get { return _instance; }
	}

	public Camera mainCamera;

	public Transform character;
	public float followLerprate = 8f;

	public Transform yRotationGroup;
	//public float yRotation;
	public float yTargetRotation;
	public float ySensivity = 1f;
	public bool inverseYRotation = false;
	public Transform xRotationGroup;
	//public float xRotation;
	public float xTargetRotation;
	public float xSensivity = 1f;
	public bool inverseXRotation = true;
	public float rotationLerprate = 8f;

	public Vector2 rightStickAxis;

	// Private
	private float deltaTime;

	private void Awake()
	{
		// Singleton instance
		if (_instance != null)
		{
			Debug.LogError("Two CameraBehaviour detected. Removing one of them.");
			Destroy(this);
		}
		else
		{
			_instance = this;
		}

		FollowCharacter(true);
		RotateCamera(true);
	}

	private void Update()
	{
		GetInputs();
	}

	private void LateUpdate()
	{
		LateCacheData();

		FollowCharacter();
		RotateCamera();
	}

	private void GetInputs()
	{
		rightStickAxis = new Vector2(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY"));
		float yDelta = rightStickAxis.x * ySensivity * deltaTime;
		yTargetRotation += inverseYRotation ? yDelta : -yDelta;
		float xDelta = rightStickAxis.y * xSensivity * deltaTime;
		xTargetRotation += inverseYRotation ? xDelta : -xDelta;
		xTargetRotation = Mathf.Clamp(xTargetRotation, 30f, 40f);
	}

	private void LateCacheData ()
	{
		deltaTime = Time.deltaTime;
	}

	private void FollowCharacter (bool instantFollow = false)
	{
		if (!character)
			return;

		transform.position = Vector3.Lerp(transform.position, character.position, instantFollow ? 1f : deltaTime * followLerprate);
	}

	private void RotateCamera(bool instantRotation = false)
	{
		yRotationGroup.localRotation = Quaternion.Slerp(yRotationGroup.localRotation, Quaternion.Euler(0f, yTargetRotation, 0f), instantRotation ? 1f : deltaTime * rotationLerprate);
		xRotationGroup.localRotation = Quaternion.Slerp(xRotationGroup.localRotation, Quaternion.Euler(xTargetRotation, 0f, 0f), instantRotation ? 1f : deltaTime * rotationLerprate);
	}
}
