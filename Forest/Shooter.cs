using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Camera cam;
    public AudioSource audioSource, audioSourceGun;
    public AudioClip gunShotClip;
           TargetFactory factory;
    readonly float force = 50f;

    public static int targetsHit = 0;
    public static bool isRifleEquipped = false;

    private void Start()
    {
        factory = new TargetFactory();
        audioSource = GetComponent<AudioSource>();
        audioSourceGun = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isRifleEquipped)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            audioSourceGun.PlayOneShot(gunShotClip);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Target target = factory.CreateTarget(hit.collider.tag);

                if (hit.collider.CompareTag("Target"))
                {
                    targetsHit++;

                    Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                    Vector3 direction = hit.point - rb.position;

                    rb.AddForce(-direction * force, ForceMode.Impulse);
                }
                else if (target != null)
                {
                    audioSource.PlayOneShot(target.GetSoundClip());
                }
            }
        }
    }

}
