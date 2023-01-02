using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveHome : MonoBehaviour
{
    public GameObject fpsController, canvas;
    float distanceToInterract = 3f;
    Vector3 fpsPosition, gameObjectPosition;

    void Start()
    {
        gameObjectPosition = gameObject.GetComponent<Transform>().position;
    }

    void Update()
    {
        fpsPosition = fpsController.GetComponent<Transform>().position;

        if (Vector3.Distance(fpsPosition, gameObjectPosition) < distanceToInterract && Items.itemsCollected == 4)
        {
            canvas.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            canvas.SetActive(false);
        }
    }
}
