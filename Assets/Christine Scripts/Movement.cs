using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    private bool _moving;
    private float currentY;
    [SerializeField] private float currentZRot;
    [SerializeField] private float currentXRot;
    [SerializeField] private bool upright = true;
    [SerializeField] private bool left = false;
    [SerializeField] private bool right = false;
    [SerializeField] private bool front = true;
    [SerializeField] private bool back = false;
    public bool touchingFloor;
    [SerializeField] private KeyCode lastKey;

    [SerializeField] private List<string> strings = new List<string>();

    private void Update()
    {
        currentY = transform.position.y;
        currentZRot = transform.eulerAngles.z - 180;
        currentXRot = transform.eulerAngles.x - 180;

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
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.left);
                        var axis = Vector3.Cross(Vector3.up, Vector3.left);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.left) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.left);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
                else if (right == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.left);
                        var axis = Vector3.Cross(Vector3.up, Vector3.left);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.left) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.left);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
                else if (front == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.left) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.left);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.left);
                        var axis = Vector3.Cross(Vector3.up, Vector3.left);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
                else if (back == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.left) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.left);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.left);
                        var axis = Vector3.Cross(Vector3.up, Vector3.left);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
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
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.right);
                        var axis = Vector3.Cross(Vector3.up, Vector3.right);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.right) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.right);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
                else if (right == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.right);
                        var axis = Vector3.Cross(Vector3.up, Vector3.right);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.right) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.right);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
                else if (front == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.right) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.right);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.right);
                        var axis = Vector3.Cross(Vector3.up, Vector3.right);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
                else if (back == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.right) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.right);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.right);
                        var axis = Vector3.Cross(Vector3.up, Vector3.right);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
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
                        var anchor = transform.position + (Vector3.down + Vector3.forward) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.forward);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.forward);
                        var axis = Vector3.Cross(Vector3.up, Vector3.forward);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
                else if (right == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.forward) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.forward);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.forward);
                        var axis = Vector3.Cross(Vector3.up, Vector3.forward);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
                else if (front == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.forward);
                        var axis = Vector3.Cross(Vector3.up, Vector3.forward);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.forward) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.forward);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
                else if (back == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.forward);
                        var axis = Vector3.Cross(Vector3.up, Vector3.forward);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.forward) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.forward);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
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
                        var anchor = transform.position + (Vector3.down + Vector3.back) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.back);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.back);
                        var axis = Vector3.Cross(Vector3.up, Vector3.back);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
                else if (right == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.back) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.back);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.back);
                        var axis = Vector3.Cross(Vector3.up, Vector3.back);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
                else if (front == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.back);
                        var axis = Vector3.Cross(Vector3.up, Vector3.back);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.back) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.back);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
                else if (back == true)
                {
                    if (strings[strings.Count - 1] != strings[strings.Count - 2])
                    {
                        var anchor = transform.position + ((Vector3.down * 0.5f) + Vector3.back);
                        var axis = Vector3.Cross(Vector3.up, Vector3.back);
                        strings.Add("upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                    else if (strings[strings.Count - 1] == strings[strings.Count - 2])
                    {
                        var anchor = transform.position + (Vector3.down + Vector3.back) * 0.5f;
                        var axis = Vector3.Cross(Vector3.up, Vector3.back);
                        strings.Add("not upright");

                        StartCoroutine(Rolling(anchor, axis));
                    }
                }
            }

            left = false;
            right = false;
            front = false;
            back = true;
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
