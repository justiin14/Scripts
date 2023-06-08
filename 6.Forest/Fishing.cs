using System.Collections;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public GameObject fpsController, startFishingCanvas, fishingRode, fish;

    Vector3 seatPosition, fpsPosition;
    CharacterController characterController;

    void Start()
    {
        seatPosition = gameObject.transform.position;
        characterController = fpsController.GetComponent<CharacterController>();
    }

    void Update()
    {
        fpsPosition = fpsController.transform.position;
        
        if (Vector3.Distance(seatPosition, fpsPosition) < 3f && Tracker.isFishingRodCollected && !Tracker.isFishCollected)
        {
            startFishingCanvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(startFishingCanvas);
                fishingRode.SetActive(true);
                characterController.enabled = false;
                
                StartCoroutine(CatchFish());
            }
        }
        else
        {
            startFishingCanvas.SetActive(false);
        }
    }

    IEnumerator CatchFish()
    {
        yield return new WaitForSeconds(3f);
        fishingRode.SetActive(false);
        fish.SetActive(true);
        StartCoroutine(LetFPSGo());
    }

    IEnumerator LetFPSGo()
    {
        yield return new WaitForSeconds(3f);
        fish.SetActive(false);
        characterController.enabled = true;
        Tracker.isFishCollected = true;
        Tracker.missionsCompleted++;
    }
}
