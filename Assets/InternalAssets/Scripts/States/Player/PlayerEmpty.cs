using UnityEngine;

public class PlayerEmpty : State
{
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
}
