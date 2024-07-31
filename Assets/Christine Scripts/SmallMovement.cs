using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMovement : MonoBehaviour
{
    public bool _moving;
    [SerializeField] private float speed = 3;
private AudioSource audioSource; // Reference to the AudioSource component
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_moving)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Directions(Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Directions(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Directions(Vector3.back);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Directions(Vector3.right);
        }

        void Directions(Vector3 direction)
        {
            var anchor = transform.position + (Vector3.down + direction) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, direction);

            StartCoroutine(Rolling(anchor, axis));
        }
    }

   IEnumerator Rolling(Vector3 anchor, Vector3 axis)
    {
        _moving = true;
        
        // Play the movement sound
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        for (int i = 0; i < (90 / speed); i++)
        {
            transform.RotateAround(anchor, axis, speed);
            yield return new WaitForSeconds(0.01f);
        }

        _moving = false;
    }


}
