using UnityEngine;

public class FishingRodeInstruction : MonoBehaviour
{
    public GameObject canvasFishingRode, fpsController;

    void Update()
    {
        if (Vector3.Distance(fpsController.transform.position, gameObject.transform.position) < 3f && !Tracker.isFishingRodCollected)
        {
            canvasFishingRode.SetActive(true);
        }
        else
        {
            canvasFishingRode.SetActive(false);
        }
    }
}
