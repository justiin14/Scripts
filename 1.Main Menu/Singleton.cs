using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    static Singleton instance;
    int sceneNumber;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(instance);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex >= 3)
        {
            Destroy(gameObject);
        }
    }
}
