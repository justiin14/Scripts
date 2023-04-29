using UnityEngine;

public class Wiper : MonoBehaviour
{
    float rotationSpeed = 30f;
    bool isRotatingForward = true;

    private void Update()
    {
        float zRotation = transform.rotation.eulerAngles.z;

        if (isRotatingForward)
        {
            zRotation += Time.deltaTime * rotationSpeed;
            if (zRotation >= 25f)
            {
                zRotation = 25f;
                isRotatingForward = false;
            }
        }
        else
        {
            zRotation -= Time.deltaTime * rotationSpeed;
            if (zRotation <= 0f)
            {
                zRotation = 0f;
                isRotatingForward = true;
            }
        }

        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, zRotation));
    }
}