using System;
using UnityEngine;
using UnityEngine.UI;

public class KickBall : MonoBehaviour
{
    public GameObject ball, fpsController, kickBallMessage, canvasMission;
    public Text crossbarsText, goalsText; 
           Vector3 initialPosition;
           Rigidbody rb;
    
    int crossbars = 0, goals = 0;
    float force = 15.0f; 
    float distance = 2.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = ball.transform.position;
    }

    void Update()
    {
        if(Vector3.Distance(fpsController.transform.position, ball.transform.position) <= distance)
        {
            kickBallMessage.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Vector3 direction = Camera.main.transform.forward;
                rb.AddForce(direction * force, ForceMode.Impulse);
            }
        }
        
        else
        {
            kickBallMessage.SetActive(false);
            if (!isBallInside(ball))
            {
                rb.Sleep();
                ball.transform.position = new Vector3(initialPosition.x + UnityEngine.Random.Range(-20f,20f),
                                                      initialPosition.y,
                                                      initialPosition.z + UnityEngine.Random.Range(-10f,10f));
            }
        }

        if(crossbars == 3 && goals == 3)
        {
            Destroy(canvasMission);
        }
    }

    private bool isBallInside(GameObject ball)
    {
        return
            ball.transform.position.x > 100 && ball.transform.position.x < 160 &&
            ball.transform.position.z < 36 && ball.transform.position.z > 9;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal") && goals<3)
        {
            goals++;
            goalsText.text = goals.ToString();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crossbar") && crossbars<3)
        {
            crossbars++;
            crossbarsText.text = crossbars.ToString();
        }
    }
}
