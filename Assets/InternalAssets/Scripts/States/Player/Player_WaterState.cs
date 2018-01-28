using UnityEngine;

public class Player_WaterState : State {

    GameObject stateFX;

    public Player_WaterState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_, NameState nameState_) : base(sub_, interactibleButtonEnum_, interactionRadius_, nameState_) {
    }

    public override void Tick() {

    }

    public override void OnStateEnter() {
        GameObject.Destroy(GameObject.Instantiate(sub.prefabGiveFX, sub.spawnerFxState.transform.position, Quaternion.identity), 0.5f);
        stateFX = GameObject.Instantiate(sub.prefabWaterFXState, sub.spawnerFxState.transform.position, Quaternion.identity);
    }

    public override void OnStateExit() {
        GameObject.Destroy(GameObject.Instantiate(sub.prefabGiveFX, sub.spawnerFxState.transform.position, Quaternion.identity), 0.5f);
        GameObject.Destroy(stateFX);
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
