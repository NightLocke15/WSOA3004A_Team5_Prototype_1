using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSwitch : MonoBehaviour
{
   // public ActivatableObject activatableObject;
    //private bool playerExited = false; // Track if the player has exited the tile
    Movement _movement;
    public GameObject platformSoft;
    public int activate = 0;
    public ParticleSystem softParticle;
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
            if (_levelData.tiles[i].tileType == TileType.softTile && switches.Count < 2)
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
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "HalfCube")
        {
            activate++;
            softParticle.Play();

            if (activate % 2 == 1)
            {
                for (int j = 0; j < switches.Count; j++)
                {
                    switches[j].SetActive(true);
                }
                platformSoft.SetActive(false);
            }
            else if (activate % 2 == 0)
            {
                for (int j = 0; j < switches.Count; j++)
                {
                    switches[j].SetActive(false);
                }
                platformSoft.SetActive(true);
            }
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
