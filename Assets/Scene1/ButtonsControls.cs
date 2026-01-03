using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For loading/reloading scenes

public class ButtonsControls : MonoBehaviour
{
    public Button HomeButton;
    public Button PlayButton;
    public Button PauseButton;
    public Button ExitButton;
    public Button StartButton;
    public Rigidbody sphereRb;
    public float startForce = 20f; // Adjust for desired roll speed


    private bool isPaused = false;

    void Start()
    {
        // Attach listeners to each button
        HomeButton.onClick.AddListener(OnHomeButton);
        PlayButton.onClick.AddListener(OnPlayButton);
        PauseButton.onClick.AddListener(OnPauseButton);
        ExitButton.onClick.AddListener(OnExitButton);
        StartButton.onClick.AddListener(OnStartButton);
    }

    void OnHomeButton()
    {
    Debug.Log("Exit clicked");

#if UNITY_EDITOR
    // If running inside the Unity Editor — stop Play Mode
    UnityEditor.EditorApplication.isPlaying = false;
#else
    // If running in a built game — quit the application
    Application.Quit();
#endif
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

#if UNITY_EDITOR
    // If running inside the Unity Editor — stop Play Mode
    UnityEditor.EditorApplication.isPlaying = false;
#else
    // If running in a built game — quit the application
    Application.Quit();
#endif
}


    
      void OnStartButton()
    {
        Debug.Log("Start clicked");
        sphereRb.AddForce(Vector3.forward * startForce);
    }
}

