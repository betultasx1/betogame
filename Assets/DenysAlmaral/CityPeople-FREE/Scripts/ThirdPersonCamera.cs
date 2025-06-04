using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // Karakterin Transform'u
    public Vector3 offset = new Vector3(0, 3, -6);
    public float sensitivity = 3f;
    public float distance = 6f;
    public float minY = -20f;
    public float maxY = 60f;

    float rotationX = 0f;
    float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (!target) return;

        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
        Vector3 position = target.position - rotation * Vector3.forward * distance + Vector3.up * offset.y;

        transform.position = position;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
