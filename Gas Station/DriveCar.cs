using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    public GameObject carCamera, fpsController, canvasDrive, canvasSneak;
    Rigidbody rb;

    float horizontal = 0f, vertical = 0f;
    float speed = 7.0f;
    float rotationSpeed = 30.0f;

    public static bool stop = false;

    private void Start()
    {
        //play car running sound
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontal = 0;
        vertical = 0;
        if (!stop)
        {
            if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1;
            }

            if (Input.GetKey(KeyCode.W))
            {
                vertical = 1;
                transform.Translate(0, 0, vertical * Time.deltaTime * speed);
                transform.Rotate(0, horizontal * Time.deltaTime * rotationSpeed, 0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                vertical = -1;
                transform.Translate(0, 0, vertical * Time.deltaTime * speed);
                transform.Rotate(0, -horizontal * Time.deltaTime * rotationSpeed, 0);
            }
        }
        else
        {
            StartCoroutine(WaitAndExit());
        }
        
    }

    void OnCollisionStay(Collision collision)
    {
        rb.Sleep();
    }

    IEnumerator WaitAndExit()
    {
        //play stop engine sound
        yield return new WaitForSeconds(2);
        canvasDrive.SetActive(false);
        carCamera.SetActive(false);

        fpsController.SetActive(true);
        rb.isKinematic = true;
        canvasSneak.SetActive(true);
        //play slam door sound
    }
}
