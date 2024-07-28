using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public Button pauseButton;  // The always visible pause button
    public Button resumeButton;
    public Button mainMenuButton;
    public Button exitButton;

    private Button[] buttons;
    private int selectedButtonIndex = 0;
    private bool isPaused = false;

    void Start()
    {
        // Ensure the pause menu is inactive at the start
        pauseMenuPanel.SetActive(false);

        // Array of buttons for easy navigation
        buttons = new Button[] { resumeButton, mainMenuButton, exitButton };

        // Assign button listeners
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        exitButton.onClick.AddListener(ExitGame);

        // Assign listener to the always visible pause button
        pauseButton.onClick.AddListener(TogglePauseMenu);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
   
            if (!pauseMenuPanel.activeSelf)
            {
              
                pauseButton.Select();
                pauseButton.onClick.Invoke();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
          
            if (pauseMenuPanel.activeSelf)
            {
             
                TogglePauseMenu();
            }
            else
            {
            
                ExitGame();
            }
        }

        // The following navigation handling should only be active when the pause menu is active
        if (pauseMenuPanel.activeSelf)
        {
            HandleNavigation();
        }
    }

    void TogglePauseMenu()
    {
        isPaused = !isPaused;
        pauseMenuPanel.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            SelectButton(selectedButtonIndex); // Select the first button
         
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
        
        }
    }

    void HandleNavigation()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedButtonIndex = (selectedButtonIndex - 1 + buttons.Length) % buttons.Length;
            SelectButton(selectedButtonIndex);
           
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedButtonIndex = (selectedButtonIndex + 1) % buttons.Length;
            SelectButton(selectedButtonIndex);
       
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            buttons[selectedButtonIndex].onClick.Invoke();
        
        }
    }

    void SelectButton(int index)
    {
        buttons[index].Select();
      
    }

    void ResumeGame()
    {
        isPaused = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
       
    }

    void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game is not paused when switching scenes
        SceneManager.LoadScene("MainMenuScene"); // Replace "MainMenuScene" with your main menu scene name
       
    }

    void ExitGame()
    {
        Time.timeScale = 1f; // Ensure the game is not paused when quitting
        Application.Quit();
        Debug.Log("Exiting Game from pause menu");
    }
}
