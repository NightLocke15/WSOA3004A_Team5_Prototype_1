using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public Button levelsButton;
    public Button howToPlayButton; // New "How to Play" button
    public GameObject levelSelectionPanel;
    public AudioClip buttonClickSound; // The sound to play on button click
    public string gameSceneName = "MainScene"; // The name of the game scene
    public string rulesSceneName = "RulesScene"; // The name of the rules scene

    private Button[] levelButtons;
    private AudioSource audioSource;

    void Start()
    {
        // Initialize AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        if (buttonClickSound != null)
        {
            audioSource.clip = buttonClickSound;
        }

        levelSelectionPanel.SetActive(false);
        startButton.Select();

        // Add listeners to buttons
        startButton.onClick.AddListener(StartGameWithSound);
        exitButton.onClick.AddListener(ExitGameWithSound);
        levelsButton.onClick.AddListener(OpenLevelSelectionWithSound);
        howToPlayButton.onClick.AddListener(OpenRulesSceneWithSound); // Listener for "How to Play" button

        // Add debug logs
        startButton.onClick.AddListener(() => Debug.Log("Start button clicked"));
        exitButton.onClick.AddListener(() => Debug.Log("Exit button clicked"));
        levelsButton.onClick.AddListener(() => Debug.Log("Levels button clicked"));
        howToPlayButton.onClick.AddListener(() => Debug.Log("How to Play button clicked"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (levelSelectionPanel.activeSelf)
            {
                Debug.Log("Closing level selection panel");
                CloseLevelSelection();
            }
            else
            {
                Debug.Log("Exiting game");
                ExitGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            var selectedButton = EventSystem.current.currentSelectedGameObject?.GetComponent<Button>();
            if (selectedButton != null)
            {
                Debug.Log("Invoking button: " + selectedButton.name);
                selectedButton.onClick.Invoke();
            }
            else
            {
                Debug.LogWarning("No button is currently selected.");
            }
        }
    }

    public void OpenLevelSelection()
    {
        levelSelectionPanel.SetActive(true);
        levelButtons = levelSelectionPanel.GetComponentsInChildren<Button>();

        // Add debug logs and listeners for level buttons
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i;
            levelButtons[i].onClick.AddListener(() => Debug.Log("Loading level: " + levelIndex));
            levelButtons[i].onClick.AddListener(() => SetLevelIndexAndLoad(levelIndex));
            levelButtons[i].onClick.AddListener(PlayButtonClickSound); // Add sound listener
        }

        
    }

    public void CloseLevelSelection()
    {
        levelSelectionPanel.SetActive(false);
        levelsButton.Select();
    }

    private void StartGame()
    {
        // Load the game scene
        Debug.Log("Starting game");
        
        SceneManager.LoadScene(gameSceneName);
    }

    private void ExitGame()
    {
        // Exit the application
        Debug.Log("Quitting application");
        Application.Quit();
    }

    private void SetLevelIndexAndLoad(int levelIndex)
    {
        PlayerPrefs.SetInt("SelectedLevelIndex", levelIndex); // Save the level index
        SceneManager.LoadScene(gameSceneName); // Load the game scene
    }

    private void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }

    private void StartGameWithSound()
    {
        PlayButtonClickSound();
        StartGame();
    }

    private void ExitGameWithSound()
    {
        PlayButtonClickSound();
        ExitGame();
    }

    private void OpenLevelSelectionWithSound()
    {
        PlayButtonClickSound();
        OpenLevelSelection();
    }

    private void OpenRulesSceneWithSound()
    {
        PlayButtonClickSound();
        OpenRulesScene();
    }

    private void OpenRulesScene()
    {
        Debug.Log("Opening rules scene");
        SceneManager.LoadScene(rulesSceneName);
    }
}
