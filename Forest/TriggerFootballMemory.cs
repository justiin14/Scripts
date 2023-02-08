using System.Collections;
using UnityEngine;

public class TriggerFootballMemory : MonoBehaviour
{
    public GameObject boy, dad, ball, fpsController, realBall, canvasFootballMision;
    public AudioClip audioClip;
           AudioSource audioSource;
           Rigidbody rb;
    float distance = 30f;
    bool triggered = false;

    private void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Vector3.Distance(fpsController.transform.position, ball.transform.position) <= distance && !triggered)
        {
            Flashback.startFlashback = true;
            audioSource.PlayOneShot(audioClip);
            StartCoroutine(StartAnimation());
            StartCoroutine(StartBallHit());
            StartCoroutine(EndFlashback());
            triggered = true;
        }
    }

    IEnumerator StartBallHit()
    {
        yield return new WaitForSeconds(1.5f);
        rb.AddForce(new Vector3(-10, 0, 0), ForceMode.Impulse);
    }

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(1f);
        boy.SetActive(true);
        dad.SetActive(true);
        ball.SetActive(true);
    }

    IEnumerator EndFlashback()
    {
        yield return new WaitForSeconds(3.5f);
        boy.SetActive(false);
        dad.SetActive(false);
        ball.SetActive(false);

        Flashback.startFlashback = true;
        yield return new WaitForSeconds(1f);
        realBall.SetActive(true);
        canvasFootballMision.SetActive(true);
    }
}
