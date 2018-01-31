using UnityEngine;

public class Player_FireState : State {

    GameObject stateFX;
    GameObject light;

    public Player_FireState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_, NameState nameState_) : base(sub_, interactibleButtonEnum_, interactionRadius_, nameState_) {
    }

    public override void Tick() {

    }

    public override void OnStateEnter() {
        GameObject.Destroy(GameObject.Instantiate(sub.prefabGiveFX, sub.spawnerFxState.transform.position, Quaternion.identity), 0.5f);
        stateFX = GameObject.Instantiate(sub.prefabFireFXState, sub.spawnerFxState.transform.position, sub.gameObject.transform.rotation);
        stateFX.transform.parent = sub.gameObject.transform;
        light = GameObject.Instantiate(sub.prefabLightSpot, sub.spawnerFxState.transform.position, sub.gameObject.transform.rotation);
        CharacterBehaviour.Instance.AddOffroadAnchor(light.GetComponent<LightSpot>());
        light.transform.position = new Vector3(light.transform.position.x, light.transform.position.y + 2, light.transform.position.z);
        light.transform.parent = sub.gameObject.transform;
        //CharacterBehaviour.Instance.lockInputs = false;
    }

    public override void OnStateExit() {
        CharacterBehaviour.Instance.RemoveOffroadAnchor(light.GetComponent<LightSpot>());
        GameObject.Destroy(GameObject.Instantiate(sub.prefabGiveFX, sub.spawnerFxState.transform.position, Quaternion.identity), 0.5f);
        GameObject.Destroy(stateFX);
        //GameObject.Destroy(light);
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
