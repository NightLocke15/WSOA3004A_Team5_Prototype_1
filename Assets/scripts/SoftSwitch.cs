using UnityEngine;

public class SoftSwitch : MonoBehaviour
{
   // public ActivatableObject activatableObject;
    //private bool playerExited = false; // Track if the player has exited the tile
    Movement _movement;
    public GameObject platformSoft;
    private int activate = 0;

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        platformSoft.SetActive(false);
    }

    private void Update()
    {
        if (activate % 2 == 0)
        {
            platformSoft.SetActive(false);
        }
        else if (activate % 2 == 1)
        {
            platformSoft.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "HalfCube")
        {
            activate++;
        }
    }

    /*void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("On O Tile: Checking if fully covering");
            if (IsFullyCovering(other))
            {
                Debug.Log("Player fully covers the O Tile");
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

        Debug.Log($"Tile Bounds: {tileBounds}, Player Bounds: {playerBounds}, Is Fully Covering: {isFullyCovering}");
        return isFullyCovering;
    }*/
}
