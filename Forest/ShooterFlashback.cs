using UnityEngine;

public class ShooterFlashback : MonoBehaviour
{
    //public GameObject shootingRange, wolf;
    //public Animator animator;
    //public AudioSource audioSource;
    //bool triggered = false;

    //private void Start()
    //{
    //    animator = wolf.GetComponent<Animator>();
    //    audioSource = GetComponent<AudioSource>();
    //}

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha9))
    //    {
    //        Shooter.targetsHit = 10;
    //    }

    //    if(Shooter.targetsHit == 10 && !triggered)
    //    {
    //        Flashback.startFlashback = true;
    //        StartCoroutine(WaitForWolfAppearance());
    //        triggered = true;
    //    }

    //    if (Shooter.isWolfDead)
    //    {
    //        animator.SetTrigger("Die");
    //    }
    //}

    //IEnumerator WaitForWolfAppearance()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    shootingRange.SetActive(false);
    //    wolf.SetActive(true);

    //    yield return new WaitForSeconds(1f);
    //    if (!Shooter.isWolfDead)
    //    {
    //        audioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/AimForTheHead"));
    //    }

    //}
}
