using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour {

  //  GameObject soundEffect;
    AudioSource audioSource;
    public Toggle toggle;

    void Awake()
    {
  //      soundEffect = GameObject.Find("Effect/Sound/AudioPlayer");
        audioSource = GameObject.Find("Effect").GetComponentInChildren<AudioSource>();

    }

    void Start()
    {
        toggle = GetComponentInChildren<Toggle>();
    }


    void Update()
    {

        if (!toggle.isOn)
        {
            MusicOn();
        }

        if (toggle.isOn)
        {
            MusicOff();
        }
    }

    public void MusicOff()
    {
        audioSource.mute = true;
      
    }

    public void MusicOn()
    {
        audioSource.mute = false;

    }
}
