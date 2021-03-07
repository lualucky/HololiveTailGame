using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public int Value;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter!!!");
        ScoreManager.Instance.AddScore(Value);
    }
}
