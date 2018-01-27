﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Interactiblebutton { a, b, x, y };

public class BeingBehavior : MonoBehaviour
{
    // State/category related dpf
    public enum Category { Mushroom, Fisherman, BridgeBuilder, Gardener, Windmill, AirGuy, EarthGuy, WaterGuy, FireGuy, Brazier, Player, TEST }; // Used to set initial State
    public Category cat = Category.FireGuy;
    private State state;

    // Entry values for HUD
    [SerializeField] private Interactiblebutton interactiblebuttonenum;
    [SerializeField] private float interactionradius = 5.0f;


    // Use this for initialization
    void Start ()
    {
        switch (cat)
        {
            // TODO insert loooooooooots of states 
            case Category.TEST :
            {
                SetState(new Sleeping(gameObject.GetComponent<BeingBehavior>(), interactiblebuttonenum, interactionradius));
                break;
            }
            case Category.Player :
            {
                SetState(new PlayerEmpty(gameObject.GetComponent<BeingBehavior>(), interactiblebuttonenum, interactionradius));
                break;
            }
            default:
            {
                Debug.LogError("unknown category : "+cat);
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        state.OnTriggerEnterPassThrought(col);
    }

    private void OnTriggerExit(Collider col)
    {
        state.OnTriggerExitPassThrought(col);
    }

    public void SetState(State state_)
    {
        if (state != null)
            state.OnStateExit();

        state = state_;
        gameObject.name = cat.ToString() + "_" + state_.GetType().Name;

        if (state != null)
            state.OnStateEnter();
    }
}
