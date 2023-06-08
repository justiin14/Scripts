using System.Collections;
using UnityEngine;

public class ShooterFlashback : MonoBehaviour
{
    public GameObject flashbackObjects, fpsController, box, cam;
    CharacterController characterController;
    public AudioSource audioSource;
    public AudioClip audioClip;

    Vector3 fpsControllerPosition, boxPosition;
    float distanceToFlashbackTrigger = 30f;
    bool triggered = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxPosition = box.transform.position;
        characterController = fpsController.GetComponent<CharacterController>();
    }

    private void Update()
    {
        fpsControllerPosition = fpsController.transform.position;
        if(Vector3.Distance(fpsControllerPosition, boxPosition) < distanceToFlashbackTrigger 
            && !triggered && !Tracker.isMissionInProgress)
        {
            characterController.SimpleMove(new Vector3(0, 0, 0));
            characterController.enabled = false;
            StartCoroutine(StartShootingFlashback());
            StartCoroutine(EndShootingFlashback());
        }
    }

    IEnumerator StartShootingFlashback()
    {
        audioSource.PlayOneShot(audioClip);
        Flashback.startFlashback = true;
        triggered = true;

        yield return new WaitForSeconds(.5f);
        flashbackObjects.SetActive(true);

    }

    IEnumerator EndShootingFlashback()
    {
        yield return new WaitForSeconds(5f);
        Flashback.startFlashback = true;

        yield return new WaitForSeconds(.25f);
        flashbackObjects.SetActive(false);
        characterController.enabled = true;
    }
}
