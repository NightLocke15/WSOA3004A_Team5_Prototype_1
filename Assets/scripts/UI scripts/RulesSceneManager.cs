using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RulesSceneManager : MonoBehaviour
{
    public Button closeButton;
    public AudioClip buttonClickSound; // The sound to play on button click
    public string mainMenuSceneName = "MainMenu"; // The name of the main menu scene

    private AudioSource audioSource;

    void Start()
    {
        // Initialize AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        if (buttonClickSound != null)
        {
            audioSource.clip = buttonClickSound;
        }

        // Add listeners to buttons
        closeButton.onClick.AddListener(CloseRulesWithSound);

        // Add debug logs
        closeButton.onClick.AddListener(() => Debug.Log("Close Instructions button clicked"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Closing rules scene");
            CloseRules();
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

    private void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }

    private void CloseRulesWithSound()
    {
        PlayButtonClickSound();
        CloseRules();
    }

    private void CloseRules()
    {
        Debug.Log("Closing rules scene");
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
