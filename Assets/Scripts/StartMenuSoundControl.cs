using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuSoundControl : MonoBehaviour {

    Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }


    void Update()
    {
        if (!toggle.isOn)
        {
            TurnOffAllSound();
            
        }

        if (toggle.isOn)
        {
            TurnOnTheSound();
          
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

  
}
