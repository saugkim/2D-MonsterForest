using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPickup : InteractableItems
{

    public int healthModifier;

 //   PlayerStats playerStats;

    int count;
    public bool isHealthModified;

    SpriteRenderer spriteRenderer;
    public Sprite flower1;
    public Sprite flower;

    // Animator animator;

    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        count = 0;
        isHealthModified = false;
        //   animator = GetComponent<Animator>();
   //     playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (isInteractable)
        {
            Interact();
        }

        else
        {
            isHealthModified = false;
            spriteRenderer.sprite = flower;
            if (count >= 3)
            {
                spriteRenderer.sprite = flower1;
            }
        }

    }

    public override void Interact()
    {
        //animator.SetTrigger
        
        if (!isHealthModified && count < 3)
        {
            base.Interact();
            GameControl.gameControl.ModifyHealth(healthModifier);
//            playerStats.ModifyHealth(healthModifier);
            count++;
            isHealthModified = true;
            spriteRenderer.sprite = flower1;
        }
    }

}
