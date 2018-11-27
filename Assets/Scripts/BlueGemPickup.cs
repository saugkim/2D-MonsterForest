using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGemPickup :  InteractableItems
{

    public int earningPoint;
   // public float crystalDisappearTime;

    void Start()
    {
    //    playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        earningPoint = 10;
    }

    public override void Interact()
    {
        base.Interact();
        GameControl.gameControl.collectedBlueGem++;
        GameControl.gameControl.EarningScore(earningPoint);
        gameObject.SetActive(false);
    }
}

         