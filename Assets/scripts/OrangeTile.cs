using System.Collections;
using UnityEngine;

public class OrangeTile : MonoBehaviour
{
    public AudioClip fallingSound; // Audio clip for falling sound
    private AudioSource audioSource;
    private bool isBreaking = false; // Flag to check if the tile is already breaking

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the tile: " + other.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Something staying on the tile: " + other.name);
        if (other.CompareTag("Player") && !isBreaking)
        {
            Debug.Log("Player is on the orange tile.");
            if (IsStandingVertically(other))
            {
                Debug.Log("Player is standing vertically on the orange tile.");
                BreakTile();
            }
            else
            {
                Debug.Log("Player is not standing vertically on the orange tile.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Something exited the tile: " + other.name);
    }

    private bool IsStandingVertically(Collider other)
    {
        Bounds playerBounds = other.bounds;

        // Check if the player block is standing vertically (tallest dimension is along the y-axis)
        bool isStandingVertically = playerBounds.size.y > playerBounds.size.x && playerBounds.size.y > playerBounds.size.z;

        return isStandingVertically;
    }

    private void BreakTile()
    {
        Debug.Log("Orange Tile Broken!");
        isBreaking = true; // Set the flag to prevent re-triggering
        if (audioSource != null && fallingSound != null)
        {
            audioSource.clip = fallingSound;
            audioSource.Play();
            StartCoroutine(DestroyAfterDelay(0.5f)); // Adjust the delay time as needed
        }
        else
        {
            Debug.LogWarning("AudioSource or fallingSound is missing.");
            Destroy(gameObject); // Destroy the tile immediately if there's no sound
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject); // Destroy the tile after the delay
    }
}
