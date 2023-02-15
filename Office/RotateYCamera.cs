using UnityEngine;

public class RotateYCamera : MonoBehaviour
{
    float RotationSensitivity = 100.0f, yRotate = 0.0f, xRotate = 0.0f;

    void Update()
    {
        yRotate += Input.GetAxis("Mouse X") * RotationSensitivity * Time.deltaTime;
        xRotate += Input.GetAxis("Mouse Y") * RotationSensitivity * Time.deltaTime;

        yRotate = Mathf.Clamp(yRotate, -180, 180);
        xRotate = Mathf.Clamp(xRotate, -10, 10);

        transform.eulerAngles = new Vector3(-xRotate, yRotate, 0.0f);
    }
}
