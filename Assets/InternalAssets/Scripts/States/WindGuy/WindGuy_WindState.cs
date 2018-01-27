using UnityEngine;

public class WindGuy_WindState : State
{
    public WindGuy_WindState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_, NameState nameState_) : base(sub_, interactibleButtonEnum_, interactionRadius_, nameState_)
    {
    }

    public override void Tick()
    {


    }

    public override void OnStateEnter()
    {
        sub.gameObject.GetComponent<Renderer>().material.color = Color.green;
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
        player.nameState = NameState.Wind;
        player.SetState(new Player_WindState(player, player.interactiblebuttonenum, player.interactionradius, player.nameState));
        sub.SetState(new WindGuy_NeutralState(sub, interactibleButtonEnum, interactionRadius, nameState));
        
    }

    public override void BInteraction() {
        BeingBehavior player = GameObject.FindGameObjectWithTag("Player").GetComponent<BeingBehavior>();
        if (player.nameState.Equals(NameState.Earth)) {
            nameState = NameState.Dead;
            player.nameState = NameState.Neutral;
            player.SetState(new PlayerEmpty(player, player.interactiblebuttonenum, player.interactionradius, player.nameState));
            GameObject.Destroy(sub.gameObject);
        }
    }

    public override void XInteraction() {

        Debug.Log("BACK TO YOU");
    }

    public override void YInteraction() {
        Debug.Log("BACK TO YOU");
    }
}
