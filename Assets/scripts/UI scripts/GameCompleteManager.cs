using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCompleteManager : MonoBehaviour
{
    public Button mainMenuButton;
    public Button exitButton;
    public AudioClip buttonClickSound; // The sound to play on button click

    private Button[] buttons;
    private int selectedButtonIndex = 0;
    private AudioSource audioSource;

    void Start()
    {
        // Initialize AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        if (buttonClickSound != null)
        {
            audioSource.clip = buttonClickSound;
        }

        // Array of buttons for easy navigation
        buttons = new Button[] { mainMenuButton, exitButton };

        // Select the first button by default
        SelectButton(selectedButtonIndex);

        // Assign button listeners
        mainMenuButton.onClick.AddListener(BackToMainMenu);
        exitButton.onClick.AddListener(ExitGame);

        // Add listeners for playing sound
        mainMenuButton.onClick.AddListener(PlayButtonClickSound);
        exitButton.onClick.AddListener(PlayButtonClickSound);
    }

    void Update()
    {
        // Handle arrow key navigation
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

        // Handle Escape key to exit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }

        // Handle Enter key to invoke the selected button's click event
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            buttons[selectedButtonIndex].onClick.Invoke();
        }
    }

    void SelectButton(int index)
    {
        buttons[index].Select();
    }

    void BackToMainMenu()
    {
        // Load the main menu scene, replace "MainMenu" with your main menu scene name
        SceneManager.LoadScene("MainMenuScene");
    }

    void ExitGame()
    {
        // Exit the application
        Application.Quit();
        Debug.Log("Exiting Game");
    }

    private void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
