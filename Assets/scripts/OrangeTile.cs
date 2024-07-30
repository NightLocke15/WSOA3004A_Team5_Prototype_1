using System.Collections;
using UnityEngine;

public class OrangeTile : MonoBehaviour
{
    public GameObject orangeTile;
    Movement _movement;
    ScriptHandler _scripthandler;
    [SerializeField] private bool moveDown = false;
    [SerializeField] private GameObject playerCube;
    public AudioClip fallingSound; // Audio clip for the falling sound
    private AudioSource audioSource; // Reference to the AudioSource component
    private bool isBreaking = false; // Flag to check if the tile is already breaking

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        _scripthandler = GameObject.Find("Script Handler Variant").GetComponent<ScriptHandler>();
        playerCube = GameObject.Find("Player Holder");

        // Add an AudioSource component if it doesn't exist
        if (gameObject.GetComponent<AudioSource>() == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        if (fallingSound == null)
        {
            Debug.LogError("Falling sound clip is not assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _movement.upright == true && !isBreaking)
        {
            isBreaking = true; // Set the flag to prevent re-triggering
            _scripthandler.fall = true;
            _scripthandler.timer = true;
            PlayFallingSound();
        }
    }

    private void PlayFallingSound()
    {
        if (audioSource != null && fallingSound != null)
        {
            audioSource.clip = fallingSound;
            audioSource.Play();
            StartCoroutine(SetTileInactiveAfterSound());
        }
        else
        {
            Debug.LogWarning("AudioSource or fallingSound is missing.");
            SetTileInactive();
        }
    }

    private IEnumerator SetTileInactiveAfterSound()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        SetTileInactive();
    }

    private void SetTileInactive()
    {
        orangeTile.SetActive(false);
        Debug.Log("OrangeTile");
        Debug.Log(gameObject.name);
    }
}
