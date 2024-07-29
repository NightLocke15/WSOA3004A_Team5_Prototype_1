using UnityEngine;

public class AudioManager : MonoBehaviour
  {
    public AudioClip backgroundMusic; // Assign this in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Add an AudioSource component if it doesn't exist
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the background music and play it
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true; // Loop the background music
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Background music not assigned in " + gameObject.name);
        }
    }
}
