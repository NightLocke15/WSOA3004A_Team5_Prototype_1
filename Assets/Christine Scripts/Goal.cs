using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class Goal : MonoBehaviour
{
    public TileManager tileManager;
    public LevelManager levelManager;
    public LevelData[] levels;
    public LevelData _levelData;

    public int currentLevelIndex = 0;

    public Movement _movement;

    private bool timer;
    private float seconds;

    private bool moveDown = false;

    [SerializeField] private GameObject playerCube;
    SoftSwitch softSwitch;
    HardSwitch hardSwitch;
    ScriptHandler _scriptHandler;

    public AudioClip goalSound; // Add a field for the goal sound
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        tileManager = GameObject.Find("Manager").GetComponent<TileManager>();
        levelManager = GameObject.Find("Manager").GetComponent<LevelManager>();
        _scriptHandler = GameObject.Find("Script Handler Variant").GetComponent<ScriptHandler>();
        playerCube = GameObject.Find("Player Holder");

        // Add an AudioSource component if it doesn't exist
        if (gameObject.GetComponent<AudioSource>() == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        if (goalSound == null)
        {
            Debug.LogError("Goal sound clip is not assigned.");
        }
    }

    private void Update()
    {
        _levelData = levelManager.levels[levelManager.currentLevelIndex];

        for (int i = 0; i < _levelData.tiles.Length; i++)
        {
            if (_levelData.tiles[i].tileType == TileType.Soft)
            {
                softSwitch = GameObject.Find("tile" + i).GetComponent<SoftSwitch>();
            }
        }

        for (int i = 0; i < _levelData.tiles.Length; i++)
        {
            if (_levelData.tiles[i].tileType == TileType.Hard)
            {
                hardSwitch = GameObject.Find("tile" + i).GetComponent<HardSwitch>();
            }
        }

        if (timer == true)
        {
            seconds += Time.deltaTime;
        }

        if (seconds > 0.5)
        {
            levelManager.level();
            timer = false;
            moveDown = false;
            seconds = 0;
        }

        if (moveDown == true)
        {
            playerCube.transform.position = playerCube.transform.position + new Vector3(0, -1, 0) * Time.deltaTime * 5;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _movement.upright == true)
        {
            if (audioSource != null && goalSound != null)
            {
                audioSource.clip = goalSound;
                audioSource.Play();
            }

            timer = true;
            moveDown = true;
            for (int j = 0; j < _levelData.tiles.Length; j++)
            {
                if (_levelData.tiles[j].tileType.Equals(TileType.Soft))
                {
                    softSwitch.switches.Clear();
                }
            }

            for (int j = 0; j < _levelData.tiles.Length; j++)
            {
                if (_levelData.tiles[j].tileType.Equals(TileType.Hard))
                {
                    hardSwitch.switches.Clear();
                }
            }

            
        }
    }
}
