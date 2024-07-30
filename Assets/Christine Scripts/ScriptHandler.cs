using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHandler : MonoBehaviour
{
    public SmallMovement movementCube1;
    public SmallMovement movementCube2;
    Movement _movement;

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();

        movementCube1 = GameObject.Find("Half One").GetComponent<SmallMovement>();
        movementCube2 = GameObject.Find("Half Two").GetComponent<SmallMovement>();

        movementCube1.enabled = false;
        movementCube2.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");

            if (movementCube1.enabled == true)
            {
                movementCube1.enabled = false;
                movementCube2.enabled = true;
            }
            else if (movementCube2.enabled == true)
            {
                movementCube2.enabled = false;
                movementCube1.enabled = true;
            }
            else
            {

            }
        }
    }
}
