using UnityEngine;

public class RotateMenuCamera : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime*2);
    }
}
