using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Crystal", menuName = "Item/Flower")]
public class Flower : Item
{ 
    public int healthModifier;

    public AudioClip clip;
    public Sprite openFlower;
    public Sprite closeFlower;


    void Start()
    {
       
    }

    public override void Use()
    {
        base.Use();
//        PlayerStats.playerInfo.ModifyHealth(healthModifier);
    }
  
}
