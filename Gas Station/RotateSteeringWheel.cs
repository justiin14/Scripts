using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSteeringWheel : MonoBehaviour
{
    float rotationSpeed = 0.2f;
    float backRotation = 0f;

    void Update()
    {
        if (!DriveCar.stop)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, 0, 10 * rotationSpeed);
                backRotation += 10;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 0, -10 * rotationSpeed);
                backRotation -= 10;
            }
            else
            {
                if (backRotation != 0f)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
                    backRotation = 0f;
                }
            }
        }
        
    }

}
