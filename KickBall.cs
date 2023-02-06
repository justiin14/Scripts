using System;
using UnityEngine;

public class KickBall : MonoBehaviour
{
    public GameObject ball, fpsController, kickBallMessage;
    float force = 20.0f;
    float distance = 2.0f;
    Vector3 initialPosition;
    Rigidbody rb;

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
                ball.transform.position = initialPosition;
            }
        }
    }

    private bool isBallInside(GameObject ball)
    {
        return
            ball.transform.position.x > 100 && ball.transform.position.x < 160 &&
            ball.transform.position.z < 36 && ball.transform.position.z > 9;
    }
}
