using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    public List<HitDetection> Colliders;

    private bool hitRecieved;
    private int score;

    private void FixedUpdate()
    {
        if (hitRecieved)
        {
            HitRegistered();
        }
    }

    public void RecieveHit(int Score, bool Last)
    {
        score = Mathf.Max(score, Score);

        hitRecieved = Last || hitRecieved;
    }

    public void Reset()
    {
        hitRecieved = false;
        score = 0;
    }

    public void HitRegistered()
    {
        ScoreManager.Instance.AddScore(score);
        Reset();
    }
}

