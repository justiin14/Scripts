using System.Collections.Generic;
using UnityEngine;

public class FpsManager : MonoBehaviour
{
    List<Vector3> positions;
    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        positions = new List<Vector3>()
        {
            new Vector3(123, 5, -30),
            new Vector3(-55, 5, -33),
            new Vector3( 65, 5,  70),
            new Vector3( 20, 5, 120)
        };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            characterController.enabled = false;
            gameObject.transform.position = positions[2];
            characterController.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            characterController.enabled = false;
            gameObject.transform.position = positions[3];
            characterController.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            characterController.enabled = false;
            gameObject.transform.position = positions[1];
            characterController.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            characterController.enabled = false;
            gameObject.transform.position = positions[0];
            characterController.enabled = true;
        }
    }
}
