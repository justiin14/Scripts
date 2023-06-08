using UnityEngine;

public class Instruction : MonoBehaviour
{
    public GameObject fpsController, canvasCompleteMissions;
    Vector3 gatePosition, fpsPosition;

    void Start()
    {
        gatePosition = gameObject.transform.position;
    }

    void Update()
    {
        fpsPosition = fpsController.transform.position;

        if(Vector3.Distance(gatePosition, fpsPosition) < 20f && Tracker.missionsCompleted != 3)
        {
            canvasCompleteMissions.SetActive(true);
            Debug.Log(Tracker.missionsCompleted);
        }
        else 
        {
            canvasCompleteMissions.SetActive(false);
        }

        if(Vector3.Distance(gatePosition, fpsPosition) < 10f && Tracker.missionsCompleted == 3)
        {
            SceneChanger.LoadNextScene();
        }
    }
}
