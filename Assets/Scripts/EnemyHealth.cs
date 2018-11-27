using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public AudioClip dieClip;
    public AudioClip hitClip;
    private AudioSource audioSource;
    float minVol = 0.5f;
    float maxVol = 1f;

    public GameObject pinkGem;
    public int maximumHealth;
    public int currentHealth;

    public float enemyDisappearTimeWhenDie;

    public int damageFromPlayer;

    public bool isDead;

    bool isPinkInstantiated;

    Animator animator;

//    public string stateNameOfAnimator;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
  //      audioSource.playOnAwake = false;
    }
    void Start()
    {
        currentHealth = maximumHealth;
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SmallRock"))
        {
            damageFromPlayer = 10;
            other.gameObject.SetActive(false);
//            Destroy(other.gameObject);
            TakeDamage(damageFromPlayer);
        }

        if (other.gameObject.CompareTag("BigRock"))
        {
            damageFromPlayer = 20;
            Destroy(other.gameObject);
            TakeDamage(damageFromPlayer);
        }
    }

    private void TakeDamage(int damage)
    {
        float vol = Random.Range(minVol, maxVol);
        audioSource.PlayOneShot(hitClip, vol);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            bool isStarted = false;

            if (!isStarted && !isDead)
            {
                StartCoroutine(EnemyDie());
                isStarted = true;
            }
            isStarted = true;
        }
    }

    IEnumerator EnemyDie()
    {
        gameObject.GetComponent<EnemyFlip>().enabled = false;

      //  animator.SetTrigger("enemyDie");
        PlayDieEffect();
        animator.Play("die");
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("die") )
        {
            //Wait every frame until animation has finished
            yield return null;
        }
        yield return new WaitForSeconds(seconds: enemyDisappearTimeWhenDie);
        InstantiateGem();
        Destroy(gameObject);
        isDead = true;
    }
    //private void EnemyDie()
    //{
    //    Debug.Log("Dead");
    //    animator.SetTrigger("enemyDie");
    //    PlayDieEffect();
    //    if (animator.GetCurrentAnimatorStateInfo(0).IsName("die"))
    //    {
            
    //    }
    //    PlayDieEffect();

    //    InstantiateGem();
    //    Destroy(gameObject, t: enemyDisappearTimeWhenDie);
        

    //}

    public void InstantiateGem()
    {
        if (!isPinkInstantiated)
        {
            GameObject obj = Instantiate(pinkGem, transform.position, Quaternion.identity);
            obj.transform.parent = GameObject.Find("Dynamic").transform;

            isPinkInstantiated = true;
        }

    }

    public void PlayDieEffect()
    {
        float vol = Random.Range(minVol, maxVol);
        audioSource.PlayOneShot(dieClip, vol);
    }
}
