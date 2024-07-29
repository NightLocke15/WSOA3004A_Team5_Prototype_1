using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject solidTilePrefab;
    public GameObject emptyTilePrefab;
    public GameObject redTilePrefab;
    public GameObject greenTilePrefab;

    public float animDuration = 1.0f;
    public float maxDelay = 0.5f;


    public void LoadLevel(LevelData levelData)
    {
        ClearLevel();

        int count = 0;
        foreach (var tile in levelData.tiles)
        {
            GameObject tilePrefab = null;
            switch (tile.tileType)
            {
                case TileType.Solid:
                    tilePrefab = solidTilePrefab;
                    break;
                case TileType.Empty:
                    tilePrefab = emptyTilePrefab;
                    break;
                case TileType.Soft:
                    tilePrefab = redTilePrefab;
                    break;
                case TileType.Hard:
                    tilePrefab = redTilePrefab;
                    break;
                case TileType.Orange:
                    tilePrefab = redTilePrefab;
                    break;
                case TileType.Split1:
                    tilePrefab = greenTilePrefab;
                    break;
                case TileType.Split2:
                    tilePrefab = greenTilePrefab;
                    break;
                case TileType.Start:
                    tilePrefab = greenTilePrefab;
                    break;
                case TileType.Goal:
                    tilePrefab = greenTilePrefab;
                    break;
                case TileType.softTile:
                    tilePrefab = redTilePrefab;
                    break;
                case TileType.hardTile:
                    tilePrefab = redTilePrefab;
                    break;
                case TileType.Split:
                    tilePrefab = redTilePrefab;
                    break;
            }

            if (tilePrefab != null)
            {
                GameObject tileInstance = Instantiate(tilePrefab, new Vector3(tile.position.x, 0, tile.position.y), Quaternion.identity, transform);
                //StartCoroutine(StartTileAnimationWithDelay(tileInstance, maxDelay));
                tileInstance.name = $"tile{count}";
            }

            count++; 
        }

    }

    //private IEnumerator StartTileAnimationWithDelay(GameObject tile, float maxDelay)
    //{
    //    float delay = Random.Range(0f, maxDelay);
    //    yield return new WaitForSeconds(delay);

    //    Animator animator = tile.GetComponent<Animator>();
    //    if (animator != null)
    //    {
    //        animator.SetTrigger("Float"); 
    //    }
    //}

    public void ClearLevel()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
