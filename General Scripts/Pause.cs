using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject gameObject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            gameObject.SetActive(!gameObject.activeSelf);
            if (gameObject.activeSelf)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }       
    }
}
