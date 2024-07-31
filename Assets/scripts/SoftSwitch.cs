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
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "HalfCube1" || other.gameObject.tag == "HalfCube2")
        {
            activate++;
             PlayActivationSound(); // Play activation sound
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
