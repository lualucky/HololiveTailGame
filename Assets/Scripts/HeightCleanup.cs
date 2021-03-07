using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightCleanup : MonoBehaviour
{
    public float Height;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= Height)
            Destroy(gameObject);
    }
}
