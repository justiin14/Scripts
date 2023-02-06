using System.Collections;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    public GameObject carCamera, fpsController, canvasDrive, canvasSneak;
    AudioSource audioSource;
    Rigidbody rb;
    

    float horizontal = 0f, vertical = 0f;
    float speed = 10.0f;
    float rotationSpeed = 40.0f;

    public static bool stop = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontal = 0;
        vertical = 0;
        if (!stop)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                horizontal = -1;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                horizontal = 1;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                vertical = 1;
                transform.Translate(0, 0, vertical * Time.deltaTime * speed);
                transform.Rotate(0, horizontal * Time.deltaTime * rotationSpeed, 0);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
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
        audioSource.Stop();
        canvasDrive.SetActive(false);
        yield return new WaitForSeconds(1);

        carCamera.SetActive(false);
        fpsController.SetActive(true);
        rb.isKinematic = true;
        canvasSneak.SetActive(true);
    }
}
