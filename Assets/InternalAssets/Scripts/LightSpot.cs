﻿using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
[RequireComponent(typeof(SphereCollider))]
public class LightSpot : MonoBehaviour {

	public float spotRadius = 10f;

	private SphereCollider _lightCollider;
	private SphereCollider lightCollider
	{
		get
		{
			if (!_lightCollider)
				_lightCollider = GetComponent<SphereCollider>();

			return _lightCollider;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		CharacterBehaviour.Instance.AddOffroadAnchor(this);	
	}

	private void OnTriggerExit(Collider other)
	{
		CharacterBehaviour.Instance.RemoveOffroadAnchor(this);
	}

#if UNITY_EDITOR
	// More accurate than OnDrawGizmos
	private void Update()
	{
		if (spotRadius < 0f)
			spotRadius = 0f;

		lightCollider.isTrigger = true;
		lightCollider.radius = spotRadius;
		lightCollider.center = new Vector3(0, 0, transform.position.y);

		transform.gameObject.layer = 9;

		transform.eulerAngles = new Vector3(90, 0, 0);
	}

	private void OnDrawGizmos()
	{
		Handles.color = new Color(1, 0, 0, 0.5f);

		Vector3 groundPos = transform.position;
		groundPos.y = 0f;
		Handles.DrawWireDisc(groundPos, Vector3.up, spotRadius);

		Handles.color = new Color(1, 0, 0, 0.05f);

		Handles.DrawSolidDisc(groundPos, Vector3.up, spotRadius);
	}
#endif
}
