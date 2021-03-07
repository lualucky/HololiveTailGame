using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInDirection : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 vel = GetComponent<Rigidbody2D>().velocity;
        if (vel != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(vel);
        }
    }
}
