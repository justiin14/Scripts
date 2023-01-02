using UnityEngine;

public class KickBall : MonoBehaviour
{
    public GameObject ball, fpsController, kickBallMessage;
    float force = 20.0f;
    float distance = 2.0f;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        }
    }
}
