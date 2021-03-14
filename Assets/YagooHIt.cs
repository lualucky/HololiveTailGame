using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YagooHIt : MonoBehaviour
{
    List<AudioClip> HitSounds;
    private void OnTriggerEnter(Collider other)
    {
        Tail obj = other.GetComponent<Tail>();
        if (obj != null)
        {
            LevelManager.Instance.Lose();
            if (HitSounds.Count > 0)
                GetComponent<AudioSource>().PlayOneShot(HitSounds[Random.Range(0, HitSounds.Count)]);
        }
    }
}
