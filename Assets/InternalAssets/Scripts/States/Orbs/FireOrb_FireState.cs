using UnityEngine;

public class FireOrb_FireState : State {

    GameObject stateFX;
    GameObject light;

    public FireOrb_FireState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_, NameState nameState_) : base(sub_, interactibleButtonEnum_, interactionRadius_, nameState_) {
    }

    public override void Tick() {


    }

    public override void OnStateEnter() {
        SetHud(Interactiblebutton.a);
        stateFX = GameObject.Instantiate(sub.prefabFireFXState, sub.spawnerFxState.transform.position, sub.gameObject.transform.rotation);
        stateFX.transform.parent = sub.gameObject.transform;
        light = GameObject.Instantiate(sub.prefabLightSpot, sub.spawnerFxState.transform.position, sub.gameObject.transform.rotation);
        light.transform.position = new Vector3(light.transform.position.x, light.transform.position.y + 2, light.transform.position.z);
        light.transform.parent = sub.gameObject.transform;
    }

    public override void OnStateExit() {
        GameObject.Destroy(stateFX);
        GameObject.Destroy(light);
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
        Debug.Log("A PU LE FEU");
        nameState = NameState.Neutral;
        GameObject.Destroy(GameObject.Instantiate(sub.prefabGiveFX, sub.spawnerFxState.transform.position, Quaternion.identity),0.5f);
        BeingBehavior player = GameObject.FindGameObjectWithTag("Player").GetComponent<BeingBehavior>();
        player.nameState = NameState.Fire;
        player.SetState(new Player_FireState(player, player.interactiblebuttonenum, player.interactionradius, player.nameState));
        sub.SetState(new FireOrb_NeutralState(sub, interactibleButtonEnum, interactionRadius, nameState));

    }

    public override void BInteraction() {
       
    }

    public override void XInteraction() {

        Debug.Log("BACK TO YOU");
    }

    public override void YInteraction() {
        Debug.Log("BACK TO YOU");
    }
}
