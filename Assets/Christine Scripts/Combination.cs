using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    public GameObject cubeOne;
    public GameObject cubeTwo;
    public GameObject playerCube;

    public float positionZ;
    public float positionX;


    private void Update()
    {
        positionZ = (cubeOne.transform.position.z - cubeTwo.transform.position.z) / 2;
        positionX = (cubeOne.transform.position.x - cubeTwo.transform.position.x) / 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HalfCube")
        {
            if (cubeOne.transform.position.z < (cubeTwo.transform.position.z - 0.2) || cubeOne.transform.position.z > (cubeTwo.transform.position.z + 0.2)) // forward and back
            {
                Debug.Log("front");
                cubeOne.SetActive(false);
                cubeTwo.SetActive(false);
                playerCube.SetActive(true);

                playerCube.transform.position = new Vector3(positionX, 0.5f, positionZ);
                playerCube.transform.rotation = Quaternion.Euler(90, 0, 0);

            }
            else if (cubeOne.transform.position.x < (cubeTwo.transform.position.x - 0.2) || cubeOne.transform.position.x > (cubeTwo.transform.position.x + 0.2)) // left and right
            {
                Debug.Log("back");
                cubeOne.SetActive(false);
                cubeTwo.SetActive(false);
                playerCube.SetActive(true);

                playerCube.transform.position = new Vector3(positionX, 0.5f, positionZ);
                playerCube.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
    }
}
