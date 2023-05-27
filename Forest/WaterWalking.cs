using UnityEngine;

public class WaterWalking : MonoBehaviour
{
    public GameObject fpsController;
    AudioSource fpsAudio, waterAudio;

    private void Start()
    {
        fpsAudio = fpsController.GetComponent<AudioSource>();
        waterAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fpsAudio.mute = true;
            waterAudio.mute = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool isPlayerMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
            if (!isPlayerMoving)
            {
                waterAudio.mute = true;
                fpsAudio.mute = true;
            }
            else
            {
                waterAudio.mute = false;
                fpsAudio.mute = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fpsAudio.mute = false;
            waterAudio.mute = true;
        }
    }
}
