﻿using UnityEngine;

public class WaterGuy_FireState : State
{
    public WaterGuy_FireState(BeingBehavior sub_, Interactiblebutton interactibleButtonEnum_, float interactionRadius_, NameState nameState_) : base(sub_, interactibleButtonEnum_, interactionRadius_, nameState_)
    {
    }

    public override void Tick()
    {


    }

    public override void OnStateEnter()
    {
        sub.gameObject.GetComponent<Renderer>().material.color = Color.red;
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
        player.nameState = NameState.Fire;
        player.SetState(new Player_FireState(player, player.interactiblebuttonenum, player.interactionradius, player.nameState));
        sub.SetState(new WaterGuy_NeutralState(sub, interactibleButtonEnum, interactionRadius, nameState));
        
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
