﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public Sprite UpSprite;
    public Sprite MidSprite;
    public Sprite TopSprite;
    public Sprite DownSprite;

    public Movement player;

    private Rigidbody rigid;
    private SpriteRenderer sprite;
    private Animator anim;

    bool successfulHit = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rigid.isKinematic)
        {
            float vel = rigid.velocity.y;
            if (vel < .2f && sprite.sprite == UpSprite)
                sprite.sprite = MidSprite;
            if (vel < .1f && sprite.sprite == MidSprite)
                sprite.sprite = TopSprite;
            if (vel < 0 && sprite.sprite == TopSprite)
                sprite.sprite = DownSprite;
        }
    }

    public void Reset()
    {
        sprite.sprite = UpSprite;
        player.GetComponent<Movement>().Reload();
        LevelManager.Instance.Hit(successfulHit);
        successfulHit = false;
    }

    public void Hit()
    {
        successfulHit = true;
        anim.SetTrigger("Hit");
    }
}
