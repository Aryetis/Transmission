using UnityEngine;

public class PlayerEmpty : State
{
    // HUD related
    private Sprite interactionButtonSprite;
    private CapsuleCollider col;
    private GameObject hudButtonGo;
    private SpriteRenderer buttonSprite;

    public PlayerEmpty(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_) : base(sub_, interactibleButtonEnum_, interactionRadius_)
    {
        //SetHud(); // Set hud using interactibleButtonEnum's mother value
    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }

    public override void OnTriggerEnterPassThrought(Collider col)
    {
        // toggle hud
        if (col.CompareTag("Player"))
            hudButtonGo.SetActive(true);
    }

    public override void OnTriggerExitPassThrought(Collider col)
    {
        // toggle hud
        if (col.CompareTag("Player"))
            hudButtonGo.SetActive(false);
    }

    //public override void SetHud()
    //{
    //    // Load correct button sprite 
    //    switch (interactibleButtonEnum)
    //    {
    //        case Interactiblebutton.a:
    //            {
    //                interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonA");
    //                break;
    //            }
    //        case Interactiblebutton.b:
    //            {
    //                interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonB");
    //                break;
    //            }
    //        case Interactiblebutton.x:
    //            {
    //                interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonX");
    //                break;
    //            }
    //        case Interactiblebutton.y:
    //            {
    //                interactionButtonSprite = Resources.Load<Sprite>("ButtonImages/xboxControllerButtonY");
    //                break;
    //            }
    //        default:
    //            {
    //                Debug.LogError("unknown interactible button");
    //                break;
    //            }
    //    }

    //    // Set collider / interaction zone
    //    col = sub.gameObject.AddComponent<CapsuleCollider>();
    //    col.radius += interactionRadius;
    //    col.isTrigger = true;

    //    // Creating child gameobject holding SPriteRenderer
    //    hudButtonGo = new GameObject();
    //    hudButtonGo.name = "hudButtonGo";
    //    hudButtonGo.transform.position = sub.transform.position + Vector3.up * 2;
    //    hudButtonGo.AddComponent<BillboardBehavior>();
    //    hudButtonGo.SetActive(false);

    //    // Set SpriteRenderer buttonSprite
    //    buttonSprite = hudButtonGo.AddComponent<SpriteRenderer>();
    //    buttonSprite.sprite = interactionButtonSprite;
    //}
}
