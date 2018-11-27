using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {
    EnemyHealth health;
    public float moveSpeed;

    public GameObject caveRock;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform spawnPoint5;
    public Transform spawnPoint6;

    public Vector2 rightCornerPosition;
    public Vector2 leftCornerPosition;

    public float rockDisappearTime;

    private Animator animator;

    bool isBossAtCenter;
    bool isBossAtCorner;

    public bool isPlayerDead;

    public bool isPlayerInScene;

    public bool isBossCanWalk = true;

    bool isCoroutineStarted = false;

    public float absLocalScaleX;

    public void Start()
    {
        health = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
        absLocalScaleX = Mathf.Abs(transform.localScale.x);

        isPlayerDead = false;
        isPlayerInScene = false;
        isCoroutineStarted = false;
    }

    void Update()
    {
        isPlayerDead = GameControl.gameControl.isPlayerDead;
        isPlayerInScene = GameControl.gameControl.isPlayerInBossRoom;

        if (GameControl.gameControl.isPlayerInBossRoom && !isCoroutineStarted)
        {
            StartCoroutine(Action());
            isCoroutineStarted = true;
        }

    }

    private IEnumerator Action()
    {
        isCoroutineStarted = true;
        
        while (!isPlayerDead && !health.isDead)
        {  
            isBossCanWalk = true;
            moveSpeed = 2f;

            BossWalk();

            if(isBossAtCenter)
            {
                isBossCanWalk = false;
                moveSpeed = 0f;
                animator.SetTrigger("JumpAttack");
                yield return new WaitForSeconds(2);
                CaverocksDrop();
                animator.SetTrigger("BellyAttack");
                yield return new WaitForSeconds(4);

                isBossCanWalk = true;

            }

            moveSpeed = 2f;
            BossWalk();

            if(isBossAtCorner)
            {
                transform.localScale = new Vector2(-absLocalScaleX, transform.localScale.y);
                moveSpeed = 0f;
                isBossCanWalk = false;
                animator.SetTrigger("LaserAttack");
                yield return new WaitForSeconds(1);
                CaverocksDrop();
                yield return new WaitForSeconds(1);

                isBossCanWalk = true;
            }

            moveSpeed = 2f;
            BossWalk();

            if (isBossAtCenter)
            {
                isBossCanWalk = false;
                moveSpeed = 0f;
                animator.SetTrigger("JumpAttack");
                yield return new WaitForSeconds(2);
                CaverocksDrop();
                animator.SetTrigger("BellyAttack");
                yield return new WaitForSeconds(4);

                isBossCanWalk = true;

            }

            moveSpeed = 2f;
            BossWalk();

            if (isBossAtCorner)
            {
                transform.localScale = new Vector2(absLocalScaleX, transform.localScale.y);
                moveSpeed = 0f;
                isBossCanWalk = false;
                animator.SetTrigger("LaserAttack");
                yield return new WaitForSeconds(1);
                CaverocksDrop();
                yield return new WaitForSeconds(1);

                isBossCanWalk = true;
            }
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CornerBox" )
        {
            isBossAtCorner = true;
            isBossCanWalk = false;
        }


        if (other.gameObject.tag == "CenterBox" )
        {
            isBossAtCenter = true;
            isBossCanWalk = false;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CornerBox")
        {
            isBossAtCorner = false;
        }

        if (other.gameObject.tag == "CenterBox")
        {
            isBossAtCenter = false;

        }
    }

    
    private void BossWalk()
    {
        if (isBossCanWalk)
        {
            animator.SetTrigger("Walk");

            moveSpeed = 2f;
            float speed = moveSpeed;

            if (transform.localScale.x > 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, leftCornerPosition, speed * Time.deltaTime);
            }
            else if (transform.localScale.x < 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, rightCornerPosition, speed * Time.deltaTime);
            }
        }
       
    }

    private void CaverocksDrop()
    {
        GameObject rock1 = Instantiate(caveRock, spawnPoint1.position, spawnPoint1.rotation);
        GameObject rock2 = Instantiate(caveRock, spawnPoint2.position, spawnPoint2.rotation);
        GameObject rock3 = Instantiate(caveRock, spawnPoint3.position, spawnPoint3.rotation);
        GameObject rock4 = Instantiate(caveRock, spawnPoint4.position, spawnPoint4.rotation);
        GameObject rock5 = Instantiate(caveRock, spawnPoint5.position, spawnPoint5.rotation);
        GameObject rock6 = Instantiate(caveRock, spawnPoint6.position, spawnPoint6.rotation);

        Destroy(rock1, t: rockDisappearTime);
        Destroy(rock2, t: rockDisappearTime);
        Destroy(rock3, t: rockDisappearTime);
        Destroy(rock4, t: rockDisappearTime);
        Destroy(rock5, t: rockDisappearTime);
        Destroy(rock6, t: rockDisappearTime);
    }

}