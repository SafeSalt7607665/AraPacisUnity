using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform; // Assegna qui la camera

    Rigidbody rb;
    Vector3 input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Input normalizzato
        Vector3 rawInput = new Vector3(x, 0f, z).normalized;

        // Trasformalo rispetto alla camera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        input = (forward * rawInput.z + right * rawInput.x) * speed;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(input.x, rb.linearVelocity.y, input.z);
    }
}
