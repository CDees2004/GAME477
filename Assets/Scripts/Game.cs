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
    private float score;
    public TextMeshProUGUI scoreText;
    public GameObject healthPowerUpPrefab;
    public GameObject speedPowerUpPrefab;
    private float _powerUpTimer = 0;
    //public int last = 0;  
    public int curr = 0; 
    public int powerUp; //determine which powerup is spawned

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
        Instance = this;
        Input = new SpaceShooterControls();     //grab input
        _powerUpTimer = float.MaxValue; //makign sure powerups don't spawn in the main menu


    }

    // Update is called once per frame
    private void Update() {
        scoreText.text = score.ToString("00000");

        if (_powerUpTimer == 0 || (_powerUpTimer == float.MaxValue))
        {
            _powerUpTimer = Random.Range(5f, 12f);
        }
        curr =  (int)Time.time;

        //controls spawning of power ups
        if ((curr - _powerUpTimer) > 0){
            powerUp = Random.Range(0, 2);
            if (powerUp == 0){
                Instantiate(healthPowerUpPrefab);
                
            }
            else if (powerUp == 1){
                Instantiate(speedPowerUpPrefab);
            }
            _powerUpTimer += Random.Range(5f, 12f);
        }
        
    }

    public void StartGame(GameObject mainMenuScreen)
    {
        Input.Enable();
        mainMenuScreen.SetActive(false);
        score = 0;
    }


    public void updateScore(float amount)
    {
        score += amount;
    }


    public float getScore()
    {
        return score;
    }
}

