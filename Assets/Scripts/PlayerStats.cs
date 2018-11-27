using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public GameObject rootObject;
    GameControl gameControl;
 
    public int maxHealth;
    public int currentHealth;

    HealthBarController slider;

    [HideInInspector] public int eanrningPoint;

    public GameObject c1, c2;

    [HideInInspector]  public int damageFromEnemy;
    // public int damageFromPumpking;
    [HideInInspector]  public int damageFromObstacle;

    public bool isDead;

    public Animator animator1, animator2;

    [HideInInspector] public int numberOfCrystal;


    void Awake()
    {
        slider = GameObject.Find("HealthSlider").GetComponent<HealthBarController>();

    }
    void Start()
    {
        animator1 = GetComponentInChildren<Animator>();
        animator2 = GetComponentInChildren<Animator>();
        c1 = GameObject.Find("Player/c1");
        c2 = rootObject.transform.Find("c2").gameObject;
      //  c2 = GameObject.Find("Player/c2");
        isDead = false;
        currentHealth = maxHealth;
        numberOfCrystal = 0;
    }

    void Update()
    {
        slider.healthValue = currentHealth;
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Enemy") 
        {
            damageFromEnemy = 5;
            TakeDamage(damageFromEnemy);
            Debug.Log("CollisionwithEnemy");
        }
        if (other.gameObject.tag == "EnemyPumpking")
        {
            damageFromEnemy = 10;
            TakeDamage(damageFromEnemy);
            Debug.Log("CollisionwithEnemy");
        }

        if (other.gameObject.tag == "Trap")
        {
            damageFromObstacle = 10;
            TakeDamage(damageFromObstacle);
            Debug.Log("CollisionWithTarp");
        }

        if (other.gameObject.tag == "Trap2")
        {
            damageFromObstacle = 5;
            TakeDamage(damageFromObstacle);
            Debug.Log("CollisionWithTarp");
        }

        if (other.gameObject.tag == "caveRock")
        {
            damageFromEnemy = 5;
            TakeDamage(damageFromEnemy);
            Debug.Log("CollisionWithCaveRocks");
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap3")
        {
            damageFromObstacle = 50;
            TakeDamage(damageFromObstacle);
            Debug.Log("CollisionWithTarp");
        }

        //if (other.gameObject.tag == "YellowGem")
        //{
        //    eanrningPoint = 20;
        //    GameControl.gameControl.collectedYellowGem++;
        //    EarningScore(eanrningPoint);
        ////    other.gameObject.SetActive(false);
        //}
       

        if (other.gameObject.tag == "Crystal")
        {
            eanrningPoint = 100;
            GameControl.gameControl.collectedCrystal++;
            EarningScore(eanrningPoint);
            other.gameObject.SetActive(false);
        }
    }


    public void ModifyHealth(int healthModifier) 
    {
        currentHealth += healthModifier;
    }
    
    public void EarningScore(int point)
    {
        GameControl.gameControl.score += point;
    }

    public void TakeDamage(int damage)
    {
 
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
            isDead = true;           
        }
    }

    private void Die()
    {
        //animator1.SetTrigger("PlayerDie");
        //animator2.SetTrigger("PlayerDie");
        if (c1.activeSelf)
        {
            Debug.Log("c1 dead");
            animator1.SetTrigger("PlayerDie");
        }

        if(c2.activeSelf)
        {
            Debug.Log("c2 dead");
            animator2.SetTrigger("PlayerDie");
        }

        Invoke("GameEnd", 2);
    }

    private void GameEnd()
    { 
        gameObject.SetActive(false);
        GameControl.gameControl.isPlayerDead = true;
    }
}
