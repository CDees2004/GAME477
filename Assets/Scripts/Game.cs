    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using TMPro;

using UnityEngine;
    using Random =  UnityEngine.Random;


    public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private int _score = 0;
    TextMeshProUGUI _scoreText;
    Slider _healthSlider;
    
    private int _health = 10;
    private int _respawnTime = 3;
    
    
    public GameObject enemyPrefab;
    private Vector3 _eSpawnVector = new Vector3(5, 0, 0);
    int _last = 0;
    int _curr = 0; 
    public static SpaceShooterControls Input { get; private set; }  //initalize SpaceShooterControls as input

    // Start is called before the first frame update
    void Start() {
        Input = new SpaceShooterControls();     //grab input
        Input.Enable(); //enable input assets

    }

    // Update is called once per frame
    private void Update() {
        _curr =  (int)Time.time;
        
        print(_score);
        print("Score");
        print(_health);
        print("Health");

        if (_curr - _last > _respawnTime)
        {
            int randomNumber = Random.Range(-4, 5);//Controls spawning along Y axis
            _last = _curr;
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(8, randomNumber, 0);
        }

        if (_health <= 0)
        {
            #if UNITY_STANDALONE
                Application.Quit();
            #endif
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

    public void updateHealth(int x)
    {
        _health += x;
        _healthSlider.value = _health;
        
    }

    public void updateScore(int x)
    {
        _score += x;
        _scoreText.text = _score.ToString("00000");
    }

    public int getHealth()
    {
        return _health;
    }

    public int getScore()
    {
        return _score;
    }
}

