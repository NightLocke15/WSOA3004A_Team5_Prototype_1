using System.Collections;
using UnityEngine;

public class ReconnectSoundPlayer : MonoBehaviour
{
    public AudioClip reconnectSound; // Audio clip for the reconnect sound
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component to the GameObject
        audioSource.playOnAwake = false; // Ensure the sound doesn't play on start
    }

    public void PlayReconnectSound()
    {
        if (audioSource != null && reconnectSound != null)
        {
            audioSource.clip = reconnectSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or reconnectSound is missing.");
        }
    }
}
