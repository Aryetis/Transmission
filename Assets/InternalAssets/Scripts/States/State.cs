using UnityEngine;

public enum NameState { Fire, Neutral, Water, Wind, Earth, Love, Dead, Life }

public abstract class State
{
    public BeingBehavior sub; // subject of the state
    protected Interactiblebutton interactibleButtonEnum; // HUD interaction button, state dependant 
    protected NameState nameState;
    protected float interactionRadius;
    // HUD related
    protected Sprite interactionButtonSprite;
    protected CapsuleCollider col = null;
    public GameObject hudButtonGo = null;
    protected SpriteRenderer buttonSprite;

    public abstract void Tick();
    
    // OVERLOAD METHODS 
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public virtual void OnTriggerEnterPassThrought(Collider col) { }
    public virtual void OnTriggerExitPassThrought(Collider col) { }
    public virtual void AInteraction() { }
    public virtual void BInteraction() { }
    public virtual void XInteraction() { }
    public virtual void YInteraction() { }


    public State(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_, NameState nameState_)
    {
        sub = sub_;
        interactibleButtonEnum = interactibleButtonEnum_;
        interactionRadius = interactionRadius_;
        SetHud();
    }

    public void SetHud(Interactiblebutton but) {
        interactibleButtonEnum = but;
        SetHud();
    }

    public void SetHud()
    {
        // Load correct button sprite 
        switch (interactibleButtonEnum)
        {
            case Interactiblebutton.a:
                {
                    interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/UI_Acquire");
                    break;
                }
            case Interactiblebutton.b:
                {
                    interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/UI_Transmit");
                    break;
                }
            case Interactiblebutton.x:
                {
                    interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonX");
                    break;
                }
            case Interactiblebutton.y:
                {
                    interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonY");
                    break;
                }
            case Interactiblebutton.none:
                {
                    // TODO handle player case => don't create hudButtonGo therefore lots of repercusions
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
        CapsuleCollider col = sub.gameObject.GetComponent<CapsuleCollider>();
        if ( sub.gameObject.CompareTag("Player") && col != null && !col.isTrigger )
        {
            Debug.Log("sub.gameObject.name : " + sub.gameObject.name);
            col = sub.gameObject.AddComponent<CapsuleCollider>();
            col.radius += interactionRadius;
            col.isTrigger = true;
        }

        // Set HUD
        else
        {
            hudButtonGo = new GameObject();
            hudButtonGo.AddComponent<BillboardBehavior>();
            hudButtonGo.transform.position = sub.transform.position + Vector3.up * 2;
            hudButtonGo.transform.parent = sub.transform;
            //}
            hudButtonGo.name = sub.gameObject.name + "_hudButtonGo";
            hudButtonGo.SetActive(false);

            // Set SpriteRenderer buttonSprite
            buttonSprite = hudButtonGo.AddComponent<SpriteRenderer>();
            buttonSprite.sprite = interactionButtonSprite;
        }
    }

    //void OnDestroy()
    //{
    //    // Ugly hack 
    //    // TODO (in a future time dimension) : handle creation of gameobject & collider correctly   
    //    GameObject.Destroy(hudButtonGo);
    //    GameObject.Destroy(hudButtonGo);
    //}
}