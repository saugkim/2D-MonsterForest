using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGemPickup : InteractableItems {

  //  PlayerStats playerStats;
    public int earningPoint;

    GameObject[] traps;
    public float inRangeBetweenYellowGemAndTrap;

    void Start()
    {
        traps = GameObject.FindGameObjectsWithTag("Trap");
    //    playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        earningPoint = 20;
    }

    void Update()
    {
        if (GameControl.gameControl.gameOver)
        {
            gameObject.SetActive(true);
        }

        if (isInteractable)
        {
            Interact();
        }
    }

    public override void Interact()
    {
        base.Interact();
        GameControl.gameControl.collectedYellowGem++;
        GameControl.gameControl.EarningScore(earningPoint);
        gameObject.SetActive(false);
        RemoveObstacle();
    }

    public void RemoveObstacle()
    {
        foreach (var trap in traps)
        {
            float distance = Mathf.Abs(trap.transform.position.x - transform.position.x);
            if(distance < inRangeBetweenYellowGemAndTrap)
            {
                trap.SetActive(false);
            }
        }
    }

}
