using UnityEngine;
using TMPro; // ✅ Add this line for TextMeshPro

public class StoreCount : MonoBehaviour
{
    public Transform Sphere;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        if (Sphere != null && scoreText != null)
        {
            // Update the text with the sphere's Z position
            scoreText.text = Sphere.position.z.ToString("F2");
        }
    }
}

