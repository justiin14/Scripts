using System.Threading;
using UnityEngine;

public class InterractionKey : MonoBehaviour
{
    public static bool hasSeated = false, hasDialogEnded = false;
    public GameObject fpsController, personaj, canvas, canvasSitUp;
    float distanceToInterract = 3f;
    AudioSource audioSource;
    Vector3 fpsPosition, gameObjectPosition;

    void Start()
    {
        gameObjectPosition = gameObject.GetComponent<Transform>().position;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        fpsPosition = fpsController.GetComponent<Transform>().position;

        if (Vector3.Distance(fpsPosition, gameObjectPosition) < distanceToInterract && !hasSeated)
        {
            canvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                audioSource.Play();
                fpsController.SetActive(false);
                hasSeated = true;
            }
        }
        else
        {
            canvas.SetActive(false);
            if (hasSeated && !hasDialogEnded) 
            {
                personaj.GetComponent<Animator>().enabled = true;
                if (!audioSource.isPlaying)
                {
                    canvasSitUp.SetActive(true);
                    if (Input.GetKey(KeyCode.E))
                    {
                        fpsController.SetActive(true);
                        canvasSitUp.SetActive(false);
                        hasDialogEnded = true;
                        personaj.GetComponent<Animator>().enabled = false;
                    }
                }
            }
        }
    }
}

