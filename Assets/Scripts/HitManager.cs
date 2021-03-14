using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    public List<HitDetection> Colliders;

    public bool SlidingScale;

    private bool hitRecieved;
    private int score;

    private Tail tail;

    private void Start()
    {
        if(SlidingScale)
        {
            transform.GetChild(0).GetComponent<HitDetection>().SlidingScore = true;
            for (int i = 1; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void FixedUpdate()
    {
        if (hitRecieved)
        {
            HitRegistered();
        }
    }

    public void RecieveHit(int Score, bool Last, Tail incomingTail)
    {
        if (tail == null || tail == incomingTail)
        {
            tail = incomingTail;
            score = Mathf.Max(score, Score);

            hitRecieved = Last || hitRecieved;
            tail.Hit();
        }
    }

    public void Reset()
    {
        tail = null;
        hitRecieved = false;
        score = 0;
    }

    public void HitRegistered()
    {
        ScoreManager.Instance.AddScore(score);
        Reset();
        GetComponent<Kaichou>().Hit();
    }
}

