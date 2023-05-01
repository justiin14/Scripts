using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSong : MonoBehaviour
{
    AudioSource audioSource;
 
    void Start()
    {
        Debug.Log(Tracker.carSong);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Tracker.carSong);
    }
}
