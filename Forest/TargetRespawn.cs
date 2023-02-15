using UnityEngine;

public class TargetRespawn : MonoBehaviour
{
    Vector3 initialPosition;
    Quaternion initialRotation;

    void Start()
    {
        initialPosition = gameObject.transform.position;
        initialRotation = gameObject.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Terrain"))
        {
            gameObject.GetComponent<Rigidbody>().Sleep();
            gameObject.transform.position = initialPosition;
            gameObject.transform.rotation = initialRotation;
        }
    }
}
