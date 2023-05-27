using UnityEngine;

public class Instruction : MonoBehaviour
{
    public GameObject fpsController;
    Vector3 gatePosition, fpsPosition;

    void Start()
    {
        gatePosition = gameObject.transform.position;
    }

    void Update()
    {
        fpsPosition = fpsController.transform.position;

        if(Vector3.Distance(gatePosition, fpsPosition) < 20f && Tracker.missionsCompleted == 3)
        {
            SceneChanger.LoadNextScene();
        }
    }

    private void OnGUI()
    {
        if (Vector3.Distance(gatePosition, fpsPosition) < 20f && Tracker.missionsCompleted <3)
        {
            GUI.skin.label.fontSize = 30;
            GUI.Label(new Rect(50, 50, 1000, 1000), "Come back when you complete 3 missions");
        }

        if(Tracker.missionsCompleted == 3)
        {
            GUI.skin.label.fontSize = 30;
            GUI.Label(new Rect(50, 50, 1000, 1000), "Head back to the fence");
        }
    }
}
