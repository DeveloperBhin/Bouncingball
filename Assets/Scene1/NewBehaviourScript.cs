using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 10f;
    public float sidewaysForce = 5f;
   public float rotationSmoothness = 10f; // Optional: smooth turning


    void Start()
    {
        rb.freezeRotation = true; // Prevent rotation when moving
    }

    void FixedUpdate()
    {
        // Constant forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // Move right
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Move left
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}

