using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


//This script Control whole game, control UI and manage the Scene

public class GameControl : MonoBehaviour {


    public Texture onGuiPauseImage;
    public static GameControl gameControl;

    public GateToTheBoss gateToTheBoss;

    EnemyHealth bossHealth;

    public GameObject WinPopup;
    public GameObject LosePopup;
    public GameObject PausePopup;

    public Text numberOfBlueGem;
    public Text numberOfYellowGem;
    public Text numberOfPinkGem;
    public Text numberOfCrystal;

    public bool isPlayerDead = false;
    public bool isEnemyBossDead = false;

    public int totalEnemyinScene;
    public int numberEnemyAlive;

    public bool isPlayerInBossRoom;
    GameObject[] enemies;

    public PlayerStats playerStats;
    public GameObject player;

    public Text scoreBoard;
    public Text enemyKilled;

    [HideInInspector] public int score =0;
    [HideInInspector] public int collectedBlueGem;
    [HideInInspector] public int collectedYellowGem;
    [HideInInspector] public int collectedPinkGem;
    [HideInInspector] public int collectedCrystal;

    public bool gameOver = false;

    public float scrollSpeed = -0.5f;   //Background scrolling speed


    void Awake()
    {
        if (gameControl == null)
        {
            gameControl = this;
        }
        if (gameControl != this)
        {
            Destroy(gameObject);
        }

        Debug.Log(Screen.width + " and height " + Screen.height);
    }

    void Start()
    {
        score = 0;
        collectedCrystal = 0;
        //   DontDestroyOnLoad(this);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemyinScene = enemies.Length;
        gateToTheBoss = GameObject.FindGameObjectWithTag("Gate").GetComponent<GateToTheBoss>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        isPlayerInBossRoom = false;
        bossHealth = GameObject.Find("EnemyBoss").GetComponent<EnemyHealth>();

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect (11, 11, 45, 45), onGuiPauseImage))
        {
            PauseGamePlay();
        }
    }

    void Update()
    {
        isEnemyBossDead = bossHealth.isDead;
      //  Debug.Log(playerStats.currentHealth);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numberEnemyAlive = enemies.Length;

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }


        int countDeadEnemies = totalEnemyinScene - numberEnemyAlive;
        enemyKilled.text = "Count enemies: " + countDeadEnemies;
        scoreBoard.text = "score: " + score;

        numberOfBlueGem.text = collectedBlueGem.ToString();
        numberOfPinkGem.text = collectedPinkGem.ToString();
        numberOfYellowGem.text = collectedYellowGem.ToString();
        numberOfCrystal.text = collectedCrystal.ToString();

        if (isPlayerDead)
        {
            LosePopup.SetActive(true);
        }

        
        if (isEnemyBossDead)
        {
            WinPopup.SetActive(true);
        }

        if(gateToTheBoss.isPlayerInGate)
        {
            player.transform.position = new Vector2(635f, 2f);
         //   SceneManager.LoadScene(2);
            isPlayerInBossRoom = true;
        }
    }

    

    public void StartGamePlay()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadingGamePlay()
    {
        gameOver = true;
        GameReset();
        SceneManager.LoadScene(1);
    }

    private void GameReset()
    {
        isPlayerDead = false;
        isEnemyBossDead = false;
        numberEnemyAlive = totalEnemyinScene;
        playerStats.currentHealth = playerStats.maxHealth;
        WinPopup.SetActive(false);
        LosePopup.SetActive(false);
    }

    public void QuitGamePlay()
    {
        Application.Quit();
    }

    public void PauseGamePlay()
    {
        Time.timeScale = 0;
        PausePopup.SetActive(true);
    }

    public void ResumeGamePlay()
    {
        PausePopup.SetActive(false);
        Time.timeScale = 1;
    }


    public void OpenOptionMenu()
    {
        SceneManager.LoadScene(2);

    }

    public void EarningScore(int point)
    {
        score += point;
    }

    public void ModifyHealth(int point)
    {
        playerStats.currentHealth += point;
    }


}
