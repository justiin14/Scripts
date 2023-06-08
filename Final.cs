using System.Collections;
using UnityEngine;

public class Final : MonoBehaviour
{
    public GameObject parent1, parent2, canvas, canvasEnd;
    bool canQuit = false;
    void Start()
    {
        StartCoroutine(TriggerSequence());
    }

    private void Update()
    {
        if (canQuit)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
                Debug.Log("Have quitted");
            }
        }
    }

    IEnumerator TriggerSequence()
    {
        yield return new WaitForSeconds(24f);
        parent1.SetActive(true);
        parent2.SetActive(true);

        yield return new WaitForSeconds(2f);
        canvas.SetActive(true);
        parent1.SetActive(false);
        parent2.SetActive(false);

        yield return new WaitForSeconds(3f);
        canvasEnd.SetActive(true);
        canQuit = true;
    }
}
