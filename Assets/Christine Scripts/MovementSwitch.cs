using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementSwitch : MonoBehaviour
{
    public SmallMovement movementCube1;
    public SmallMovement movementCube2;
    public GameObject cubeOne;

    public TextMeshProUGUI activeCube;
    public GameObject activeCubeObject;

   

    void Update()
    {
        if (movementCube1.enabled == true)
        {
            activeCubeObject.SetActive(true);
            activeCube.text = "Active Cube: 1";
        }
        else if (movementCube2.enabled == true)
        {
            activeCubeObject.SetActive(true);
            activeCube.text = "Active Cube: 2";
        }
        else
        {
            activeCubeObject.SetActive(false);
        }

        if (cubeOne.activeInHierarchy == false)
        {
            activeCubeObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
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
