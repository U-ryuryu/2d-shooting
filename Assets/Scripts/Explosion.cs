using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip boomSE;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(boomSE);
        Destroy(gameObject, 0.5f);
    }
}
