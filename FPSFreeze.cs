using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSFreeze : MonoBehaviour
{
    // Start is called before the first frame update
    public static CharacterController characterController;
    void Start()
    {
        characterController = GetComponent(typeof(CharacterController)) as CharacterController;
    }

    // Update is called once per frame
    void Update()
    {
        characterController.enabled = true;
    }
}
