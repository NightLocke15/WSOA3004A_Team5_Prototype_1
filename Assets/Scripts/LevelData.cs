using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "Level")]
public class LevelData : ScriptableObject
{
    //public int levelNumber;
    //public Vector2Int startPosition;
    //public Vector2Int endPosition;
    public TileData[] tiles;
}

[System.Serializable]
public class TileData
{
    public Vector2Int position;
    public TileType tileType;
}

public enum TileType
{
    Solid,
    Empty,
    Soft,
    Hard, 
    Orange, 
    Split1,
    Split2,
    Start,
    Goal, 
    softTile,
    hardTile, 
    Split,
}