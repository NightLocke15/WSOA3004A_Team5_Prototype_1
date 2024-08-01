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
    public float initialDelay = 0.6f;
    public Vector3 hidePos = new Vector3(0, -10, 0);
    public List<GameObject> tiles = new List<GameObject>();

    public void LoadLevel(LevelData levelData)
    {

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
                GameObject tileInstance = Instantiate(tilePrefab, new Vector3(tile.position.x, 0, tile.position.y) + hidePos, Quaternion.identity, transform);
                tileInstance.name = $"tile{count}";
                StartCoroutine(startDelay(tileInstance, new Vector3(tile.position.x, 0, tile.position.y), maxDelay));
            }

            count++;
        }
    }

    private IEnumerator startDelay(GameObject tile, Vector3 targetPosition, float maxDelay)
    {
        yield return new WaitForSeconds(initialDelay); //so that fly out and fly in don't overlap 
        StartCoroutine(flyInAni(tile, targetPosition, maxDelay));
    }

    private IEnumerator flyInAni(GameObject tile, Vector3 targetPosition, float maxDelay)
    {
        float delay = Random.Range(0f, maxDelay);
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0f;
        Vector3 startPosition = tile.transform.position;

        while (elapsedTime < animDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animDuration;
            tile.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        // to end in the right place 
        tile.transform.position = targetPosition;
        tiles.Add(tile);
    }

    public void FlyOutLevel()
    {
        foreach (Transform child in transform)
        {
            StartCoroutine(flyOutAni(child.gameObject));
        }
        
    }

    private IEnumerator flyOutAni(GameObject tile)
    {
        float delay = Random.Range(0f, maxDelay);
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0f;
        Vector3 startPosition = tile.transform.position;
        Vector3 targetPosition = startPosition + hidePos;

        while (elapsedTime < animDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animDuration;
            tile.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
        tile.transform.position = targetPosition;

        //Destroy(tile);
    }
}
