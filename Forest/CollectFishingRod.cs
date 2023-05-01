using UnityEngine;

public class CollectFishingRod : MonoBehaviour
{
    public GameObject fpsController;
    Vector3 fishingRodPosition, fpsPosition;

    void Start()
    {
        fishingRodPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        fpsPosition = fpsController.transform.position;
        if (Vector3.Distance(fishingRodPosition, fpsPosition) < 3f && !Tracker.isFishingRodCollected)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.SetActive(false);
                Tracker.isFishingRodCollected = true;
            }
        }
    }
}
