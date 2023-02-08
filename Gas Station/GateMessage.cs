using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GateMessage : MonoBehaviour
{
    public GameObject fpsController, textMessageCanvas;

    float triggerDistance = 2.0f, distance;
    int nextScene;

    bool isTransitioning=false;

    void Update()
    {
        distance = Vector3.Distance(transform.position, fpsController.transform.position);
        if (distance <= triggerDistance)
        {
            textMessageCanvas.SetActive(true);
            if (Input.GetKey(KeyCode.E) && !isTransitioning)
            {
                StartCoroutine(TransitionScene());
            }
        }
        else
        {
            textMessageCanvas.SetActive(false);
        }
    }

    IEnumerator TransitionScene()
    {
        isTransitioning = true;
        while (Input.GetKey(KeyCode.E))
        {
            yield return null;
        }
        SceneChanger.LoadNextScene();
    }
}
