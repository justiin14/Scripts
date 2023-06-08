using UnityEngine;

public class DoorInterraction : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip clipOpenDoor, clipCloseDoor;
    public GameObject player;

    float distanceToInterract = 3.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < distanceToInterract)
        {
            animator.SetBool("isOpen", true);
        }
        else
        {
            animator.SetBool("isOpen", false);
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
