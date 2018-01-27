using UnityEngine;

public class Sleeping : State
{
    public Sleeping(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_) : base(sub_, interactibleButtonEnum_, interactionRadius_)
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

    public override void AInteraction()
    {
        Debug.Log("BACK TO YOU");
    }

    public override void BInteraction()
    {
        Debug.Log("BACK TO YOU");
    }

    public override void XInteraction()
    {

        Debug.Log("BACK TO YOU");
    }

    public override void YInteraction()
    {
        Debug.Log("BACK TO YOU");
    }
}
