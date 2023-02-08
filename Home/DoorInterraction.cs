using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInterraction : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip clipOpenDoor;
    public AudioClip clipCloseDoor;
    public GameObject player;

    float distanceToInterract = 3.0f;

    bool isOpened = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < distanceToInterract)
        {
            animator.SetBool("isOpen", true);
        }
        else
        {
            animator.SetBool("isOpen", false);
            isOpened = true;
        }
    }

    void PlayOpenSFX()
    {
        audioSource.PlayOneShot(clipOpenDoor);
    }

    void PlayCloseSFX()
    {
        audioSource.PlayOneShot(clipCloseDoor);
    }
}
