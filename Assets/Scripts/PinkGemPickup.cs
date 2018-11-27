using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkGemPickup : InteractableItems {

//    PlayerStats playerStats;
    public int earningPoint;

    bool isCollected;
    // public float crystalDisappearTime;

    void Start()
    {

        earningPoint = 50;
        isCollected = false;
    }

    public override void Interact()
    {
        base.Interact();
        if (!isCollected)
        {
            GameControl.gameControl.collectedPinkGem++;
            GameControl.gameControl.EarningScore(earningPoint);
            isCollected = true;
        }
        Destroy (gameObject, 0.5f);
    }
}
