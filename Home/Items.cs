using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject canvasItems, canvas;
    public static int itemsCollected = 0;
    void Update()
    {
        canvasItems.SetActive(true);
        if(itemsCollected == 4)
        {
            canvasItems.SetActive(false);
            canvas.SetActive(true);
        }
    }
}
