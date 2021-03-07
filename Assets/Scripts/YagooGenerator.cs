using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YagooGenerator : MonoBehaviour
{
    public float MinTime;
    public float MaxTime;

    public GameObject YagooPrime;

    public List<Transform> SpawnPoints;

    public float MinForce;
    public float MaxForce;

    private float timer;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        spawnTime = Random.Range(MinTime, MaxTime) + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            timer = 0f;
            Spawn();
            spawnTime = Random.Range(MinTime, MaxTime);
        }
    }

    void Spawn ()
    {
        GameObject goo = Instantiate(YagooPrime);
        Transform pt = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
        goo.transform.position = pt.position;
        float force = Random.Range(MinForce, MaxForce);
        goo.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, force));
    }
}
