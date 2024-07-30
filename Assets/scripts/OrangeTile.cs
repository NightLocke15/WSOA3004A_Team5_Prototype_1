using UnityEngine;

public class OrangeTile : MonoBehaviour
{
    public GameObject orangeTile;
    Movement _movement;
    ScriptHandler _scripthandler;
    [SerializeField] private bool moveDown = false;
    [SerializeField] private GameObject playerCube;

    private void Start()
    {
        _movement = GameObject.Find("Player Holder").GetComponent<Movement>();
        orangeTile.SetActive(true);
        playerCube = GameObject.Find("Player Holder");
        _scripthandler = GameObject.Find("Script Handler Variant").GetComponent<ScriptHandler>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _movement.upright == true)
        {
            _scripthandler.fall = true;
            _scripthandler.timer = true;
            orangeTile.SetActive(false);
            Debug.Log("OrangeTile");
            Debug.Log(gameObject.name);

        }
        else
        {

        }

        
        //Debug.Log("Something entered the tile: " + other.name);
    }
}
    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("Something staying on the tile: " + other.name);
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("Player is on the orange tile.");
    //        if (IsStandingVertically(other))
    //        {
    //            Debug.Log("Player is standing vertically on the orange tile.");
    //            BreakTile();
    //        }
    //        else
    //        {
    //            Debug.Log("Player is not standing vertically on the orange tile.");
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("Something exited the tile: " + other.name);
    //}

    //private bool IsStandingVertically(Collider other)
    //{
     //   Bounds playerBounds = other.bounds;

        // Check if the player block is standing vertically (tallest dimension is along the y-axis)
      //  bool isStandingVertically = playerBounds.size.y > playerBounds.size.x && playerBounds.size.y > playerBounds.size.z;

      //  return isStandingVertically;
    //}

   // private void BreakTile()
   // {
    //    Debug.Log("Orange Tile Broken!");
    //    gameObject.SetActive(false); // Disable the tile to simulate breaking
    //    Destroy(gameObject); // Destroy the tile to remove it from the hierarchy
    //}
//}
