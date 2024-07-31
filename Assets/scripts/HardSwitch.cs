using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSwitch : MonoBehaviour
{
    //public ActivatableObject activatableObject;
    //private bool playerExited = false; // Track if the player has exited the tile
    Movement _movement;
    public GameObject platformHard;
    public int activate = 0;
    public ParticleSystem hardParticle;
    public List<GameObject> switches = new List<GameObject>();

    public LevelData _levelData;
    public LevelManager _levelManager;
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        _levelManager = GameObject.Find("Manager").GetComponent<LevelManager>();

         audioSource = GetComponent<AudioSource>(); // Initialize the AudioSource
    }

    private void Update()
    {
        _levelData = _levelManager.levels[_levelManager.currentLevelIndex];

        for (int i = 0; i < _levelData.tiles.Length; i++)
        {
            if (_levelManager.currentLevelIndex == 3)
            {
                if (_levelData.tiles[i].tileType == TileType.hardTile && switches.Count < 2)
                {
                    GameObject tile = GameObject.Find("tile" + i);
                    switches.Add(tile);

                    for (int j = 0; j < switches.Count; j++)
                    {
                        switches[j].SetActive(false);
                    }
                }
            }    
            else if (_levelManager.currentLevelIndex == 4)
            {
                if (_levelData.tiles[i].tileType == TileType.hardTile && switches.Count < 4)
                {
                    GameObject tile = GameObject.Find("tile" + i);
                    switches.Add(tile);

                    for (int j = 0; j < switches.Count; j++)
                    {
                        switches[j].SetActive(false);
                    }
                }
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _movement.upright == true)
        {
            activate++;
            PlayActivationSound(); // Play activation sound
            hardParticle.Play();

            if (activate % 2 == 1)
            {
                for (int j = 0; j < switches.Count; j++)
                {
                    switches[j].SetActive(true);
                }
                platformHard.SetActive(false);
            }
            else if (activate % 2 == 0)
            {
                for (int j = 0; j < switches.Count; j++)
                {
                    switches[j].SetActive(false);
                }
                platformHard.SetActive(true);
            }
        }
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

   /* void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("On X Tile: Checking if fully covering and standing vertically");
            if (IsFullyCoveringAndStanding(other))
            {
                Debug.Log("Player fully covers the X Tile and is standing vertically");
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

    bool IsFullyCoveringAndStanding(Collider other)
    {
        Bounds tileBounds = GetComponent<Collider>().bounds;
        Bounds playerBounds = other.bounds;

        bool isFullyCovering = playerBounds.min.x <= tileBounds.min.x &&
                               playerBounds.max.x >= tileBounds.max.x &&
                               playerBounds.min.z <= tileBounds.min.z &&
                               playerBounds.max.z >= tileBounds.max.z;

        bool isStandingVertically = playerBounds.size.y > playerBounds.size.x && playerBounds.size.y > playerBounds.size.z;

        Debug.Log($"Tile Bounds: {tileBounds}, Player Bounds: {playerBounds}, Is Fully Covering: {isFullyCovering}, Is Standing Vertically: {isStandingVertically}");
        return isFullyCovering && isStandingVertically;
    }*/
}
