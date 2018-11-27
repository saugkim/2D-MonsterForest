using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    new public string name = "Item";

    //  public Sprite icon = null;

  //  public AudioClip audioClip;
    public Vector2[] spawnPoints;

    public virtual void Use()
    {
        
    }
	

}
