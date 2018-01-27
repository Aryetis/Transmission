using UnityEngine;

public class NeutralState : State
{
    public NeutralState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_) : base(sub_, interactibleButtonEnum_, interactionRadius_)
    {
    }

    public override void Tick()
    {

        //if player give fire
        if (Input.GetKeyDown("s")){
            sub.SetState(new FireState(sub, interactibleButtonEnum, interactionRadius));
        }
        
    }

    public override void OnStateEnter()
    {
        sub.gameObject.GetComponent<Renderer>().material.color = Color.gray;
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
