using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For loading/reloading scenes

public class ButtonsControls : MonoBehaviour
{
    public Button HomButton;
    public Button PlayButton;
    public Button PausButton;
    public Button xitButton;
    public Button StartButton;

    private bool isPaused = false;

    void Start()
    {
        // Attach listeners to each button
        HomButton.onClick.AddListener(OnHomeButton);
        PlayButton.onClick.AddListener(OnPlayButton);
        PausButton.onClick.AddListener(OnPauseButton);
        xitButton.onClick.AddListener(OnExitButton);
        StartButton.onClick.AddListener(OnStartButton);
    }

    void OnHomeButton()
    {
        // Example: Reload home scene
        SceneManager.LoadScene("HomeScene");
    }

    void OnPlayButton()
    {
        Time.timeScale = 1f; // Resume game speed
        Debug.Log("Play clicked");
    }

    void OnPauseButton()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f; // Toggle pause
        Debug.Log("Paused: " + isPaused);
    }

    void OnExitButton()
    {
        Debug.Log("Exit clicked");
        Application.Quit(); // Works in build (not in editor)
    }

    void OnStartButton()
    {
        Debug.Log("Start clicked");
        // Example: Load next scene or start gameplay
        SceneManager.LoadScene("GameScene");
    }
}

