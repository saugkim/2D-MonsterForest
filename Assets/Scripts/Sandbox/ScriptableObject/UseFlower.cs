using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFlower : InteractableItems
{
    public Flower item;

    private List<SpriteRenderer> mySprites;


	void Start ()
    {
        mySprites = new List<SpriteRenderer>();

        foreach (Vector2 spawn in item.spawnPoints)
        {
            GameObject mySprite = new GameObject("Flower");
            mySprite.transform.parent = GameObject.Find("Dynamic").transform;

       //     mySprite.tag = "Flower";
            mySprite.AddComponent<SpriteRenderer>();
            mySprite.GetComponent<SpriteRenderer>().sprite = item.openFlower;
            mySprite.GetComponent<SpriteRenderer>().sortingLayerName = "Item";

            mySprite.AddComponent<CapsuleCollider2D>();
            mySprite.GetComponent<CapsuleCollider2D>().isTrigger = true;

            mySprite.AddComponent<FlowerPickup>();
            mySprite.GetComponent<FlowerPickup>().flower = item.openFlower;
            mySprite.GetComponent<FlowerPickup>().flower1 = item.closeFlower;
            mySprite.GetComponent<FlowerPickup>().healthModifier = item.healthModifier;

            mySprite.GetComponent<FlowerPickup>().clip = item.clip;

            mySprite.AddComponent<AudioSource>();
            mySprite.GetComponent<AudioSource>().playOnAwake = false;


            mySprite.transform.position = spawn;

            mySprites.Add(mySprite.GetComponent<SpriteRenderer>());
        }        
    }

    //void Update()
    //{
    //    if (isInteractable)
    //    {
    //        Interact();
    //    }

    //    else
    //    {
    //        foreach (var mySprite in mySprites)
    //        {
    //            isHealthModified = false;
    //            mySprite.sprite = item.openFlower;
    //            if (count >= 3)
    //            {
    //                mySprite.sprite = item.closeFlower;
    //            }
    //        }
            
    //    }
    //}

    //public override void Interact()
    //{
    //    if (!isHealthModified && count < 3)
    //    {
    //        foreach (var mySprite in mySprites)
    //        {
    //            base.Interact();
    //            playerStats.ModifyHealth(item.healthModifier);
    //            count++;
    //            isHealthModified = true;
    //            mySprite.sprite = item.closeFlower;
    //        }
            
    //    }
    //}

}




