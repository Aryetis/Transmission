using UnityEngine;

public abstract class State
{
    protected BeingBehavior sub; // subject of the state
    protected Interactiblebutton interactibleButtonEnum; // HUD interaction button, state dependant 
    protected float interactionRadius;
    // HUD related
    protected Sprite interactionButtonSprite;
    protected CapsuleCollider col;
    protected GameObject hudButtonGo;
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


    public State(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_)
    {
        sub = sub_;
        interactibleButtonEnum = interactibleButtonEnum_;
        interactionRadius = interactionRadius_;
        SetHud();
    }


    public void SetHud()
    {
        // Load correct button sprite 
        switch (interactibleButtonEnum)
        {
            case Interactiblebutton.a:
                {
                    interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonA");
                    break;
                }
            case Interactiblebutton.b:
                {
                    interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonB");
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
        col = sub.gameObject.AddComponent<CapsuleCollider>();
        col.radius += interactionRadius;
        col.isTrigger = true;

        // Creating child gameobject holding SPriteRenderer
        hudButtonGo = new GameObject();
        hudButtonGo.transform.parent = sub.transform;
        hudButtonGo.name = sub.gameObject.name+"_hudButtonGo";
        hudButtonGo.transform.position = sub.transform.position + Vector3.up * 2;
        hudButtonGo.AddComponent<BillboardBehavior>();
        hudButtonGo.SetActive(false);

        // Set SpriteRenderer buttonSprite
        buttonSprite = hudButtonGo.AddComponent<SpriteRenderer>();
        buttonSprite.sprite = interactionButtonSprite;
    }
}