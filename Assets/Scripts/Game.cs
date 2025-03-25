using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using Random =  UnityEngine.Random;


    public class Game : MonoBehaviour
{
    public float _score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextBg; 
    public GameObject healthPowerUpPrefab;
    public GameObject speedPowerUpPrefab;
    public GameObject gameOverScreen;
    public GameObject gameWinScreen;
    public GameObject bossDead; 
    private float _powerUpTimer = float.MaxValue;
    //public int last = 0;  
    public int curr = 0; 
    public int powerUp; //determine which powerup is spawned
    public Boolean gameStarted = false;

    public AudioClip startScreen;
    public AudioClip gameMusic;
    private AudioSource audioSource;

    #region properties
    public static SpaceShooterControls Input { get; private set; }
    public static Game Instance { get; private set; }
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
   

    // Start is called before the first frame update
    void Start() {

        Input = new SpaceShooterControls();     //grab input
        _powerUpTimer = float.MaxValue; //makign sure powerups don't spawn in the main menu
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = startScreen;
        audioSource.Play();

    }

    // Update is called once per frame
    private void Update() {
        if (gameStarted)
        {

            scoreText.text = _score.ToString("00000");
            scoreTextBg.text = _score.ToString("00000");
            
            if (_powerUpTimer == 0 || (_powerUpTimer == float.MaxValue))
            {
                _powerUpTimer = Random.Range(5f, 12f);
            }

            curr = (int)Time.time;

            //controls spawning of power ups

            if ((curr - _powerUpTimer) > 0)
            {
                powerUp = Random.Range(0, 2);
                if (powerUp == 0)
                {
                    Instantiate(healthPowerUpPrefab);

                }
                else if (powerUp == 1)
                {
                    Instantiate(speedPowerUpPrefab);
                }

                _powerUpTimer += Random.Range(5f, 12f);
            }
        }

    }

    public void StartGame(GameObject mainMenuScreen)
    {
        Input.Enable();
        mainMenuScreen.SetActive(false);
        _score = 0;
        gameStarted = true;
        audioSource.Stop();
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    public void ToggleHud(GameObject hud)
    {
        hud.SetActive(!hud.activeSelf);
    }



    public void TogglePauseMenu(GameObject pauseMenu)
    {
        if (pauseMenu.activeSelf)
        {
            Input.Enable();
            Time.timeScale = 1;

        }
        else
        {
            Input.Disable();
            Time.timeScale = 0;
        }
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        
            
    }

    private void WinMenu()
    {
        gameWinScreen.SetActive(true);
        Input.Disable();
        Time.timeScale = 0;
    }




    public void updateScore(float amount)
    {
        _score += amount;
    }


    public float getScore()
    {
        return _score;
    }

    public void Reset()
    {
        Time.timeScale = 1;
        Input.Disable();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win(GameObject g)
    {
        //On win condition 
        Instantiate(bossDead,  g.transform.position, g.transform.rotation).SetActive(true);
        Destroy(g);
        if (true)
        {
            Invoke(nameof(WinMenu), 6f);
        }
    }
    
}

