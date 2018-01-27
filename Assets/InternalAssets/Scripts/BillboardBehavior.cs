using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardBehavior : MonoBehaviour
{

	// Use this for initialization
	//void Start ()
 //   {
		
	//}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(transform.position + Camera.current.transform.rotation * Vector3.forward,
            Camera.current.transform.rotation * Vector3.up);
    }
}
