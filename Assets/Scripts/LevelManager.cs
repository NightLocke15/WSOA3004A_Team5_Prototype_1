using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TileManager tileManager;
    public LevelData[] levels;
    public Movement _movement;
    public bool levelLoad;
    ScriptHandler _scriptHandler;
    [SerializeField] private GameObject playerCube;
    public GameObject Space;
    public TextMeshProUGUI levelNum;

    public int currentLevelIndex = 0;
    public AudioClip levelStartSound; // Add a field for the level start sound
    private AudioSource audioSource; // Reference to the AudioSource component
    public TMP_Text levelText; // Reference to the TMP_Text component that displays the level number

    void Start()
    {
        _scriptHandler = GameObject.Find("Script Handler Variant").GetComponent<ScriptHandler>();
        Space.SetActive(false);

        // Retrieve the level index from PlayerPrefs
        currentLevelIndex = PlayerPrefs.GetInt("SelectedLevelIndex", 0);
    
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

        if (currentLevelIndex == 3)
        {
            Space.SetActive(true);
        }
        else
        {
            Space.SetActive(false);
        }

        levelNum.text = "Level: " + (currentLevelIndex + 1);
    }

    public void level()
    {
        LoadNextLevel();
        Debug.Log("working2");
        _movement.startLevel = true;
    }

    public void LoadCurrentLevel()
    {
        if (tileManager.tiles.Count > 0)
            {
                for (int i = 0; i < tileManager.tiles.Count; i++)
                {
                    Destroy(tileManager.tiles[i]);
                }
                tileManager.tiles.Clear();
            }

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

            _scriptHandler.empty1L2.SetActive(false);
            _scriptHandler.empty2L2.SetActive(false);
            _scriptHandler.empty3L2.SetActive(false);
            _scriptHandler.empty4L2.SetActive(false);

            _scriptHandler.empty1L5.SetActive(false);
            _scriptHandler.empty2L5.SetActive(false);
            _scriptHandler.empty3L5.SetActive(false);
            _scriptHandler.empty4L5.SetActive(false);
            _scriptHandler.empty5L5.SetActive(false);
            _scriptHandler.empty6L5.SetActive(false);

            _movement.strings.Clear();
            _movement.strings.Add("upright");
            // Update the level text
            UpdateLevelText();
        }
    }

    public void LoadNextLevel()
    {
        //tileManager.FlyOutLevel();
        currentLevelIndex++;
        if (currentLevelIndex < levels.Length)
        {
            LoadCurrentLevel();
        }
    }

    private void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + (currentLevelIndex + 1);
        }
    }
}
