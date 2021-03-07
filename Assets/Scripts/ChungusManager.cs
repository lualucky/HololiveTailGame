using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChungusManager : MonoBehaviour
{

    public List<Transform> Points;
    public GameObject Chungus;

    public Animator Right;
    public Animator Left;

    public void Trigger(int NumChungus)
    {
        for (int i = 0; i < NumChungus; ++i)
        {
            int p = Random.Range(0, Points.Count);
            Transform pt = Points[p];
            Points.RemoveAt(p);
            GameObject chung = Instantiate(Chungus);
            chung.transform.SetParent(pt);
            chung.transform.localPosition = Vector3.zero;
        }
        Right.SetBool("start", true);
        Left.SetBool("start", true);
    }
}
