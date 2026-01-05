using UnityEngine;
using UnityEngine.SceneManagement; 

public class sphereCollision : MonoBehaviour
{
    public SphereBehavior movement;
    public GameObject gameOverText;
    public GameObject restartButton;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            movement.enabled = false;
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

