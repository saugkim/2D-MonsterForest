using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour {

    public float movementSpeed;
    public float jumpForce;

    public GameObject blank;

    Rigidbody2D rb2D;

    public GameObject groundCheck;

    public GameObject c1, c2;

 //   public GameObject playerWeapon1;
 //   private GameObject bullet;
    public GameObject bulletSpawner;
    public float bulletForce;
    public float attackRate = 0.25f;
    float nextAttack;

    public bool grounded;

    int characterChanger;

    public Animator animator1;
    public Animator animator2;


    void Start()
    {
        characterChanger = 1;
        //c1 = GameObject.Find("Player/c1");
        //c2 = GameObject.Find("Player/c2");
        //  rb2D = GetComponentInChildren<Rigidbody2D>();
        rb2D = GetComponent<Rigidbody2D>();
        animator1 = GetComponentInChildren<Animator>();
        animator2 = GetComponentInChildren<Animator>();
        grounded = true;
    }

    void Update()
    {
        PlayerChangeCharacter();
        
        if (characterChanger == 1)
        {
            c1.SetActive(true);
            c2.SetActive(false);

        //    bullet = playerWeapon1;

            float newLocalScale = 1.2f;
            transform.localScale = new Vector2(newLocalScale, newLocalScale);
            PlayerChangeDirection(newLocalScale);

            rb2D.isKinematic = false;
            rb2D.mass = 1;
            rb2D.gravityScale = 1;
            PlayerWalk();
            
            PlayerJump();
        }

        else if (characterChanger == 2)
        {
            c1.SetActive(false);
            c2.SetActive(true);

            float newLocalScale = 0.6f;
            transform.localScale = new Vector2(newLocalScale, newLocalScale);
            PlayerChangeDirection(newLocalScale);

            rb2D.mass = 0;
            rb2D.gravityScale = 0;
//            rb2D.isKinematic = true;

            PlayerFly();

            Vector2 boundaryVector = transform.position;
            boundaryVector.y = Mathf.Clamp(boundaryVector.y, 0, 10f);
        }

        PlayerAttack();
    }

    private void PlayerAttack()
    {
        //bool isMouseOnUIelement;

        //if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < blank.transform.position.x
        //    && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > blank.transform.position.y )
        //{
        //    isMouseOnUIelement = true;
        //}
        //else
        //    isMouseOnUIelement = false;


        if (Input.GetButtonDown("Fire1") && Time.time > nextAttack && GUIUtility.hotControl == 0 && !GameControl.gameControl.PausePopup.activeSelf)
        {
            nextAttack = Time.time + attackRate;
            //GameObject ammo = Instantiate(bullet, bulletSpawner.transform.position, Quaternion.identity);
            //ammo.transform.parent = GameObject.Find("Dynamic").transform;

            GameObject ammo = BulletPooled.instance.GetPooledBullet();
            if(ammo == null)
            {
                return; 
            }
            ammo.transform.position = bulletSpawner.transform.position;
            ammo.transform.rotation = Quaternion.identity;
            ammo.SetActive(true);

            Vector2 bulletDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bulletSpawner.transform.position;
            ammo.GetComponent<Rigidbody2D>().AddForce(bulletDirection * bulletForce * Time.deltaTime, ForceMode2D.Impulse);
            
        }
    }

    public void PlayerChangeCharacter()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (characterChanger == 1)
            {
                characterChanger = 2;
            }
            else if (characterChanger == 2)
            {
                characterChanger = 1;
            }
        }
    }

    private void PlayerFly()
    {
       // animator2.SetTrigger("PlayerFly");

        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        
        transform.Translate(new Vector3(horizontal, vertical, 0));
    }


    private void PlayerWalk()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator1.SetTrigger("PlayerWalk");
            float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
            transform.Translate(new Vector2(horizontal, 0));
            
        }
        else
        {
            animator1.SetTrigger("PlayerIdle");
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            animator1.SetTrigger("PlayerJump");
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
        }

    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }

    private void PlayerChangeDirection(float newLocalScale)
    {
        float absLocalScale = Mathf.Abs(newLocalScale);

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector2(absLocalScale, absLocalScale); 
        }

        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector2(-absLocalScale, absLocalScale);
        }
    }

}

