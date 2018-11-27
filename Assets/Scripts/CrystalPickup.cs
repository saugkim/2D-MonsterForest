using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : InteractableItems
{
    public int earningPoint;
    public float crystalDisappearTime;

    void Start()
    {

    }


    public override void Interact()
    {
        base.Interact();
        GameControl.gameControl.collectedCrystal++;
        GameControl.gameControl.score += earningPoint;
        Destroy(gameObject, t: crystalDisappearTime);
    }
}

