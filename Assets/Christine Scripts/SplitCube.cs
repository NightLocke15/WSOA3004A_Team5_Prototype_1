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


    private void Start()
    {
        _levelManager = GameObject.Find("Manager").GetComponent<LevelManager>();
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        _scriptHandler = GameObject.Find("Script Handler").GetComponent<ScriptHandler>();
        playerCube = GameObject.Find("Player Holder");
        cubeOne = GameObject.Find("Half One");
        cubeTwo = GameObject.Find("Half Two");

        movementCube1 = GameObject.Find("Half One").GetComponent<SmallMovement>();
        movementCube2 = GameObject.Find("Half Two").GetComponent<SmallMovement>();

        movementCube1.enabled = false;
        movementCube2.enabled = false;
    }

    private void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");

            if (movementCube1.enabled == true)
            {
                movementCube1.enabled = false;
                movementCube2.enabled = true;
            }
            else if (movementCube2.enabled == true)
            {
                movementCube2.enabled = false;
                movementCube1.enabled = true;
            }
            else
            {

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _movement.upright == true)
        {
            Debug.Log("Yes");
            playerCube.SetActive(false);
            cubeOne.SetActive(true);
            cubeTwo.SetActive(true);

            float x = Mathf.Round(playerCube.transform.position.x * 2f) / 2f;
            float z = Mathf.Round(playerCube.transform.position.z * 2f) / 2f;


            cubeOne.transform.position = new Vector3(x, 0.6f, z);

            _scriptHandler.movementCube1.enabled = true;
            splitParticle.Play();
        }
    }
}
