using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;

    public int curlevel;

    public bool isGameActive = true;
    public bool isPaused = false;

    public HealthManager playerManager;

    public GameObject inGameUI;
    public Image healthBar;
    public TextMeshProUGUI scoreText;

    public GameObject PauseMenu;

    public GameObject background;

    public GameObject mainMenu;

    public GameObject GameOverScreen;

    void Start()
    {
        //playerManager = GameObject.Find("Player").GetComponent<HealthManager>();
    }

    
    void Update()
    {
        UpdateInGameUI();
        Pause();
    }

    public void StartGame(int level, Sprite bg)
    {
        background.gameObject.SetActive(true);
        background.GetComponent<SpriteRenderer>().sprite = bg;
        curlevel = level;

        isGameActive = true;

        playerManager.gameObject.SetActive(true);

        mainMenu.SetActive(false);
        inGameUI.SetActive(true);
    }

    public void LevelOver()
    {
        isGameActive = false;
    }

    public void AddScore(int val)
    {
        score += val;
    }

    public void OnGameStart()
    {
        InitializeGameUI();
    }

    public void InitializeGameUI()
    {
        scoreText.SetText("Score:" + score);
    }

    public void UpdateInGameUI()
    {
        UpdateHealthBar();
        UpdateScoreText();
    }

    public void UpdateHealthBar()
    {
        float val = (float)playerManager.curHP / playerManager.maxHP;
        healthBar.fillAmount = val;
    }

    public void UpdateScoreText()
    {
        scoreText.SetText("Score:" + score);
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            isPaused = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            isPaused = true;
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void BackToMainMenu()
    {
        isPaused = false;
        isGameActive = false;

        playerManager.gameObject.SetActive(false);
        Time.timeScale = 1;

        PauseMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
