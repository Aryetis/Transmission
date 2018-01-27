using UnityEngine;

[ExecuteInEditMode]
public class BillboardBehavior : MonoBehaviour
{
	public Transform lookAtTransform;
	public bool verticalBillboard = false;

private void Start()
{
lookAtTransform = Camera.main.transform;
}

    void LateUpdate ()
    {
        //transform.LookAt(lookAtTransform);
        if (!verticalBillboard)
        {
            transform.rotation = lookAtTransform.rotation;
        }
        else
        {
            if (!CameraBehaviour.Instance)
                return;

            Vector3 targetPos = lookAtTransform.position - CameraBehaviour.Instance.yRotationGroup.forward * 10;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
        }
	}
}
