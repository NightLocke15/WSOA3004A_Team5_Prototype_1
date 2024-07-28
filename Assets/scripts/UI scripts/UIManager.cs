using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public Button levelsButton;
    public GameObject levelSelectionPanel;

    private Button[] levelButtons;

    void Start()
    {
        levelSelectionPanel.SetActive(false);
        startButton.Select();

        // Add listeners to buttons
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
        levelsButton.onClick.AddListener(OpenLevelSelection);

        // Add debug logs
        startButton.onClick.AddListener(() => Debug.Log("Start button clicked"));
        exitButton.onClick.AddListener(() => Debug.Log("Exit button clicked"));
        levelsButton.onClick.AddListener(() => Debug.Log("Levels button clicked"));
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
            var selectedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            if (selectedButton != null)
            {
                Debug.Log("Invoking button: " + selectedButton.name);
                selectedButton.onClick.Invoke();
            }
        }
    }

    public void OpenLevelSelection()
    {
        levelSelectionPanel.SetActive(true);
        levelButtons = levelSelectionPanel.GetComponentsInChildren<Button>();

        // Add debug logs and listeners for level buttons
        foreach (var button in levelButtons)
        {
            button.onClick.AddListener(() => Debug.Log(button.name + " clicked"));
            button.onClick.AddListener(() => LoadLevel(button.name)); // Assuming button name is the level name
        }
    }

    public void CloseLevelSelection()
    {
        levelSelectionPanel.SetActive(false);
        levelsButton.Select();
    }

    private void StartGame()
    {
        // Load the game scene, replace "GameScene" with your scene name
        Debug.Log("Starting game");
        SceneManager.LoadScene("SampleScene");
    }

    private void ExitGame()
    {
        // Exit the application
        Debug.Log("Quitting application");
        Application.Quit();
    }

    private void LoadLevel(string levelName)
    {
        // Load the selected level scene
        Debug.Log("Loading level: " + levelName);
        SceneManager.LoadScene(levelName);
    }
}
