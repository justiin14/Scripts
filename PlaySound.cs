using UnityEngine;

public class PlaySound : MonoBehaviour
{
    // Reference to the FPS controller script
    public GameObject fps;
    public AudioClip clip;
    AudioSource audioSource;
    Vector3 gameObjectPosition, fpsPosition;
    float distanceToInterract = 5.0f;
    public static bool soundEnded = false;
    private void Start()
    {
        gameObjectPosition = gameObject.GetComponent<Transform>().position;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        fpsPosition = fps.GetComponent<Transform>().position;
        
        if (Vector3.Distance(fpsPosition, gameObjectPosition) < distanceToInterract)
        {
            if (!soundEnded)
            {
                audioSource.PlayOneShot(clip);
                soundEnded = true;
            }
        }
    }
}