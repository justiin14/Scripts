using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject dialogueSystem;

    public void StartGame()
    {
        dialogueSystem.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
