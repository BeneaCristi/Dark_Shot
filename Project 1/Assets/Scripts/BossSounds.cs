using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSounds : MonoBehaviour
{
    private AudioSource source;

    public AudioClip[] clips;

    public float TimeBetweenEffects;
    private float nextEffect;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Time.time >= nextEffect)
        {
            int rand = Random.Range(0, clips.Length);
            source.clip = clips[rand];
            source.Play();
            nextEffect = Time.time + TimeBetweenEffects;
        }
       
    }
}
