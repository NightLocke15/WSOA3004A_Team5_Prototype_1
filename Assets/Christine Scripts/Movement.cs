using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Booleans
    [SerializeField] private bool upright = true; //Tells if block is standing up of laying sideways
    [SerializeField] private bool left = false; //True if the last direction block went into is this direction
    [SerializeField] private bool right = false; // " "
    [SerializeField] private bool front = true; // " "
    [SerializeField] private bool back = false; // " "
    public bool touchingFloor; //Tells if Raycast is touching the floor or not
    private bool _moving; //Telle is block is moving or not
    #endregion

    #region Misc
    [SerializeField] private float speed = 3; //Speed of the block rolling
    private float currentY; //What the block Y position is in the world. Helps determine if block is upright or not
    [SerializeField] private List<string> strings = new List<string>(); //List that contains string that tells what the previous state was, upright or not
    #endregion

    private void Update()
    {
        currentY = transform.position.y;

        //Determine whether block is standing or not

        if (currentY > 0.8f && currentY < 1.2f)
        {
            upright = true;
        }
        else
        {
            upright = false;
        }

        if (_moving)
        {
            return;
        }

        //Movement tied to WASD

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (upright == true)
            {
                var anchor = transform.position + (Vector3.down + (Vector3.left * 0.5f));
                var axis = Vector3.Cross(Vector3.up, Vector3.left);
                strings.Add("not upright");

                StartCoroutine(Rolling(anchor, axis));
            }
            else if (upright == false)
            {

                if (left == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.left);
                        strings.Add("upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.left);
                        strings.Add("not upright");
                    }
                }
                else if (right == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.left);
                        strings.Add("upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.left);
                        strings.Add("not upright");
                    }
                }
                else if (front == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.left);
                        strings.Add("not upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.left);
                        strings.Add("upright");
                    }
                }
                else if (back == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.left);
                        strings.Add("not upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.left);
                        strings.Add("upright");
                    }
                }
            }

            left = true;
            right = false;
            front = false;
            back = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (upright == true)
            {
                var anchor = transform.position + (Vector3.down + (Vector3.right * 0.5f));
                var axis = Vector3.Cross(Vector3.up, Vector3.right);
                strings.Add("not upright");

                StartCoroutine(Rolling(anchor, axis));
            }
            else if (upright == false)
            {

                if (left == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.right);
                        strings.Add("upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.right);
                        strings.Add("not upright");
                    }
                }
                else if (right == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.right);
                        strings.Add("upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.right);
                        strings.Add("not upright");
                    }
                }
                else if (front == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.right);
                        strings.Add("not upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.right);
                        strings.Add("upright");
                    }
                }
                else if (back == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.right);
                        strings.Add("not upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.right);
                        strings.Add("upright");
                    }
                }
            }

            left = false;
            right = true;
            front = false;
            back = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (upright == true)
            {
                var anchor = transform.position + (Vector3.down + (Vector3.forward * 0.5f));
                var axis = Vector3.Cross(Vector3.up, Vector3.forward);
                strings.Add("not upright");

                StartCoroutine(Rolling(anchor, axis));
            }
            else if (upright == false)
            {
                if (left == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.forward);
                        strings.Add("not upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.forward);
                        strings.Add("upright");
                    }
                }
                else if (right == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.forward);
                        strings.Add("not upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.forward);
                        strings.Add("upright");
                    }
                }
                else if (front == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.forward);
                        strings.Add("upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.forward);
                        strings.Add("not upright");
                    }
                }
                else if (back == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.forward);
                        strings.Add("upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.forward);
                        strings.Add("not upright");
                    }
                }
            }

            left = false;
            right = false;
            front = true;
            back = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (upright == true)
            {
                var anchor = transform.position + (Vector3.down + (Vector3.back * 0.5f));
                var axis = Vector3.Cross(Vector3.up, Vector3.back);
                strings.Add("not upright");

                StartCoroutine(Rolling(anchor, axis));
            }
            else if (upright == false)
            {
                if (left == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.back);
                        strings.Add("not upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.back);
                        strings.Add("upright");
                    }
                }
                else if (right == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.back);
                        strings.Add("not upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.back);
                        strings.Add("upright");
                    }
                }
                else if (front == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.back);
                        strings.Add("upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.back);
                        strings.Add("not upright");
                    }
                }
                else if (back == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        DirectionTwo(Vector3.back);
                        strings.Add("upright");
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        DirectionOne(Vector3.back);
                        strings.Add("not upright");
                    }
                }
            }

            left = false;
            right = false;
            front = false;
            back = true;
        }     

        void DirectionOne (Vector3 direction)
        {
            var anchor = transform.position + (Vector3.down + direction) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, direction);

            StartCoroutine(Rolling(anchor, axis));
        }

        void DirectionTwo(Vector3 direction)
        {
            var anchor = transform.position + ((Vector3.down * 0.5f) + direction);
            var axis = Vector3.Cross(Vector3.up, direction);

            StartCoroutine(Rolling(anchor, axis));
        }
    }

    IEnumerator Rolling(Vector3 anchor, Vector3 axis)
    {
        _moving = true;

        for (int i = 0; i < (90 / speed); i++)
        {
            transform.RotateAround(anchor, axis, speed);
            yield return new WaitForSeconds(0.01f);
        }

        _moving = false;
    }
}
