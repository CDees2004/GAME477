    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using Random =  UnityEngine.Random;


    public class Game : MonoBehaviour
{
    public static int Score = 0;
    public static int Health = 10;
    public static int RespawnTime = 3;
    public GameObject enemyPrefab;
    private Vector3 _eSpawnVector = new Vector3(5, 0, 0);
    int last = 0;
    int curr = 0; 
    public static SpaceShooterControls Input { get; private set; }  //initalize SpaceShooterControls as input

    // Start is called before the first frame update
    void Start() {
        Input = new SpaceShooterControls();     //grab input
        Input.Enable(); //enable input assets

    }

    // Update is called once per frame
    private void Update() {
        curr =  (int)Time.time;
        print(Score);
        print("Score");
        
        print(Health);
        print("Health");

        if (curr - last > RespawnTime)
        {
            int randomNumber = Random.Range(-4, 5);//Controls spawning along Y axis
            last = curr;
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(8, randomNumber, 0);
        }

        if (Health <= 0)
        {
            #if UNITY_STANDALONE
                Application.Quit();
            #endif
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}

