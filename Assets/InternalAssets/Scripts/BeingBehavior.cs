using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingBehavior : MonoBehaviour
{
    // State/category related dpf
    public enum Category { Mushroom, Fisherman, BridgeBuilder, Gardener, Windmill, AirGuy, EarthGuy, WaterGuy, FireGuy, Brazier, TEST }; // Used to set initial State
    [SerializeField] private Category cat;
    private State state;

    // HUD related variables
    public enum InteractibleButton { A, B, X, Y, NONE };

    [SerializeField] private InteractibleButton interactibleButtonEnum;
    [SerializeField] private float interactionRadius = 5.0f;

    private Sprite interactionButtonSprite;
    private CapsuleCollider col;
    private GameObject hudButtonGo;
    private SpriteRenderer buttonSprite;

	// Use this for initialization
	void Start ()
    {
        switch (cat)
        {
            case Category.TEST :
            {
                SetState(new Sleeping(gameObject.GetComponent<BeingBehavior>()));
                break;
            }
            default:
            {
                Debug.LogError("unknown category");
                break;
            }

        }


    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
            hudButtonGo.SetActive(true);
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
            hudButtonGo.SetActive(false);
    }

    public void SetState(State state_)
    {
        if (state != null)
            state.OnStateExit();

        state = state_;
        gameObject.name = "InteractibleNPC_" + state_.GetType().Name;

        if (state != null)
            state.OnStateEnter();
    }

    public void SetInteractibleButton(InteractibleButton b)
    {
        // Load correct button sprite 
        switch (interactibleButtonEnum)
        {
            case InteractibleButton.A:
                {
                    interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonA");
                    break;
                }
            case InteractibleButton.B:
                {
                    interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonB");
                    break;
                }
            case InteractibleButton.X:
                {
                    interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonX");
                    break;
                }
            case InteractibleButton.Y:
                {
                    interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonY");
                    break;
                }
            case InteractibleButton.NONE:
                {
                    interactionButtonSprite = null;
                    break;
                }
            default:
                {
                    Debug.LogError("unknown interactible button");
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
}
