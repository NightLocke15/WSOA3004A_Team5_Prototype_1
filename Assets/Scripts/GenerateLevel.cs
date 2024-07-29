using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GenerateLevel : MonoBehaviour
{
    
    public LevelData levelData;
    public int height;
    public int width; 

    void Start()
    {
        PopulateTileData(width, height);
    }

    void PopulateTileData(int width, int height)
    {
        // instantiate grid
        levelData.tiles = new TileData[width * height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                TileData tile = new TileData
                {
                    position = new Vector2Int(x, y),
                    //tileType = TileType.Solid;
                };
                levelData.tiles[x + y * width] = tile;
            }      
        }
    }
}
