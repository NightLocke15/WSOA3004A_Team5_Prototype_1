using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private Movement _movement;

    private float range = 2;

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
    }

    void Update()
    {
        Vector3 down = Vector3.down;
        Vector3 up = Vector3.up;
        Vector3 left = Vector3.left;
        Vector3 right = Vector3.right;
        Vector3 left1 = new Vector3(0, 0, -1);
        Vector3 right1 = new Vector3(0, 0, 1);
        Ray colRay1 = new Ray(transform.position, transform.TransformDirection(down * range));
        Ray colRay2 = new Ray(transform.position, transform.TransformDirection(up * range));
        Ray colRay3 = new Ray(transform.position, transform.TransformDirection(left * range));
        Ray colRay4 = new Ray(transform.position, transform.TransformDirection(right * range));
        Ray colRay5 = new Ray(transform.position, transform.TransformDirection(left1 * range));
        Ray colRay6 = new Ray(transform.position, transform.TransformDirection(right1 * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(down * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(up * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(left * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(right * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(left1 * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(right1 * range));

        if (Physics.Raycast(colRay1, out RaycastHit hit1, range))
        {
            _movement.touchingFloor = true;
        }
        else if (Physics.Raycast(colRay2, out RaycastHit hit2, range))
        {
            _movement.touchingFloor = true;
        }
        else if (Physics.Raycast(colRay3, out RaycastHit hit3, range))
        {
            _movement.touchingFloor = true;
        }
        else if (Physics.Raycast(colRay4, out RaycastHit hit4, range))
        {
            _movement.touchingFloor = true;
        }
        else if (Physics.Raycast(colRay5, out RaycastHit hit5, range))
        {
            _movement.touchingFloor = true;
        }
        else if (Physics.Raycast(colRay6, out RaycastHit hit6, range))
        {
            _movement.touchingFloor = true;
        }
        else
        {
            _movement.touchingFloor = false;
        }
    }
}
