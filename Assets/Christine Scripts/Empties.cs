using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empties : MonoBehaviour
{
    [SerializeField] private bool falling;
    [SerializeField] private GameObject playerCube;
    [SerializeField] private GameObject HalfCube1;
    [SerializeField] private GameObject HalfCube2;
    ScriptHandler _scriptHandler;
    private bool timer;
    public float seconds = 0;
    private bool moveDown = false;
    Movement _movement;
    SoftSwitch softSwitch;
    HardSwitch hardSwitch;
    public LevelData _levelData;
    public LevelManager _levelManager;
    SplitCube _splitCube;
    private bool fallCube1;
    private bool fallCube2;
    private bool timer2;
    private float seconds2 = 0;

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        playerCube = GameObject.Find("Player Holder");
        _levelManager = GameObject.Find("Manager").GetComponent<LevelManager>();
        HalfCube1 = GameObject.Find("Half One");
        HalfCube1 = GameObject.Find("Half Two");
        _scriptHandler = GameObject.Find("Script Handler Variant").GetComponent<ScriptHandler>();

    }

    private void Update()
    {
        _levelData = _levelManager.levels[_levelManager.currentLevelIndex];

        for (int i = 0; i < _levelData.tiles.Length; i++)
        {
            if (_levelData.tiles[i].tileType.Equals(TileType.Split))
            {
                if (_levelData.tiles[i].tileType == TileType.Split)
                {
                    _splitCube = GameObject.Find("tile" + i).GetComponent<SplitCube>();
                }
                else
                {

                }
            }
            else { }
        }

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

        if (falling == true && _movement._moving == false)
        {
            if (_movement.strings[_movement.strings.Count - 1] == "upright")
            {
                if (_movement.left == true)
                {
                    playerCube.transform.Rotate(0, 0, 5f, Space.World);
                    playerCube.transform.position = playerCube.transform.position + new Vector3(-1, -2.5f, 0) * Time.deltaTime * 5f;
                }
                else if (_movement.right == true)
                {
                    playerCube.transform.Rotate(0, 0, -5f, Space.World);
                    playerCube.transform.position = playerCube.transform.position + new Vector3(1, -2.5f, 0) * Time.deltaTime * 5f;
                }
                else if (_movement.front == true)
                {
                    playerCube.transform.Rotate(5f, 0, 0, Space.World);
                    playerCube.transform.position = playerCube.transform.position + new Vector3(0, -2.5f, 1) * Time.deltaTime * 5f;
                }
                else if (_movement.back == true)
                {
                    playerCube.transform.Rotate(-5f, 0, 0, Space.World);
                    playerCube.transform.position = playerCube.transform.position + new Vector3(0, -2.5f, -1) * Time.deltaTime * 5f;
                }
            }
            else if (_movement.strings[_movement.strings.Count - 1] == "not upright")
            {
                if (_movement.left == true)
                {
                    if (_movement.strings[_movement.strings.Count - 1] != _movement.strings[_movement.strings.Count - 2])
                    {
                        playerCube.transform.Rotate(0, 0, 5f, Space.World);
                        playerCube.transform.position = playerCube.transform.position + new Vector3(-1, -2.5f, 0) * Time.deltaTime * 5f;
                    }
                    else if (_movement.strings[_movement.strings.Count - 1] == _movement.strings[_movement.strings.Count - 2])
                    {
                        playerCube.transform.Rotate(0, 0, 1f, Space.World);
                        playerCube.transform.position = playerCube.transform.position + new Vector3(-0.5f, -1f, 0) * Time.deltaTime * 5f;
                    }
                }
                else if (_movement.right == true)
                {
                    if (_movement.strings[_movement.strings.Count - 1] != _movement.strings[_movement.strings.Count - 2])
                    {
                        playerCube.transform.Rotate(0, 0, -5f, Space.World);
                        playerCube.transform.position = playerCube.transform.position + new Vector3(1, -2.5f, 0) * Time.deltaTime * 5f;
                    }
                    else if (_movement.strings[_movement.strings.Count - 1] == _movement.strings[_movement.strings.Count - 2])
                    {
                        playerCube.transform.Rotate(0, 0, -1f, Space.World);
                        playerCube.transform.position = playerCube.transform.position + new Vector3(0.5f, -1f, 0) * Time.deltaTime * 5f;
                    }

                }
                else if (_movement.front == true)
                {
                    if (_movement.strings[_movement.strings.Count - 1] != _movement.strings[_movement.strings.Count - 2])
                    {
                        playerCube.transform.Rotate(5f, 0, 0, Space.World);
                        playerCube.transform.position = playerCube.transform.position + new Vector3(0, -2.5f, 1) * Time.deltaTime * 5f;
                    }
                    else if (_movement.strings[_movement.strings.Count - 1] == _movement.strings[_movement.strings.Count - 2])
                    {
                        playerCube.transform.Rotate(1, 0, 0f, Space.World);
                        playerCube.transform.position = playerCube.transform.position + new Vector3(0, -1f, 0.5f) * Time.deltaTime * 5f;
                    }

                }
                else if (_movement.back == true)
                {
                    if (_movement.strings[_movement.strings.Count - 1] != _movement.strings[_movement.strings.Count - 2])
                    {
                        playerCube.transform.Rotate(-5f, 0, 0, Space.World);
                        playerCube.transform.position = playerCube.transform.position + new Vector3(0, -2.5f, -1) * Time.deltaTime * 5f;
                    }
                    else if (_movement.strings[_movement.strings.Count - 1] == _movement.strings[_movement.strings.Count - 2])
                    {
                        playerCube.transform.Rotate(-1, 0, 0f, Space.World);
                        playerCube.transform.position = playerCube.transform.position + new Vector3(0, -1f, -0.5f) * Time.deltaTime * 5f;
                    }

                }
            }

            Debug.Log("Falling");

            timer = true;
        }
        else
        {

        }

        if (timer == true)
        {
            seconds += Time.deltaTime;
        }

        if (seconds > 1)
        {
            timer = false;
            seconds = 0;
            playerCube.transform.position = new Vector3(_movement.startTile.x, 10.1f, _movement.startTile.y);
            playerCube.transform.rotation = Quaternion.Euler(0, 0, 0);
            falling = false;
            _movement.upright = true;
            _movement.strings.Add("upright");
            moveDown = true;
        }

        if (moveDown == true)
        {
            playerCube.transform.position = playerCube.transform.position + new Vector3(0, -1, 0) * Time.deltaTime * 20;
        }

        if (playerCube.transform.position.y < 1 && moveDown == true)
        {
            moveDown = false;
            playerCube.transform.position = new Vector3(_movement.startTile.x, 1.1f, _movement.startTile.y);
            _movement.enabled = true;
        }

        if (fallCube1 == true)
        {
            _scriptHandler.cubeOne.transform.position = _scriptHandler.cubeOne.transform.position + new Vector3(0, -1f, 0) * Time.deltaTime * 5f;
            timer2 = true;
        }

        if (fallCube2 == true)
        {
            _scriptHandler.cubeTwo.transform.position = _scriptHandler.cubeTwo.transform.position + new Vector3(0, -1f, 0) * Time.deltaTime * 5f;
            timer2 = true;
        }

        if (timer2 == true)
        {
            seconds2 += Time.deltaTime;
        }

        if (seconds2 > 1f)
        {
            timer2 = false;
            seconds2 = 0;
            _scriptHandler.cubeOne.SetActive(false);
            _scriptHandler.cubeTwo.SetActive(false);
            fallCube1 = false;
            fallCube2 = false;
            moveDown = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _movement.strings.Clear();
            _movement.strings.Add("upright");
            _movement.enabled = false;

            if (_scriptHandler.split == true)
            {
                _scriptHandler.split = false;
            }

            Debug.Log("Empty");
            falling = true;

            for (int j = 0; j < _levelData.tiles.Length; j++)
            {
                if (_levelData.tiles[j].tileType.Equals(TileType.Soft))
                {
                    if (softSwitch.switches.Count > 0)
                    {
                        for (int i = 0; i < softSwitch.switches.Count; i++)
                        {
                            softSwitch.switches[i].SetActive(false);
                            softSwitch.activate = 0;
                        }
                    }
                    else
                    {

                    }
                }
                else { }
            }

            for (int j = 0; j < _levelData.tiles.Length; j++)
            {
                if (_levelData.tiles[j].tileType.Equals(TileType.Hard))
                {
                    if (hardSwitch.switches.Count > 0)
                    {
                        for (int i = 0; i < hardSwitch.switches.Count; i++)
                        {
                            hardSwitch.switches[i].SetActive(false);
                            hardSwitch.activate = 0;
                        }
                    }
                    else
                    {

                    }
                }
                else { }
            }
        }
        else if (other.gameObject.tag == "HalfCube1" || other.gameObject.tag == "HalfCube2")
        {
            _movement.strings.Clear();
            _movement.strings.Add("upright");
            _movement.enabled = false;

            if (_scriptHandler.split == true)
            {
                _scriptHandler.split = false;
            }

            if (other.gameObject.tag == "HalfCube1")
            {
                fallCube1 = true;
            }

            if (other.gameObject.tag == "HalfCube2")
            {
                fallCube2 = true;
            }

            _splitCube.playerCube.transform.position = new Vector3(_movement.startTile.x, 10.1f, _movement.startTile.y);
            _splitCube.playerCube.transform.rotation = Quaternion.Euler(0, 0, 0);
            _splitCube.playerCube.SetActive(true);
            
            _movement._moving = false;

            _splitCube.movementCube1._moving = false;
            _splitCube.movementCube2._moving = false;

            for (int j = 0; j < _levelData.tiles.Length; j++)
            {
                if (_levelData.tiles[j].tileType.Equals(TileType.Soft))
                {
                    if (softSwitch.switches.Count > 0)
                    {
                        for (int i = 0; i < softSwitch.switches.Count; i++)
                        {
                            softSwitch.switches[i].SetActive(false);
                            softSwitch.activate = 0;
                        }
                    }
                    else
                    {

                    }
                }
                else { }
            }

            for (int j = 0; j < _levelData.tiles.Length; j++)
            {
                if (_levelData.tiles[j].tileType.Equals(TileType.Hard))
                {
                    if (hardSwitch.switches.Count > 0)
                    {
                        for (int i = 0; i < hardSwitch.switches.Count; i++)
                        {
                            hardSwitch.switches[i].SetActive(false);
                            hardSwitch.activate = 0;
                        }
                    }
                    else
                    {

                    }
                }
                else { }
            }
        }
    }
}
