using UnityEngine;

public class RotateSteeringWheel : MonoBehaviour
{
    float rotationSpeed = 0.5f;
    float backRotation = 0f;
    float completeRotation = 360f;

    void Update()
    {
        if (!DriveCar.stop)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if(backRotation <= 1.5f*completeRotation) //one and a half rotation of steering wheel
                {
                    transform.Rotate(0, 0, 10 * rotationSpeed);
                    backRotation += 10 * rotationSpeed;
                }
                
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if(backRotation >= -1.5f * completeRotation)
                {
                    transform.Rotate(0, 0, -10 * rotationSpeed);
                    backRotation -= 10 * rotationSpeed;
                }
                
            }
            else
            {
                if (backRotation != 0f) // turn the steering wheel back to z=0;
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
                    backRotation = 0f;
                }
            }
        }
        
    }

}
