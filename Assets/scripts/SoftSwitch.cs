using UnityEngine;

public class SoftSwitch : MonoBehaviour
{
    public ActivatableObject activatableObject;
    private bool playerExited = false; // Track if the player has exited the tile

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            if (IsFullyCovering(other))
            {
               
                if (playerExited) // Check if the player has exited before reentering
                {
                    activatableObject.Toggle();
                    playerExited = false; // Reset the flag after toggling
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerExited = true; // Set the flag when the player exits the tile
        }
    }

    bool IsFullyCovering(Collider other)
    {
        Bounds tileBounds = GetComponent<Collider>().bounds;
        Bounds playerBounds = other.bounds;

        bool isFullyCovering = playerBounds.min.x <= tileBounds.min.x &&
                               playerBounds.max.x >= tileBounds.max.x &&
                               playerBounds.min.z <= tileBounds.min.z &&
                               playerBounds.max.z >= tileBounds.max.z;

       
        return isFullyCovering;
    }
}
