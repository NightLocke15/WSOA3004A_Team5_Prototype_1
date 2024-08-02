using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHandler : MonoBehaviour
{
    public SmallMovement movementCube1;
    public SmallMovement movementCube2;
    Movement _movement;
    public bool fall = false;
    public bool moveDown = false;
    public bool timer;
    private float seconds = 0;
    [SerializeField] private GameObject playerCube;
    LevelManager _levelManager;
    public LevelData _levelData;
    public List<GameObject> hard = new List<GameObject>();
    public List<GameObject> soft = new List<GameObject>();
    public GameObject cubeOne;
    public GameObject cubeTwo;

    public bool split;

    public GameObject empty1L2;
    public GameObject empty2L2;
    public GameObject empty3L2;
    public GameObject empty4L2;

    public GameObject empty1L5;
    public GameObject empty2L5;
    public GameObject empty3L5;
    public GameObject empty4L5;
    public GameObject empty5L5;
    public GameObject empty6L5;

    SoftSwitch softSwitch;
    HardSwitch hardSwitch;

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        playerCube = GameObject.Find("Player Holder");
        _levelManager = GameObject.Find("Manager").GetComponent<LevelManager>();

        movementCube1 = GameObject.Find("Half One").GetComponent<SmallMovement>();
        movementCube2 = GameObject.Find("Half Two").GetComponent<SmallMovement>();

        cubeOne = GameObject.Find("Half One");
        cubeTwo = GameObject.Find("Half Two");

        movementCube1.enabled = false;
        movementCube2.enabled = false;

        empty1L2.SetActive(false);
        empty2L2.SetActive(false);
        empty3L2.SetActive(false);
        empty4L2.SetActive(false);

        empty1L5.SetActive(false);
        empty2L5.SetActive(false);
        empty3L5.SetActive(false);
        empty4L5.SetActive(false);
        empty5L5.SetActive(false);
        empty6L5.SetActive(false);
    }

    private void Update()
    {

        _levelData = _levelManager.levels[_levelManager.currentLevelIndex];

        for (int i = 0; i < _levelData.tiles.Length; i++)
        {
            if (_levelData.tiles[i].tileType.Equals(TileType.Soft))
            {
                if (_levelData.tiles[i].tileType == TileType.Soft)
                {
                    softSwitch = GameObject.Find("tile" + i).GetComponent<SoftSwitch>();
                }
                else
                {

                }
            }
            else { }
        }

        for (int i = 0; i < _levelData.tiles.Length; i++)
        {
            if (_levelData.tiles[i].tileType.Equals(TileType.Hard))
            {
                if (_levelData.tiles[i].tileType == TileType.Hard)
                {
                    hardSwitch = GameObject.Find("tile" + i).GetComponent<HardSwitch>();
                }
                else
                {

                }
            }
            else { }
        }

        if (fall == true)
        {
            _movement.enabled = false;
            playerCube.transform.position = playerCube.transform.position + new Vector3(0, -1, 0) * Time.deltaTime * 15;
        }

        if (timer == true)
        {
            seconds += Time.deltaTime;
        }

        if (seconds > 0.5)
        {
            timer = false;
            seconds = 0;
            fall = false;
            playerCube.transform.position = new Vector3(_movement.startTile.x, 10.1f, _movement.startTile.y);
            playerCube.transform.rotation = Quaternion.Euler(0, 0, 0);
            moveDown = true;
        }

        if (moveDown == true)
        {
            playerCube.transform.position = playerCube.transform.position + new Vector3(0, -1, 0) * Time.deltaTime * 15;
        }

        if (playerCube.transform.position.y < 1 && moveDown == true)
        {
            moveDown = false;
            playerCube.transform.position = new Vector3(_movement.startTile.x, 1.1f, _movement.startTile.y);
            _levelManager.LoadCurrentLevel();
            _movement.enabled = true;
        }

        

        if (_levelManager.currentLevelIndex == 1)
        {

            for (int j = 0; j < _levelData.tiles.Length; j++)
            {
                if (_levelData.tiles[j].tileType.Equals(TileType.Soft))
                {
                    for (int i = 0; i < softSwitch.switches.Count; i++)
                    {
                        if (softSwitch.switches[i].activeInHierarchy == true)
                        {
                            empty1L2.SetActive(false);
                            empty2L2.SetActive(false);
                        }
                        else if (softSwitch.switches[i].activeInHierarchy == false)
                        {
                            empty1L2.SetActive(true);
                            empty2L2.SetActive(true);
                        }
                    }
                }
            }

            for (int j = 0; j < _levelData.tiles.Length; j++)
            {
                if (_levelData.tiles[j].tileType.Equals(TileType.Hard))
                {
                    for (int i = 0; i < hardSwitch.switches.Count; i++)
                    {
                        if (hardSwitch.switches[i].activeInHierarchy == true)
                        {
                            empty3L2.SetActive(false);
                            empty4L2.SetActive(false);
                        }
                        else if (hardSwitch.switches[i].activeInHierarchy == false)
                        {
                            empty3L2.SetActive(true);
                            empty4L2.SetActive(true);
                        }
                    }
                }
            }
                    
        }
        else if (_levelManager.currentLevelIndex == 4)
        {
            for (int j = 0; j < _levelData.tiles.Length; j++)
            {
                if (_levelData.tiles[j].tileType.Equals(TileType.Soft))
                {
                    for (int i = 0; i < softSwitch.switches.Count; i++)
                    {
                        if (softSwitch.switches[i].activeInHierarchy == true)
                        {
                            empty1L5.SetActive(false);
                            empty2L5.SetActive(false);
                        }
                        else if (softSwitch.switches[i].activeInHierarchy == false)
                        {
                            empty1L5.SetActive(true);
                            empty2L5.SetActive(true);
                        }
                    }
                }
            }

            for (int j = 0; j < _levelData.tiles.Length; j++)
            {
                if (_levelData.tiles[j].tileType.Equals(TileType.Hard))
                {
                    for (int i = 0; i < hardSwitch.switches.Count; i++)
                    {
                        if (hardSwitch.switches[i].activeInHierarchy == true)
                        {
                            empty3L5.SetActive(false);
                            empty4L5.SetActive(false);
                            empty5L5.SetActive(false);
                            empty6L5.SetActive(false);
                        }
                        else if (hardSwitch.switches[i].activeInHierarchy == false)
                        {
                            empty3L5.SetActive(true);
                            empty4L5.SetActive(true);
                            empty5L5.SetActive(true);
                            empty6L5.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
