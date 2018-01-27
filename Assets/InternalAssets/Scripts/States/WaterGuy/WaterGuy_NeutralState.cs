using UnityEngine;

public class WaterGuy_NeutralState : State
{
    public WaterGuy_NeutralState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_, NameState nameState_) : base(sub_, interactibleButtonEnum_, interactionRadius_, nameState_) {
    }

    public override void Tick()
    {

        
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

    public override void AInteraction() {
        Debug.Log("BACK TO YOU");
    }

    public override void BInteraction() {
        
        BeingBehavior player = GameObject.FindGameObjectWithTag("Player").GetComponent<BeingBehavior>();
        if (player.nameState.Equals(NameState.Fire)) {
            nameState = NameState.Fire;
            player.nameState = NameState.Neutral;
            player.SetState(new PlayerEmpty(player, player.interactiblebuttonenum, player.interactionradius, player.nameState));
            sub.SetState(new WaterGuy_FireState(sub, interactibleButtonEnum, interactionRadius, nameState));
        }
        if (player.nameState.Equals(NameState.Water)) {
            nameState = NameState.Water;
            player.nameState = NameState.Neutral;
            player.SetState(new PlayerEmpty(player, player.interactiblebuttonenum, player.interactionradius, player.nameState));
            sub.SetState(new WaterGuy_WaterState(sub, interactibleButtonEnum, interactionRadius, nameState));
        }
        if (player.nameState.Equals(NameState.Wind)) {
            nameState = NameState.Wind;
            player.nameState = NameState.Neutral;
            player.SetState(new PlayerEmpty(player, player.interactiblebuttonenum, player.interactionradius, player.nameState));
            sub.SetState(new WaterGuy_WindState(sub, interactibleButtonEnum, interactionRadius, nameState));
        }
        if (player.nameState.Equals(NameState.Earth)) {
            nameState = NameState.Earth;
            player.nameState = NameState.Neutral;
            player.SetState(new PlayerEmpty(player, player.interactiblebuttonenum, player.interactionradius, player.nameState));
            sub.SetState(new WaterGuy_EarthState(sub, interactibleButtonEnum, interactionRadius, nameState));
        }

    }

    public override void XInteraction() {

        Debug.Log("BACK TO YOU");
    }

    public override void YInteraction() {
        Debug.Log("BACK TO YOU");
    }


}
