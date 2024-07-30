using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empties : MonoBehaviour
{
    [SerializeField] private bool falling;
    [SerializeField] private GameObject playerCube;
    private bool timer;
    public float seconds = 0;
    private bool moveDown = false;
    Movement _movement;
    SoftSwitch softSwitch;
    HardSwitch hardSwitch;
    public LevelData _levelData;
    public LevelManager _levelManager;

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        playerCube = GameObject.Find("Player Holder");
        _levelManager = GameObject.Find("Manager").GetComponent<LevelManager>();

    }

    private void Update()
    {
        _levelData = _levelManager.levels[_levelManager.currentLevelIndex];

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

        if (falling == true && _movement._moving == false)
        {
            Debug.Log("Falling");
            if (_movement.left == true)
            {
                playerCube.transform.Rotate(0, 0, 1f, Space.World);
                playerCube.transform.position = playerCube.transform.position + new Vector3(-2.5f, -2.5f, 0) * Time.deltaTime * 2f;
            }
            else if (_movement.right == true)
            {
                playerCube.transform.Rotate(0, 0, -1f, Space.World);
                playerCube.transform.position = playerCube.transform.position + new Vector3(2.5f, -2.5f, 0) * Time.deltaTime * 2f;
            }
            else if (_movement.front == true)
            {
                playerCube.transform.Rotate(1f, 0, 0, Space.World);
                playerCube.transform.position = playerCube.transform.position + new Vector3(0, -2.5f, 2.5f) * Time.deltaTime * 2f;
            }
            else if (_movement.back == true)
            {
                playerCube.transform.Rotate(-1f, 0, 0, Space.World);
                playerCube.transform.position = playerCube.transform.position + new Vector3(0, -2.5f, -2.5f) * Time.deltaTime * 2f;
            }
            timer = true;
        }
        else
        {

        }

        if (timer == true)
        {
            seconds += Time.deltaTime;
        }

        if (seconds > 2)
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
            playerCube.transform.position = playerCube.transform.position + new Vector3(0, -1, 0) * Time.deltaTime * 15;
        }

        if (playerCube.transform.position.y < 1 && moveDown == true)
        {
            moveDown = false;
            playerCube.transform.position = new Vector3(_movement.startTile.x, 1.1f, _movement.startTile.y);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Empty");
            falling = true;
            for (int i = 0; i < softSwitch.switches.Count; i++)
            {
                softSwitch.switches[i].SetActive(false);
                softSwitch.activate = 0;
            }
            for (int i = 0; i < hardSwitch.switches.Count; i++)
            {
                hardSwitch.switches[i].SetActive(false);
                hardSwitch.activate = 0;
            }
        }
    }
}
