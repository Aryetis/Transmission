using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class CharacterBehaviour : MonoBehaviour {

	private static CharacterBehaviour _instance;
	public static CharacterBehaviour Instance
	{
		get { return _instance; }
	}

	// Cache
	private CameraBehaviour cameraBehaviour;
	[HideInInspector] public Transform characterTransform;
	private Rigidbody _characterRigidbody;
	private Rigidbody characterRigidbody
	{
		get
		{
			if (_characterRigidbody)
				GetComponent<Rigidbody>();

			return _characterRigidbody;
		}
	}
	private CapsuleCollider _characterCollider;
	private CapsuleCollider characterCollider
	{
		get
		{
			if (_characterCollider)
				GetComponent<CapsuleCollider>();

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

	private void EarlyCacheData ()
	{

	}

	private void Start()
	{
		cameraBehaviour = CameraBehaviour.Instance;
	}
}
