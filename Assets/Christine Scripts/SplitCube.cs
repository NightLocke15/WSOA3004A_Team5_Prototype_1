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

    private AudioSource audioSource; // Reference to the AudioSource component


    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        _scriptHandler = GameObject.Find("Script Handler").GetComponent<ScriptHandler>();
        cubeOne.SetActive(false);
        cubeTwo.SetActive(false);        

        audioSource = GetComponent<AudioSource>(); // Initialize the AudioSource
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _movement.upright == true)
        {
            Debug.Log("Yes");
            playerCube.SetActive(false);
            cubeOne.SetActive(true);
            cubeTwo.SetActive(true);

            float x = Mathf.Round(playerCube.transform.position.x * 2f) / 2f;
            float z = Mathf.Round(playerCube.transform.position.z * 2f) / 2f;


            cubeOne.transform.position = new Vector3(x, 0.5f, z);

            _scriptHandler.movementCube1.enabled = true;
            // Play the split sound
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
