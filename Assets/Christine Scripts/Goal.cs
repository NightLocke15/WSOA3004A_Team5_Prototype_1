using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        tileManager = GameObject.Find("Manager").GetComponent<TileManager>();
        levelManager = GameObject.Find("Manager").GetComponent<LevelManager>();
        playerCube = GameObject.Find("Player Holder");
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
            timer = true;
            moveDown = true;
            softSwitch.switches.Clear();
            hardSwitch.switches.Clear();
        }
        
    }
}
