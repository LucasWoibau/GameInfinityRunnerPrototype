using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    void Update()
    {
        Vector3 direction = Vector3.forward * _speed * Time.deltaTime;
        transform.Translate(direction);
    }
}
