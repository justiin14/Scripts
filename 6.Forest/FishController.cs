using UnityEngine;
using System.Collections;
using System;

public class FishController : MonoBehaviour {

    int direction = 1;
    float speed = 2.0f, angle=0;
    Vector3 position;

    private void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        transform.Translate(new Vector3(0,0,direction) * speed * Time.deltaTime, Space.World);

        if(Math.Abs(transform.position.z - position.z) > 10)
        {
            angle += 180;
            direction = -direction;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0f, angle, 0f)), 180);
        }
    }
}
