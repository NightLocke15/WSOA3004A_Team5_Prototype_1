using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCube : MonoBehaviour
{
    Movement _movement;
    ScriptHandler _scriptHandler;
    public GameObject cubeOne;
    public GameObject cubeTwo;
    public GameObject playerCube;

    

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        _scriptHandler = GameObject.Find("Script Handler").GetComponent<ScriptHandler>();
        cubeOne.SetActive(false);
        cubeTwo.SetActive(false);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _movement.upright == true)
        {
            Debug.Log("Yes");
            playerCube.SetActive(false);
            cubeOne.SetActive(true);
            cubeTwo.SetActive(true);

            cubeOne.transform.position = playerCube.transform.position + new Vector3(0, -0.5f, 0);

            _scriptHandler.movementCube1.enabled = true;
        }
    }
}
