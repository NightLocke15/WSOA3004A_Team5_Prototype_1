using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCube : MonoBehaviour
{
    Movement _movement;
    ScriptHandler _scriptHandler;
    public LevelData _levelData;
    public LevelManager _levelManager;
    public GameObject cubeOne;
    public GameObject cubeTwo;
    public GameObject playerCube;
    public ParticleSystem splitParticle;
    public Vector2Int splitTile;
    

    public SmallMovement movementCube1;
    public SmallMovement movementCube2;

    public GameObject Tile1;
    public GameObject Tile2;
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        _levelManager = GameObject.Find("Manager").GetComponent<LevelManager>();
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        _scriptHandler = GameObject.Find("Script Handler Variant").GetComponent<ScriptHandler>();
        playerCube = GameObject.Find("Player Holder");
        cubeOne = GameObject.Find("Half One");
        cubeTwo = GameObject.Find("Half Two");

        movementCube1 = GameObject.Find("Half One").GetComponent<SmallMovement>();
        movementCube2 = GameObject.Find("Half Two").GetComponent<SmallMovement>();


        _scriptHandler.movementCube1.enabled = false;
        _scriptHandler.movementCube2.enabled = false;

         audioSource = GetComponent<AudioSource>(); // Initialize the AudioSource

    }

    private void Update()
    {

        if (_scriptHandler.split == true)
        {
            movementCube1 = GameObject.Find("Half One").GetComponent<SmallMovement>();
            movementCube2 = GameObject.Find("Half Two").GetComponent<SmallMovement>();
        }
        else { }

        _levelData = _levelManager.levels[_levelManager.currentLevelIndex];

        if (_movement.startLevel == true)
        {
            for (int i = 0; i < _levelData.tiles.Length; i++)
            {
                if (_levelData.tiles[i].tileType == TileType.Split)
                {
                    splitTile = _levelData.tiles[i].position;
                    transform.position = new Vector3(splitTile.x, 1.1f, splitTile.y);
                    _movement.startLevel = false;
                }
            }
        }

        

        if (_levelManager.currentLevelIndex == 3 || _levelManager.currentLevelIndex == 4)
        {
            for (int i = 0; i < _levelData.tiles.Length; i++)
            {
                if (_levelData.tiles[i].tileType == TileType.Split1)
                {
                    Tile1 = GameObject.Find("tile" + i);
                }

                if (_levelData.tiles[i].tileType == TileType.Split2)
                {
                    Tile2 = GameObject.Find("tile" + i);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _movement.upright == true)
        {
            Debug.Log("Yes");
            playerCube.SetActive(false);
            _scriptHandler.cubeOne.SetActive(true);
            _scriptHandler.cubeTwo.SetActive(true);

            _scriptHandler.split = true;

            float xT1 = Mathf.Round(Tile1.transform.position.x * 2f) / 2f;
            float zT1 = Mathf.Round(Tile1.transform.position.z * 2f) / 2f;
            float xT2 = Mathf.Round(Tile2.transform.position.x * 2f) / 2f;
            float zT2 = Mathf.Round(Tile2.transform.position.z * 2f) / 2f;

            _scriptHandler.cubeOne.transform.position = new Vector3(xT1, 0.6f, zT1);
            _scriptHandler.cubeOne.transform.rotation = Quaternion.Euler(0, 0, 0);
            _scriptHandler.cubeTwo.transform.position = new Vector3(xT2, 0.6f, zT2);
            _scriptHandler.cubeTwo.transform.rotation = Quaternion.Euler(0, 0, 0);

            _scriptHandler.movementCube1.enabled = true;
            _scriptHandler.movementCube2.enabled = false;
            // Play the split sound
            if (audioSource != null)
            {
                audioSource.Play();
            }

            movementCube1._moving = false;
            movementCube2._moving = false;

            splitParticle.Play();
        }
    }
}
