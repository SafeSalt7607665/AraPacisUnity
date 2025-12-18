using UnityEngine;

public class SimpleCameraRotation : MonoBehaviour
{
    public float sensitivity = 120f;
    public float minY = -60f;
    public float maxY = 60f;

    private float rotationY = 0f;

    void Update()
    {
        // Right joystick (Input Manager classico)
float lookX = Input.GetAxis("RightStickHorizontal");
float lookY = Input.GetAxis("RightStickVertical");


        // Rotazione orizzontale (Yaw)
        transform.parent.Rotate(Vector3.up * lookX * sensitivity * Time.deltaTime);

        // Rotazione verticale (Pitch)
        rotationY -= lookY * sensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
    }
}
