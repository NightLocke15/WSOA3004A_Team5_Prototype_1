using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    [SerializeField] private bool falling;
    [SerializeField] private GameObject playerCube;
    private bool timer;
    public float seconds = 0;
    private bool moveDown = false;
    Movement _movement;

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
    }

    private void Update()
    {
        if (falling == true && _movement._moving == false)
        {
            Debug.Log("Falling");
            if (_movement.left == true)
            {
                playerCube.transform.Rotate(0, 0, 2f, Space.World);
                playerCube.transform.position = playerCube.transform.position + new Vector3(-2.5f, -2.5f, 0) * Time.deltaTime * 2f;
            }
            else if (_movement.right == true)
            {
                playerCube.transform.Rotate(0, 0, -2f, Space.World);
                playerCube.transform.position = playerCube.transform.position + new Vector3(2.5f, -2.5f, 0) * Time.deltaTime * 2f;
            }
            else if (_movement.front == true)
            {
                playerCube.transform.Rotate(2f, 0, 0, Space.World);
                playerCube.transform.position = playerCube.transform.position + new Vector3(0, -2.5f, 2.5f) * Time.deltaTime * 2f;
            }
            else if (_movement.back == true)
            {
                playerCube.transform.Rotate(-2f, 0, 0, Space.World);
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
            playerCube.transform.position = new Vector3(0, 8, 0);
            playerCube.transform.rotation = Quaternion.Euler(0, 0, 0);
            falling = false;
            _movement.upright = true;
            _movement.strings.Add("upright");
            moveDown = true;
        }

        if (moveDown == true)
        {
            playerCube.transform.position = playerCube.transform.position + new Vector3(0, -1, 0) * Time.deltaTime * 5;
        }

        if (playerCube.transform.position.y < 1 && moveDown == true)
        {
            moveDown = false;
            playerCube.transform.position = new Vector3(0, 1, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            falling = true;
        }
    }
}
