using UnityEngine;

public class SphereBehavior : MonoBehaviour
{
    public Rigidbody rb;

    [Header("Movement Settings")]
    public float moveSpeed = 10f;         // Base speed
    public float acceleration = 5f;       // How quickly to reach target speed
    public float sidewaysForce = 50f;    // Side movement strength

    private Vector3 moveVelocity;
    private Vector3 inputDirection;

    void Start()
    {
        rb.freezeRotation = true; // Prevent unwanted rotations
    }

    void FixedUpdate()
    {
        // Get input (WASD)
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey("w")) moveZ = 1f;     // Forward
        if (Input.GetKey("s")) moveZ = -1f;    // Backward
        if (Input.GetKey("d")) moveX = 1f;     // Right
        if (Input.GetKey("a")) moveX = -1f;    // Left

        // Combine input directions
        inputDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // Smoothly change current velocity toward target
        Vector3 targetVelocity = inputDirection * moveSpeed;
        moveVelocity = Vector3.Lerp(moveVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);

        // Apply velocity while keeping vertical physics
        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
    }
}

