using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public bool Last;
    public int Value;

    private HitManager manager;

    private void Start()
    {
        manager = transform.parent.GetComponent<HitManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        manager.RecieveHit(Value, Last);
    }
}
