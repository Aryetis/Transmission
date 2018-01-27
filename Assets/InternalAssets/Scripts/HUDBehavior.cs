using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDBehavior : MonoBehaviour
{
    enum InteractibleButtons { A, B, X, Y };

    [SerializeField] InteractibleButtons interactibleButtonEnum;
    [SerializeField] float interactionRadius = 5.0f;

    private Sprite interactionButtonSprite;
    private CapsuleCollider col;
    private GameObject hudButtonGo;
    private SpriteRenderer buttonSprite;

	// Use this for initialization
	void Start ()
    {
        // Load correct button sprite 
        switch (interactibleButtonEnum)
        {
            case InteractibleButtons.A :
            {
                interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonA");
                break;
            }
            case InteractibleButtons.B :
            {
                interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonB");
                break;
            }
            case InteractibleButtons.X :
            {
                interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonX");
                break;
            }
            case InteractibleButtons.Y :
            {
                interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonY");
                break;
            }
            default:
            {
                Debug.LogError("wrong interactible button");
                break;
            }
        }

        // Set collider / interaction zone
        col = gameObject.AddComponent<CapsuleCollider>();
        col.radius += interactionRadius;
        col.isTrigger = true;

        // Creating child gameobject holding SPriteRenderer
        hudButtonGo = new GameObject();
        hudButtonGo.transform.position = transform.position + Vector3.up * 2;
        hudButtonGo.AddComponent<BillboardBehavior>();
        hudButtonGo.SetActive(false);

        // Set SpriteRenderer buttonSprite
        buttonSprite = hudButtonGo.AddComponent<SpriteRenderer>();
        buttonSprite.sprite = interactionButtonSprite;
    }

    private void OnTriggerEnter(Collider col)
    {
        if( col.CompareTag("Player") )
            hudButtonGo.SetActive(true);
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
            hudButtonGo.SetActive(false);
    }
}
