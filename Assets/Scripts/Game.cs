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
    private float _score;
    public TextMeshProUGUI scoreText;
    public GameObject healthPowerUpPrefab;
    public GameObject speedPowerUpPrefab;
    private float _powerUpTimer = float.MaxValue;
    //public int last = 0;  
    public int curr = 0; 
    public int powerUp; //determine which powerup is spawned
    public Boolean gameStarted = false;
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
        

    }

    // Update is called once per frame
    private void Update() {
        if (gameStarted)
        {
            scoreText.text = _score.ToString("00000");

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
        GetComponent<AudioSource>().Play();
    }

    public void ToggleHud(GameObject hud)
    {
        hud.SetActive(!hud.activeSelf);
    }


    public void updateScore(float amount)
    {
        _score += amount;
    }


    public float getScore()
    {
        return _score;
    }
}

