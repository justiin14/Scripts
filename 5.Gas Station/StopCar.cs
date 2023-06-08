using UnityEngine;

public class StopCar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")){
            DriveCar.stop = true;
        }
    }
}
