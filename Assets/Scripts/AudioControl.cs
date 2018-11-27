using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {

    public AudioClip[] clips;
    public AudioSource[] audioSources;

    void Awake()
    {
        audioSources = GetComponents<AudioSource>();
        foreach (var item in audioSources)
        {
            item.playOnAwake = false;
        }

    }

    
}
