using UnityEngine;

public class Player_FireState : State {

    public Player_FireState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_, NameState nameState_) : base(sub_, interactibleButtonEnum_, interactionRadius_, nameState_) {
    }

    public override void Tick() {

    }

    public override void OnStateEnter() {
        //sub.gameObject.GetComponent<Renderer>().material.color = Color.red;
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
        //BeingBehavior objectInteract = sub.gameObject.GetComponent<PlayerController>().interactibleGo;
        //Debug.Log("obj: " + objectInteract + " - state: " + objectInteract.nameState);
        //if (objectInteract != null) {
        //    if (objectInteract.nameState != NameState.Fire) {
        //        Debug.Log("YOP!");
        //        nameState = NameState.Neutral;
        //        sub.SetState(new PlayerEmpty(sub, interactibleButtonEnum, interactionRadius, nameState));
        //    }
        //}
    }

    public override void XInteraction() {

    }

    public override void YInteraction() {

    }
}
