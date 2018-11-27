using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public AudioClip clip;
    private AudioSource audioSource;

    float minVol = 0.5f;
    float maxVol = 1f;

    public float moveSpeed;

    public GameObject target;

    public float timeBetweenAttacks = 4f;
	
    private Animator animator;

    bool isPlayerInRange;

    bool isPlayerDead;

    public float enemyReactionRange = 20f;
    public float enemyAttackRange = 8f;

    bool isCoroutineStarted = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public virtual void Start () 
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        isPlayerInRange = false;
        isPlayerDead = false;
	}
   
    
    void Update()
    {
        isPlayerDead = GameControl.gameControl.isPlayerDead;
        EnemyMove();  
    }

    
    public void EnemyMove()
    {
        float distance = Mathf.Abs(target.transform.position.x - transform.position.x);

        if (distance >= enemyReactionRange) 
        {
        //    animator.SetTrigger("enemyIdle");
            return;
        }

        else if (distance > enemyAttackRange &&  distance < enemyReactionRange)
        {
         //   animator.SetTrigger("enemyIdle");
            isPlayerInRange = false;
            isCoroutineStarted = false;
            EnemyAction();
           
        }

        else if (distance <= enemyAttackRange )     
        {
            transform.position = transform.position;
            animator.SetTrigger("enemyAttack");

            isPlayerInRange = true;

            if (!isCoroutineStarted)
            {
                StartCoroutine(ReadyToAttack(timeBetweenAttacks));
            }
        }
    }

    IEnumerator ReadyToAttack(float timeBetweenAttacks)
    {
        isCoroutineStarted = true;

        while (isPlayerInRange && !isPlayerDead )
        {
            EnemyAttack();

            float vol = UnityEngine.Random.Range(minVol, maxVol);
            audioSource.PlayOneShot(clip, vol);

            yield return new WaitForSeconds(seconds: timeBetweenAttacks);
        }
    }

    public virtual void EnemyAction()
    {
       
    }

    public virtual void EnemyAttack()
    {
        // animator.SetTrigger(" " )
    }
}





