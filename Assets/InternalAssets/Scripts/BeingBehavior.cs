using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Interactiblebutton { a, b, x, y, none };

public class BeingBehavior : MonoBehaviour
{
    // State/category related dpf
    public enum Category { Mushroom, Fisherman, BridgeBuilder, Gardener, Windmill, WindGuy, EarthGuy, WaterGuy, FireGuy, Brazier, Player }; // Used to set initial State
    public Category cat = Category.FireGuy;
    public State state;
    public NameState nameState;

    // Entry values for HUD
    public Interactiblebutton interactiblebuttonenum;
    public float interactionradius;


    // Use this for initialization
    void Start ()
    {
        switch (cat)
        {
            // TODO insert loooooooooots of states 

            case Category.Mushroom: {
                nameState = NameState.Life;
                SetState(new Mushroom_LifeState(gameObject.GetComponent<BeingBehavior>(), interactiblebuttonenum, interactionradius, nameState));
                break;
            }

            case Category.Brazier: {
                nameState = NameState.Neutral;
                SetState(new Brazier_NeutralState(gameObject.GetComponent<BeingBehavior>(), interactiblebuttonenum, interactionradius, nameState));
                break;
            }

            case Category.FireGuy: {
                nameState = NameState.Fire;
                SetState(new FireGuy_FireState(gameObject.GetComponent<BeingBehavior>(), interactiblebuttonenum, interactionradius, nameState));
                break;
            }

            case Category.WaterGuy: {
                nameState = NameState.Water;
                SetState(new WaterGuy_WaterState(gameObject.GetComponent<BeingBehavior>(), interactiblebuttonenum, interactionradius, nameState));
                break;
            }

            case Category.WindGuy: {
                nameState = NameState.Wind;
                SetState(new WindGuy_WaterState(gameObject.GetComponent<BeingBehavior>(), interactiblebuttonenum, interactionradius, nameState));
                break;
            }

            case Category.EarthGuy: {
                nameState = NameState.Earth;
                SetState(new EarthGuy_WaterState(gameObject.GetComponent<BeingBehavior>(), interactiblebuttonenum, interactionradius, nameState));
                break;
            }

            case Category.Player :
            {
                nameState = NameState.Neutral;
                SetState(new PlayerEmpty(gameObject.GetComponent<BeingBehavior>(), interactiblebuttonenum, interactionradius, nameState));
                break;
            }
            default:
            {
                Debug.LogError("unknown category : "+cat);
                break;
            }
        }
    }

    private void Update()
    {
        state.Tick();
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
        {
            state.OnStateExit();
            Destroy(state.hudButtonGo);
        }

        state = state_;        
        
        gameObject.name = cat.ToString() + "_" + state_.GetType().Name;

        if (state != null)
            state.OnStateEnter();
    }

    public void AInteractionPassThrought()
    {
        state.AInteraction();
    }

    public void BInteractionPassThrought()
    {
        state.BInteraction();
    }

    public void XInteractionPassThrought()
    {
        state.XInteraction();
    }

    public void YInteractionPassThrought()
    {
        state.YInteraction();
    }
}
