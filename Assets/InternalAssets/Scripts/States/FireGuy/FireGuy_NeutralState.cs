﻿using UnityEngine;

public class FireGuy_NeutralState : State
{
    public FireGuy_NeutralState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_, NameState nameState_) : base(sub_, interactibleButtonEnum_, interactionRadius_, nameState_) {
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
        Debug.Log("AGROUGROU");
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<BeingBehavior>().nameState.Equals(nameState)) {
            sub.SetState(new FireGuy_FireState(sub, interactibleButtonEnum, interactionRadius, nameState));
        }
        
    }

    public override void XInteraction() {

        Debug.Log("BACK TO YOU");
    }

    public override void YInteraction() {
        Debug.Log("BACK TO YOU");
    }


}
