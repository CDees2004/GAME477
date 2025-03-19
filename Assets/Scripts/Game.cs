    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using TMPro;

using UnityEngine;
using UnityEngine.Serialization;
using Random =  UnityEngine.Random;


    public class Game : MonoBehaviour
{   
    public static SpaceShooterControls Input { get; private set; }
    private int _score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject healthPowerUpPrefab;
    public GameObject speedPowerUpPrefab;
    private float _powerUpTimer = 0;
    //public int last = 0;  
    public int curr = 0; 
    public int powerUp; //determine which powerup is spawned
    
    public static Game Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    
      //initalize SpaceShooterControls as input

    // Start is called before the first frame update
    void Start() {
        
        Input = new SpaceShooterControls();     //grab input
        Input.Enable(); //enable input assets
        _powerUpTimer = float.MaxValue; //makign sure powerups don't spawn in the main menu

    }

    // Update is called once per frame
    private void Update() {
        if (_powerUpTimer == 0 || (_powerUpTimer == float.MaxValue))
        {
            _powerUpTimer = Random.Range(5f, 12f);
        }
        curr =  (int)Time.time;

        //controls spawning of power ups
        if ((curr - _powerUpTimer) > 0){
            powerUp = Random.Range(0, 1);
            if (powerUp == 0){
                Instantiate(healthPowerUpPrefab);
               _powerUpTimer += Random.Range(5f, 12f);
            }
            if (powerUp == 1){
                Instantiate(speedPowerUpPrefab);
                _powerUpTimer += Random.Range(5f, 12f);
            }
            
        }
        
    }
    

    public void updateScore(int x)
    {
        _score += x;
        scoreText.text = _score.ToString("00000");
    }


    public int getScore()
    {
        return _score;
    }
}

