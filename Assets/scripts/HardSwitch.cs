using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSwitch : MonoBehaviour
{
    //public ActivatableObject activatableObject;
    //private bool playerExited = false; // Track if the player has exited the tile
    Movement _movement;
    public GameObject platformHard;
    private int activate = 0;
    public ParticleSystem hardParticle;
    public List<GameObject> switches = new List<GameObject>();

    public LevelData _levelData;
    public LevelManager _levelManager;

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        _levelManager = GameObject.Find("Manager").GetComponent<LevelManager>();
    }

    private void Update()
    {
        _levelData = _levelManager.levels[_levelManager.currentLevelIndex];

        for (int i = 0; i < _levelData.tiles.Length; i++)
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _movement.upright == true)
        {
            activate++;
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
