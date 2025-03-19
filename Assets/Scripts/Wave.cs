using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Wave : MonoBehaviour
{
   
    private Vector3[] _currentPattern;
    private readonly Vector3[] _pattern1 = {
        new Vector3(-2f, 2f, 0f), new Vector3( 0f, 2f , 0f), new Vector3( 2f, 2f , 0), 
        new Vector3(-1f, 1f, 0f),
        new Vector3(1f, 1f, 0f)
    };
    

    private readonly Vector3[] _pattern2 = {
        new Vector3(-2f, 3f, 0f),
        new Vector3(0f, 3f, 0f),
        new Vector3(2f, 3f, 0f),
        new Vector3(-2f, 1f, 0f),
        new Vector3(0f, 1f, 0f),
        new Vector3(2f, 1f, 0f)
    };

    private readonly Vector3[] _pattern3 = {
        new Vector3(-2f, 2f, 0f),
        new Vector3(-1f, 3f, 0f),
        new Vector3(1f, 3f, 0f),
        new Vector3(2f, 2f, 0f),
        new Vector3(-1f, 1f, 0f),
        new Vector3(1f, 1f, 0f)
    };
    
    
    void Start()
    {
        
        
    }

    void Update()
    {
        if (Game.Instance.curr - Game.Instance.last > Game.Instance.respawnTime)
        {
            SpawnWave();
        }
    }
    private void SpawnWave()
    {
        
        switch (Random.Range(1, 3))
        {
            case 1:
                _currentPattern = _pattern1;
                break;
            case 2:
                _currentPattern = _pattern2;
                break;
            case 3:
                _currentPattern = _pattern3;
                break;
        }


        for (int i = 0; i < _currentPattern.GetLength(0); i++)
        {
            var enemy = Instantiate(Game.Instance.enemyPrefab);
            enemy.transform.position = _currentPattern[i];
        }
        
    }
    
}
    
