using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            int scenaUrmatoare = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(scenaUrmatoare);
        }
    }
}
