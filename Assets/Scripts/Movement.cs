using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GameObject Tail;
    public Image ChargeBar;

    public float Speed;
    public float Force;
    public Vector3 Throw;

    public float MaxCharge;
    public float ChargeRate;

    private Rigidbody rigid;

    private bool loaded;
    private float charge;

    private Tail manager;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rigid = Tail.GetComponent<Rigidbody>();
        rigid.isKinematic = true;
        loaded = true;
        charge = -1f;
        ChargeBar.fillAmount = 0;
        manager = Tail.GetComponent<Tail>();
        sprite = Tail.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // -- left/right
        if(loaded && Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon) {
            transform.position = transform.position + new Vector3(Speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
        }

        // -- fire
        if(Input.GetButtonDown("Fire"))
        {
            charge = 0f;
        }
        if (loaded && Input.GetButton("Fire"))
        {
            ChargeBar.fillAmount = charge / MaxCharge;
            charge = (charge + (Time.deltaTime * ChargeRate)) % MaxCharge;
        }
        else if (Input.GetButtonUp("Fire"))
        {
            if (charge > 0f)
                Fire();
            charge = -1f;
        }

        // -- respawn
        if (sprite.enabled && Tail.transform.position.y < -1)
            manager.Reset();
    }

    void Fire()
    {
        loaded = false;
        rigid.isKinematic = false;
        rigid.AddForce(Throw * Force * charge);
        Tail.transform.SetParent(null);
    }

    public void Reload()
    {
        Tail.transform.SetParent(transform);
        loaded = true;
        rigid.isKinematic = true;
        Tail.transform.position = transform.position;
        ChargeBar.fillAmount = 0;
    }
}
