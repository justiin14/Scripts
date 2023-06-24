using System.Collections;
using UnityEngine;

public class FreesbieThrow : MonoBehaviour
{
    public GameObject freesbie, kid, mom, fpsController, canopy;
    public AudioSource audioSource;
    CharacterController characterController;
    Vector3 fpsPosition, canopyPosition;
    float speed = 15f;

    public static bool triggered = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        canopyPosition = canopy.transform.position;
        characterController = fpsController.GetComponent<CharacterController>();
    }

    void Update()
    {
        fpsPosition = fpsController.transform.position;
        if (Vector3.Distance(fpsPosition, canopyPosition) < 40f && !triggered)
        {
            Flashback.startFlashback = true;
            audioSource.Play();
            triggered = true;
            characterController.SimpleMove(Vector3.zero);
            characterController.enabled = false;
            StartCoroutine(WaitForThrow());
            StartCoroutine(EndFlashback());
        }
        if (freesbie.activeSelf)
        {
            freesbie.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    IEnumerator WaitForThrow()
    {
        yield return new WaitForSeconds(0.5f);
        mom.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        freesbie.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        kid.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        freesbie.SetActive(false);
        
    }

    IEnumerator EndFlashback()
    {
        yield return new WaitForSeconds(3f);
        Flashback.startFlashback = true;
        yield return new WaitForSeconds(0.5f);
        mom.SetActive(false);
        kid.SetActive(false);
        characterController.enabled = true;
    }
    
}
