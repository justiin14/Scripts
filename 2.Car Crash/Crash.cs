using UnityEngine;

public class Crash : MonoBehaviour
{
    public GameObject canvasGame;

    Rigidbody rb;
    AudioSource audioSource;
    Vector3 torqueForce = 300 * new Vector3(50, 5, -57.5f);

    int drivingSpeed = 50, timeOfCrash = 8;
    float soundDelay=2.7f;
    bool hasCrashed=false, hasPlayed=false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!hasCrashed)
        {
            rb.velocity = drivingSpeed * Vector3.forward;
        }

        if(Time.timeSinceLevelLoad > timeOfCrash-2 && !hasPlayed)
        {
            audioSource.enabled = true;
            hasPlayed = true;
        }

        if(Time.timeSinceLevelLoad > timeOfCrash && !hasCrashed)
        {
            rb.AddForce(4.25f * Vector3.up, ForceMode.Impulse);
            rb.AddTorque(torqueForce * Time.deltaTime, ForceMode.Impulse);
            hasCrashed = true;
        }

        if (Time.timeSinceLevelLoad > timeOfCrash + soundDelay)
        {
            canvasGame.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneChanger.LoadNextScene();
            }
        }
    }
}
