using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYCamera : MonoBehaviour
{
    float RotationSensitivity = 100.0f, yRotate = 0.0f;
    float minAngle = -60.0f, maxAngle = 60.0f;

    void Update()
    {
        //Rotate Y view
        yRotate += Input.GetAxis("Mouse X") * RotationSensitivity * Time.deltaTime;
        yRotate = Mathf.Clamp(yRotate, minAngle, maxAngle);
        transform.eulerAngles = new Vector3(0.0f, yRotate, 0.0f);
    }
}
