using UnityEngine;

public class WindGuy_EarthState : State
{
    public WindGuy_EarthState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_, NameState nameState_) : base(sub_, interactibleButtonEnum_, interactionRadius_, nameState_)
    {
    }

    public override void Tick()
    {


    }

    public override void OnStateEnter()
    {
        sub.gameObject.GetComponent<Renderer>().material.color = new Color(145, 90, 20);
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

    public override void AInteraction() {
        nameState = NameState.Neutral;
        BeingBehavior player = GameObject.FindGameObjectWithTag("Player").GetComponent<BeingBehavior>();
        player.nameState = NameState.Earth;
        player.SetState(new Player_EarthState(player, player.interactiblebuttonenum, player.interactionradius, player.nameState));
        sub.SetState(new WindGuy_NeutralState(sub, interactibleButtonEnum, interactionRadius, nameState));
        
    }

    public override void BInteraction() {
        Debug.Log("BACK TO YOU");
    }

    public override void XInteraction() {

        Debug.Log("BACK TO YOU");
    }

    public override void YInteraction() {
        Debug.Log("BACK TO YOU");
    }
}
