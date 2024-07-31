using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelManager : MonoBehaviour
{
    public TileManager tileManager;
    public LevelData[] levels;
    public Movement _movement;
    public bool levelLoad;

    public int currentLevelIndex = 0;
    public AudioClip levelStartSound; // Add a field for the level start sound
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Add an AudioSource component if it doesn't exist
        if (gameObject.GetComponent<AudioSource>() == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        if (levelStartSound == null)
        {
            Debug.LogError("Level start sound clip is not assigned.");
        }

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

        if (currentLevelIndex > 4)
        {
            SceneManager.LoadScene("EndGameScene");
        }
    }

    public void level()
    {
        LoadNextLevel();
        Debug.Log("working2");
        _movement.startLevel = true;
    }

    public void LoadCurrentLevel()
    {
        if (currentLevelIndex >= 0 && currentLevelIndex < levels.Length)
        {
            tileManager.LoadLevel(levels[currentLevelIndex]);
            levelLoad = true;
            
             // Play the level start sound
            if (audioSource != null && levelStartSound != null)
            {
                audioSource.clip = levelStartSound;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource or levelStartSound is missing.");
            }
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
