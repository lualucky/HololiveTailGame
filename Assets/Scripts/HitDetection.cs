using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public bool Last;
    public int Value;

    public bool SlidingScore = false;

    public PolygonCollider2D altCollider;

    private HitManager manager;

    private void Start()
    {
        manager = transform.parent.GetComponent<HitManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Tail obj = other.GetComponent<Tail>();
        if (obj != null)
        {
            int score = Value;
            if(SlidingScore)
            {
                // -- there's something wrong here but idk what
                Bounds oBounds = other.bounds;
                Bounds sBounds = GetComponent<MeshCollider>().bounds;

                Vector2 pt = oBounds.center;
                Vector2 side = altCollider.ClosestPoint(pt);
                
                Vector2 center = sBounds.center;

                Debug.Log("Contact point: " + pt);
                Debug.Log("Side: " + side);
                Debug.Log("Center: " + center);

                Vector2 distFromCenter = pt - center;
                Vector2 sideFromCenter = side - center;
                float per = distFromCenter.magnitude / sideFromCenter.magnitude;
                Debug.Log("Per: " + per + ", center: " + distFromCenter.magnitude + ", side: " + sideFromCenter.magnitude);
                score = Mathf.FloorToInt(per * Value);
            }
            manager.RecieveHit(score, Last, obj);

        }
    }
}
