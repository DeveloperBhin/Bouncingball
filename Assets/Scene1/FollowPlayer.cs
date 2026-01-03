using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player1;                     
    public Vector3 baseOffset = new Vector3(0f, 5f, -10f); // Negative Z = behind
    public float smoothSpeed = 5f;                
    public float speedMultiplier = 0.05f;         
    public float maxZOffset = -20f;               
    public float minZOffset = -1f;                

    private Vector3 lastPlayerPosition;

    void Start()
    {
        if (player1 == null)
        {
            Debug.LogError("Player1 is not assigned!");
            enabled = false;
            return;
        }

        lastPlayerPosition = player1.position;
    }

    void LateUpdate()
    {
        if (player1 == null) return;

        // Player speed
        float playerSpeed = (player1.position - lastPlayerPosition).magnitude / Time.deltaTime;

        // Dynamic offset: move further back as speed increases
        float dynamicZ = baseOffset.z + playerSpeed * speedMultiplier;
        dynamicZ = Mathf.Clamp(dynamicZ, maxZOffset, minZOffset); // negative = behind

        // Target position
        Vector3 targetPosition = player1.position + new Vector3(baseOffset.x, baseOffset.y, dynamicZ);

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);

        // Look at player
        transform.LookAt(player1);

        // Debug
        Debug.Log($"Player: {player1.position} | Camera: {transform.position} | Offset: ({baseOffset.x},{baseOffset.y},{dynamicZ:F2}) | Speed: {playerSpeed:F2}");

        lastPlayerPosition = player1.position;
    }
}

