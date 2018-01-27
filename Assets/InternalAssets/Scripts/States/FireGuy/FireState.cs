using UnityEngine;

public class FireState : State
{
    public FireState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_) : base(sub_, interactibleButtonEnum_, interactionRadius_)
    {
    }

    public override void Tick()
    {

        //if player get his fire
        if (Input.GetKeyDown("d")) {
            sub.SetState(new NeutralState(sub, interactibleButtonEnum, interactionRadius));
        }
    }

    public override void OnStateEnter()
    {
        sub.gameObject.GetComponent<Renderer>().material.color = Color.red;
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
