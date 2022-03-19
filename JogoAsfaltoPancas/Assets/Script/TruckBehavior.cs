using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckBehavior : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Vector3 direction = -Vector3.forward * speed * Time.deltaTime;
        transform.Translate(direction);
    }
}
