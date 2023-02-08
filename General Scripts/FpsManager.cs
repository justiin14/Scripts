using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FpsManager : MonoBehaviour
{
    CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            characterController.enabled = false;
            gameObject.transform.position = new Vector3(3,5,3);
            characterController.enabled = true;
        }
    }
}
