using UnityEngine;

public class ActivatableObject : MonoBehaviour
{
    private bool isActive = false;
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        gameObject.SetActive(false); // Ensure the object is inactive at the start
        audioSource = GetComponent<AudioSource>(); // Initialize the AudioSource
    }

    public void Activate()
    {
        if (!isActive)
        {
            isActive = true;
            gameObject.SetActive(true);
            Debug.Log("Bridge Activated!"); // Debug statement
            PlayActivationSound(); // Play activation sound
        }
    }

    public void Deactivate()
    {
        if (isActive)
        {
            isActive = false;
            gameObject.SetActive(false);
            Debug.Log("Bridge Deactivated!"); // Debug statement
            PlayActivationSound(); // Play deactivation sound
        }
    }

    public void Toggle()
    {
        if (isActive)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }

    public bool IsActive()
    {
        return isActive;
    }

    private void PlayActivationSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            Debug.Log("Playing Sound!"); // Debug statement
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip not set!"); // Warning if sound is not set
        }
    }
}
