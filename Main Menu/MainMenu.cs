using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneChanger.LoadNextScene();
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitted game");
        Application.Quit();
    }
}
