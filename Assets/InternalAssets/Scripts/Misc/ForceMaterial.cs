using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ForceMaterial : MonoBehaviour {

	public Renderer rend;
	public Material mat;

	private void LateUpdate()
	{
		SetMaterial();
	}

	private void SetMaterial ()
	{
		if (!rend || !mat)
			return;

		rend.material = mat;
	}
}
