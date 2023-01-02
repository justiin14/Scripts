using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEnded : MonoBehaviour
{
    public static bool hasDialogEnded=false;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            hasDialogEnded = true;
        }
    }
}
