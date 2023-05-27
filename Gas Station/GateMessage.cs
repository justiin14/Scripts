using System.Collections;
using UnityEngine;

public class GateMessage : MonoBehaviour
{
    public static bool isTransitioning=false, jumped = false;

    void Update()
    {
        if (jumped && !isTransitioning)
        {
            StartCoroutine(TransitionScene());
        }
    }

    IEnumerator TransitionScene()
    {
        yield return null;
        isTransitioning = true;
        SceneChanger.LoadNextScene();
    }
}
