using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CameraBehaviour : MonoBehaviour {

	private static CameraBehaviour _instance;
	public static CameraBehaviour Instance
	{
		get { return _instance; }
	}

	[Header("MAIN BEHAVIOUR")]
	[Space(10)]
	public Transform character;
	public Camera mainCamera;
	[Space(6)]
	public float followLerprate = 8f;
	[Space(6)]
	public Vector2 rightStickAxis;
	[Space(6)]
	public Transform yRotationGroup;
	public float yTargetRotation;
	public float ySensivity = 1f;
	public bool inverseYRotation = false;
	[Space(6)]
	public Transform xRotationGroup;
	public float xTargetRotation;
	public float xSensivity = 1f;
	[Space(6)]
	public int minXRotation = 0;
	public int maxXRotation = 90;
	[Space(6)]
	public bool inverseXRotation = true;
	[Space(6)]
	public float rotationLerprate = 8f;

	[Header("EFFECTS")]
	[Space(10)]
	public BloomOptimized bloom;
	public VignetteAndChromaticAberration vignette;
	public Fisheye fisheye;
	public Image redOverlay;
	[Space(6)]
	[Range(0f, 1f)]
	public float offroadLerp = 0f;

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

		SetOffroadFX();
		ShakeCam();
	}

	private void GetInputs()
	{
		rightStickAxis = new Vector2(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY"));
		float yDelta = rightStickAxis.x * ySensivity * deltaTime;
		yTargetRotation += inverseYRotation ? yDelta : -yDelta;
		//yTargetRotation = Mathf.Clamp(yTargetRotation, -20, 20);
		float xDelta = rightStickAxis.y * xSensivity * deltaTime;
		xTargetRotation += inverseYRotation ? xDelta : -xDelta;
		xTargetRotation = Mathf.Clamp(xTargetRotation, minXRotation, maxXRotation);
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

	public void SetOffroadFX (float lerp = -1)
	{
		if (lerp >= 0f)
			offroadLerp = lerp;

		vignette.intensity = Mathf.Lerp(0.2f, 0.6f, offroadLerp);
		vignette.chromaticAberration = offroadLerp * 20f;

		fisheye.strengthX = fisheye.strengthY = offroadLerp / 4f;

		Color overlayColor = redOverlay.color;
		overlayColor = new Color(overlayColor.r, overlayColor.g, overlayColor.b, offroadLerp / 6f);
		redOverlay.color = overlayColor;
	}

	private void ShakeCam()
	{
		mainCamera.transform.localEulerAngles = Random.insideUnitSphere * offroadLerp / 4f;
	}

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		if (EditorApplication.isPlaying)
			return;

		FollowCharacter(true);
		RotateCamera(true);

		SetOffroadFX(offroadLerp);
	}
#endif
}
