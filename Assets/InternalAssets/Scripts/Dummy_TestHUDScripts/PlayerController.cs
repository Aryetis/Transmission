using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BeingBehavior
{
	private float speed = 10.0f;

	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3(transform.position.x - Input.GetAxis("Vertical")*speed*Time.deltaTime, 
		                        transform.position.y, 
		                        transform.position.z + Input.GetAxis("Horizontal")*speed*Time.deltaTime);
	}
}
