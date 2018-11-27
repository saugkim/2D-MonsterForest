using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    EnemyHealth health;
    public float moveSpeed;

    public GameObject target;
    public GameObject caveRock;

    public Vector2 rightCornerPosition;
    public Vector2 leftCornerPosition;

    public float rockDisappearTime;

    private Animator animator;

    public bool isPlayerDead;

    public bool isPlayerInScene;

    public bool isBossCanWalk = false;

    bool isCoroutineStarted = false;

    public void Start()
    {
        health = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");
        isPlayerDead = false;
        isPlayerInScene = false;
        isCoroutineStarted = false;
        isBossCanWalk = false;

    }

    void Update()
    {
        isPlayerDead = GameControl.gameControl.isPlayerDead;
        isPlayerInScene = GameControl.gameControl.isPlayerInBossRoom;

        if (GameControl.gameControl.isPlayerInBossRoom && !isCoroutineStarted)
        {
            StartCoroutine(ActionStart());
        }

        if (isBossCanWalk && health.currentHealth > 0 )
        {
            BossWalk();
        }
    }

    private IEnumerator ActionStart()
    {
        isBossCanWalk = true;
        yield return null;
        moveSpeed = 2f;
        isCoroutineStarted = true;
    }

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "CornerBox" && isPlayerInScene && !health.isDead)
        {
            TurnXDirection();
            isBossCanWalk = false;
            moveSpeed = 0f;
            yield return new WaitForSeconds(1);
           
            animator.SetTrigger("LaserAttack");
            yield return new WaitForSeconds(1);
            CaverocksDrop();
            yield return new WaitForSeconds(1);

            isBossCanWalk = true;
        }


        if (other.gameObject.tag == "CenterBox" && isPlayerInScene && !health.isDead)
        {
            isBossCanWalk = false;
            moveSpeed = 0f;
            animator.SetTrigger("JumpAttack");
            yield return new WaitForSeconds(2);
            CaverocksDrop();
            animator.SetTrigger("BellyAttack");
            yield return new WaitForSeconds(4);
            animator.SetTrigger("LaserAttack");
            yield return new WaitForSeconds(1);
            CaverocksDrop();

            isBossCanWalk = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            TurnXDirection();
        }
    }

    public void TurnXDirection()
    {
        float x = transform.localScale.x; 
        float y = transform.localScale.y;

        transform.localScale = new Vector2(-x, y);
    }

    private void BossWalk()
    {
        animator.SetTrigger("Walk");
        
        moveSpeed = 2f;
        float speed = moveSpeed;

        if(transform.localScale.x >= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, leftCornerPosition, speed * Time.deltaTime);
        }
    
        else 
        {
            transform.position = Vector2.MoveTowards(transform.position, rightCornerPosition, speed * Time.deltaTime);
        }       
    }

    private void CaverocksDrop()
    {
        int spawningAmount = 10;
        GameObject[] rocks = new GameObject[spawningAmount];

        for (int i = 0; i < spawningAmount; i++)
        {
            float x = UnityEngine.Random.Range(635f, 660f);
            float y = UnityEngine.Random.Range(16f, 18f);
            rocks[i] = Instantiate(caveRock, new Vector2(x, y), Quaternion.identity);

            Destroy(rocks[i], t: rockDisappearTime);
        }
    }
}