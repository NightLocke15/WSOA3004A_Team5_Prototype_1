using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Movement : MonoBehaviour
{
    #region Booleans
    public bool upright = true; //Tells if block is standing up of laying sideways
    public bool left = false; //True if the last direction block went into is this direction
    public bool right = false; // " "
    public bool front = true; // " "
    public bool back = false; // " "
    public bool touchingFloor; //Tells if Raycast is touching the floor or not
    public bool _moving; //Telle is block is moving or not
    #endregion

    #region Misc
    [SerializeField] private float speed = 3; //Speed of the block rolling
    private float currentY; //What the block Y position is in the world. Helps determine if block is upright or not
    public List<string> strings = new List<string>(); //List that contains string that tells what the previous state was, upright or not
    private string state;
    public GameObject cube;
     private AudioSource audioSource; // Reference to the AudioSource component
     // Add a reference to the UI Text component
   // Add a reference to the TMP Text component
    public TMP_Text moveCounterText;

    // Add a variable to keep track of the number of moves
    private int moveCounter = 0;
    #endregion

private void Start()
    {
        audioSource = GetComponent<AudioSource>();
         UpdateMoveCounterUI(); // Initialize the UI with the starting number of moves
    }

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
        // Play the movement sound
        audioSource.Play();

        for (int i = 0; i < (90 / speed); i++)
        {
            transform.RotateAround(anchor, axis, speed);
            yield return new WaitForSeconds(0.01f);
        }

        _moving = false;
     // Increase the move counter and update the UI
        moveCounter++;
        UpdateMoveCounterUI();
    }

    private void UpdateMoveCounterUI()
    {
        if (moveCounterText != null)
        {
            moveCounterText.text = "Moves: " + moveCounter;
        }
    }
}