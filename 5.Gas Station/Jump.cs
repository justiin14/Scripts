using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Am intrat");
        if (other.gameObject.CompareTag("Player")){
            GateMessage.jumped = true;
        }
    }
}
