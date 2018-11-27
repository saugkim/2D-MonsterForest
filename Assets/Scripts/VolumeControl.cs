using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeControl : MonoBehaviour {

    
    Toggle toggle;

	void Start () {
        toggle = GetComponentInChildren<Toggle>();
	}
	

	void Update () {

		if(!toggle.isOn)
        {
            TurnOnTheSound();
        }

        if (toggle.isOn)
        {
            TurnOffAllSound();
        }
	}
    
    private void TurnOnTheSound()
    {
        AudioListener.volume = 1;
    }

    public void TurnOffAllSound()
    {
       // AudioListener.pause = true;


        AudioListener.volume = 0;
    }

    public void ReturnToTheScene()
    {
        SceneManager.LoadScene(0);
    }

    
}
