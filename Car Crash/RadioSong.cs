using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSong : MonoBehaviour
{
    AudioSource audioSource;
 
    void Start()
    {
        Debug.Log(GeneralVariables.carSong);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(GeneralVariables.carSong);
    }
}
