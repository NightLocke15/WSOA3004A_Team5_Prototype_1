using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelManager : MonoBehaviour
{
    public TileManager tileManager;
    public LevelData[] levels;
    public Movement _movement;

    public int currentLevelIndex = 0;

    void Start()
    {
        LoadCurrentLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            Debug.Log("working"); 
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            LoadNextLevel(); 
            Debug.Log("working2");
            _movement.startLevel = true;
        }
    }

    public void LoadCurrentLevel()
    {
        if (currentLevelIndex >= 0 && currentLevelIndex < levels.Length)
        {
            tileManager.LoadLevel(levels[currentLevelIndex]);
        }
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;
        if (currentLevelIndex < levels.Length)
        {
            LoadCurrentLevel();
        }
    }
}
