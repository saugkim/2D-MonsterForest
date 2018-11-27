using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJelly : Enemy
{
    SpriteRenderer spriteRenderer;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
    } 

  //  public GameObject target2;

    public override void EnemyAction()
    {
        float speed = moveSpeed;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public override void EnemyAttack()
    {
        base.EnemyAttack();
    }
}

