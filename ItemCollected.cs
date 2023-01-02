using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollected : MonoBehaviour
{
    Vector3 fpsPosition, gameObjectPosition;
    public GameObject fpsController;
    public Text item;
    float distanceToInterract = 3.0f;

    private void Start()
    {
        gameObjectPosition = gameObject.transform.position;
    }

    void Update()
    {
        fpsPosition = fpsController.GetComponent<Transform>().position;

        if (Vector3.Distance(fpsPosition, gameObjectPosition) < distanceToInterract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.SetActive(false);
                item.color = Color.green;
                Items.itemsCollected++;
            }
        }
    }
}
