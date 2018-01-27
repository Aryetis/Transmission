using UnityEngine;

[ExecuteInEditMode]
public class SimpleParent : MonoBehaviour {

	public Transform anchor;
	public Vector3 offset;

	private void LateUpdate()
	{
		FollowAnchor();
	}

	private void FollowAnchor ()
	{
		if (!anchor)
			return;

		transform.position = anchor.position + offset;
	}
}
