using UnityEngine;

public class Player_WindState : State {

    public Player_WindState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_, NameState nameState_) : base(sub_, interactibleButtonEnum_, interactionRadius_, nameState_) {
    }

    public override void Tick() {

    }

    public override void OnStateEnter() {
        sub.gameObject.GetComponent<Renderer>().material.color = Color.green;
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

    }

    public override void XInteraction() {

    }

    public override void YInteraction() {

    }
}
