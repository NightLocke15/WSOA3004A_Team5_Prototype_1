using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject solidTilePrefab;
    public GameObject emptyTilePrefab;
    public GameObject softSwitchPrefab;
    public GameObject hardSwitchPrefab;
    public GameObject orangeTilePrefab;
    public GameObject split1TilePrefab;
    public GameObject split2TilePrefab;
    public GameObject startTilePrefab;
    public GameObject goalTilePrefab;
    public GameObject softTilePrefab;
    public GameObject hardTilePrefab;
    public GameObject splitSwitchPrefab;

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
                    tilePrefab = softSwitchPrefab;
                    break;
                case TileType.Hard:
                    tilePrefab = hardSwitchPrefab;
                    break;
                case TileType.Orange:
                    tilePrefab = orangeTilePrefab;
                    break;
                case TileType.Split1:
                    tilePrefab = split1TilePrefab;
                    break;
                case TileType.Split2:
                    tilePrefab = split2TilePrefab;
                    break;
                case TileType.Start:
                    tilePrefab = startTilePrefab;
                    break;
                case TileType.Goal:
                    tilePrefab = goalTilePrefab;
                    break;
                case TileType.softTile:
                    tilePrefab = softTilePrefab;
                    break;
                case TileType.hardTile:
                    tilePrefab = hardTilePrefab;
                    break;
                case TileType.Split:
                    tilePrefab = splitSwitchPrefab;
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
