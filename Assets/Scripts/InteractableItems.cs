using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour {

    public AudioClip clip;
    AudioSource audioSource;
    float minVol = 0.5f;
    float maxVol = 1f;

    public bool isInteractable;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource = GetComponentInParent<AudioSource>();
     //   audioSource.playOnAwake = false;
        
    }

    void Update ()
    {
        if (isInteractable)
        {
            Interact();
        }   
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            float vol = Random.Range(minVol, maxVol);
            audioSource.PlayOneShot(clip, vol);
            isInteractable = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            isInteractable = false;
        }
    }

    public virtual void Interact()
    {
        
    }

    
}
