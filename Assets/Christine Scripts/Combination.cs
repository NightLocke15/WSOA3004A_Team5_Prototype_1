using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    public GameObject cubeOne;
    public GameObject cubeTwo;
    public GameObject playerCube;
    Movement _movement;
     public AudioClip combineSound; // Audio clip for the combination sound
    public GameObject soundPlayer; // Reference to the GameObject that will play the soun
    ScriptHandler _scriptHandler;

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        _scriptHandler = GameObject.Find("Script Handler Variant").GetComponent<ScriptHandler>();

        if (soundPlayer == null)
        {
            Debug.LogError("Sound Player GameObject is not assigned!");
        }

    }
     private void PlayCombineSound()
    {
        if (soundPlayer != null && combineSound != null)
        {
            AudioSource audioSource = soundPlayer.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.clip = combineSound;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource component is missing on the Sound Player GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("Sound Player or Combine Sound is not assigned.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "HalfCube1" || other.gameObject.tag == "HalfCube2")
        {
            _scriptHandler.split = false;
            
            _scriptHandler.movementCube1._moving = false;
            _scriptHandler.movementCube2._moving = false;

            if (cubeOne.transform.position.z < (cubeTwo.transform.position.z - 0.2) && cubeOne.transform.position.x == cubeTwo.transform.position.x) // forward and back
            {
                PlayCombineSound(); // Play the reconnect sound before changing states
                Debug.Log("front");
                cubeOne.SetActive(false);
                cubeTwo.SetActive(false);
                playerCube.SetActive(true);

                playerCube.transform.position = cubeOne.transform.position + new Vector3(0, 0, 0.5f);
                playerCube.transform.rotation = Quaternion.Euler(90, 0, 0);
                _movement.strings.Add("not upright");
                _movement._moving = false;
                _movement.front = true;
                _movement.back = false;
                _movement.left = false;
                _movement.right = false;
            }
            else if (cubeOne.transform.position.z > (cubeTwo.transform.position.z + 0.2) && cubeOne.transform.position.x == cubeTwo.transform.position.x)
            {
                PlayCombineSound(); // Play the reconnect sound before changing states
                Debug.Log("back");
                cubeOne.SetActive(false);
                cubeTwo.SetActive(false);
                playerCube.SetActive(true);

                playerCube.transform.position = cubeOne.transform.position + new Vector3(0, 0, -0.5f);
                playerCube.transform.rotation = Quaternion.Euler(90, 0, 0);
                _movement.strings.Add("not upright");
                _movement._moving = false;
                _movement.front = true;
                _movement.back = false;
                _movement.left = false;
                _movement.right = false;
            }
            else if (cubeOne.transform.position.x < (cubeTwo.transform.position.x - 0.2) && cubeOne.transform.position.z == cubeTwo.transform.position.z) // left and right
            {
                PlayCombineSound(); // Play the reconnect sound before changing states
                Debug.Log("left");
                cubeOne.SetActive(false);
                cubeTwo.SetActive(false);
                playerCube.SetActive(true);

                playerCube.transform.position = cubeOne.transform.position + new Vector3(0.5f, 0, 0);
                playerCube.transform.rotation = Quaternion.Euler(0, 0, 90);
                _movement.strings.Add("not upright");
                _movement._moving = false;
                _movement.front = false;
                _movement.back = false;
                _movement.left = true;
                _movement.right = false;
            }
            else if (cubeOne.transform.position.x > (cubeTwo.transform.position.x + 0.2) && cubeOne.transform.position.z == cubeTwo.transform.position.z)
            {
                PlayCombineSound(); // Play the reconnect sound before changing states
                Debug.Log("right");
                cubeOne.SetActive(false);
                cubeTwo.SetActive(false);
                playerCube.SetActive(true);

                playerCube.transform.position = cubeOne.transform.position + new Vector3(-0.5f, 0, 0);
                playerCube.transform.rotation = Quaternion.Euler(0, 0, 90);
                _movement.strings.Add("not upright");
                _movement._moving = false;
                _movement.front = false;
                _movement.back = false;
                _movement.left = true;
                _movement.right = false;
            }
        }

       
    }
}
