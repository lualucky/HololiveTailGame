using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaichou : MonoBehaviour
{
    public List<AudioClip> HitSound;
    public List<AudioClip> TauntSound;

    private AudioSource audio;
    private Animator anim;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    public void Hit()
    {
        if (HitSound.Count > 0)
            audio.PlayOneShot(HitSound[Random.Range(0, HitSound.Count)]);
        anim.SetTrigger("Hit");
    }

    public void Taunt()
    {
        if (TauntSound.Count > 0)
            audio.PlayOneShot(TauntSound[Random.Range(0, TauntSound.Count)]);
    }

    public void HitFinish()
    {
        
    }
}
