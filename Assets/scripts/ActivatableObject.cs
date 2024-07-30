//had to be attached to the bridge and need to drag it into the soft/hard switch in its inspector to link
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
            PlayActivationSound(); // Play activation sound
            Debug.Log("Bridge Activated!");
        }
    }

    public void Deactivate()
    {
        if (isActive)
        {
            isActive = false;
            gameObject.SetActive(false);
            PlayActivationSound(); // Play activation sound
            Debug.Log("Bridge Deactivated!");
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
