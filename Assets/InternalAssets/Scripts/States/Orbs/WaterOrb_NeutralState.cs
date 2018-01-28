using UnityEngine;

public class WaterOrb_NeutralState : State {
    public WaterOrb_NeutralState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_, NameState nameState_) : base(sub_, interactibleButtonEnum_, interactionRadius_, nameState_) {
    }

    public override void Tick() {


    }

    public override void OnStateEnter() {
        SetHud(Interactiblebutton.b);
        
    }

    public override void OnStateExit() {

    }

    public override void OnTriggerEnterPassThrought(Collider col) {
        // toggle hud
        if (col.CompareTag("Player"))
            hudButtonGo.SetActive(true);
    }

    public override void OnTriggerExitPassThrought(Collider col) {
        // toggle hud
        if (col.CompareTag("Player"))
            hudButtonGo.SetActive(false);
    }

    public override void AInteraction() {

    }

    public override void BInteraction() {
        BeingBehavior player = GameObject.FindGameObjectWithTag("Player").GetComponent<BeingBehavior>();
        if (player.nameState.Equals(NameState.Water)) {
            nameState = NameState.Water;
            GameObject.Destroy(GameObject.Instantiate(sub.prefabGiveFX, sub.spawnerFxState.transform.position, Quaternion.identity), 0.5f);
            player.nameState = NameState.Neutral;
            player.SetState(new PlayerEmpty(player, player.interactiblebuttonenum, player.interactionradius, player.nameState));
            sub.SetState(new WaterOrb_WaterState(sub, interactibleButtonEnum, interactionRadius, nameState));
        }
    }

    public override void XInteraction() {

        Debug.Log("BACK TO YOU");
    }

    public override void YInteraction() {
        Debug.Log("BACK TO YOU");
    }
}
