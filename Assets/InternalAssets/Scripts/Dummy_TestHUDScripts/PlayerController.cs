/**
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *  moved to CharacterBehavior
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */


























//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// WARNING WILL HAVE UNEXPECTED BEHAVIOR WHEN MULTIPLE INTERACTIBLE OBJECTS ARE CLOSE TO EACH OTHERS

//public class PlayerController : MonoBehaviour
//{
//	private float speed = 10.0f;
//    public BeingBehavior interactibleGo;

//    //private void Start()
//    //{
//    //}

//    // Update is called once per frame
//    void Update ()
//	{
//		transform.position = new Vector3(transform.position.x - Input.GetAxis("Vertical")*speed*Time.deltaTime, 
//		                        transform.position.y, 
//		                        transform.position.z + Input.GetAxis("Horizontal")*speed*Time.deltaTime);
//        if (Input.GetButtonDown("ButtonA") && interactibleGo != null) {
//            interactibleGo.AInteractionPassThrought();
//            Debug.Log("COUCOU");
//            //gameObject.GetComponent<BeingBehavior>().AInteractionPassThrought();
//        }
//        else if (Input.GetButtonDown("ButtonB") && interactibleGo != null) {
//            interactibleGo.BInteractionPassThrought();
//            //gameObject.GetComponent<BeingBehavior>().BInteractionPassThrought();
//        }
//        else if (Input.GetButtonDown("ButtonX") && interactibleGo != null)
//            interactibleGo.XInteractionPassThrought();
//        else if (Input.GetButtonDown("ButtonY") && interactibleGo != null)
//            interactibleGo.YInteractionPassThrought();
//        else if (Input.GetButtonDown("ButtonRT") && interactibleGo != null)
//            Debug.Log("USING CAPACITY");
//        else if (Input.GetButtonDown("ButtonStart") && interactibleGo != null)
//            Debug.Log("HELLO START");
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        Debug.Log("collider:"+other.gameObject.name);
//        if (other.gameObject.CompareTag("Interactif"))
//            interactibleGo = other.gameObject.GetComponent<BeingBehavior>();
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.CompareTag("Interactif"))
//            interactibleGo = null;
//    }
//}