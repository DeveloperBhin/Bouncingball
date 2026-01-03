using UnityEngine;
using UnityEngine.UIElements; // Must include this

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument uiDoc;

    void OnEnable()
    {
        // Get the UIDocument attached to this GameObject
        uiDoc = GetComponent<UIDocument>();

        if (uiDoc == null)
        {
            Debug.LogError("No UIDocument found on this GameObject!");
            return;
        }

        var root = uiDoc.rootVisualElement;

        // Query the button by name (from UXML)
        var startButton = root.Q<Button>("startButton");

        // Register the click event
        startButton.clicked += OnStartButtonClicked;
    }

    void OnDisable()
    {
        // Unregister the event to avoid memory leaks
        var startButton = uiDoc.rootVisualElement.Q<Button>("startButtonGame");
        startButton.clicked -= OnStartButtonClicked;
    }

    private void OnStartButtonClicked()
    {
        Debug.Log("Start button clicked!");
    }
}

