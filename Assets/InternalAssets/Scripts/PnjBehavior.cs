using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum StateMovementMachine {Idle, Interact, Walk};

public class PnjBehavior : MonoBehaviour {

    public int speed = 1;
    float timer = 0;
    StateMovementMachine state;
    Vector3 direction;
    bool backPos;
    Vector3 spawnPoint;

    void Start () {
        state = StateMovementMachine.Idle;
        spawnPoint = transform.position;
    }
	
	
	void Update () {
        

        switch (state) {

            case StateMovementMachine.Idle:
                timer += Time.deltaTime;
                if (timer > 5f) {
                    state = StateMovementMachine.Walk;
                    direction = Random.insideUnitSphere * 10;
                    direction.Normalize();
                }
                break;

            case StateMovementMachine.Interact:

                break;

            case StateMovementMachine.Walk:
                Move(backPos);
                timer -= Time.deltaTime*3;
                if (timer < 0) {
                    timer = 0;
                    backPos = !backPos;
                    state = StateMovementMachine.Idle;
                }
                
                break;

            default:
                break;

        }

    }

    void Move(bool backToSpawn){
        if (backToSpawn) {
            direction = spawnPoint - transform.position;
            direction.Normalize();
        }
        transform.LookAt(direction);
        transform.position = transform.position + new Vector3(direction.x, 0, direction.z) * Time.deltaTime;
    }
}
