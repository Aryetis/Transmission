using UnityEngine;

public class Awake : State
{
    public Awake(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_) : base(sub_, interactibleButtonEnum_, interactionRadius_)
    {
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
