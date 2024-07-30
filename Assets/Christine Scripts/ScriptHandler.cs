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
    public List<GameObject> hard = new List<GameObject>();
    public List<GameObject> soft = new List<GameObject>();

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        playerCube = GameObject.Find("Player Holder");
        _levelManager = GameObject.Find("Manager").GetComponent<LevelManager>();

        movementCube1 = GameObject.Find("Half One").GetComponent<SmallMovement>();
        movementCube2 = GameObject.Find("Half Two").GetComponent<SmallMovement>();

        movementCube1.enabled = false;
        movementCube2.enabled = false;
    }

    private void Update()
    {
        if (fall == true)
        {
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
}
