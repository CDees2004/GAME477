using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Wave : MonoBehaviour
{
    private int _respawnTime = 3;
    public GameObject enemyPrefab;
    private int _last = 0;  
    private int _curr = 0; 
   
    private Vector3[] _currentPattern;
    private readonly Vector3[] _pattern1 = {
        new Vector3(5f, 2f, 0f), new Vector3( 5f, 3f , 0f), new Vector3( 5f, 0f , 0), 
        new Vector3(5f, -1f, 0f),
        new Vector3(5f, -2f, 0f)
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
        _curr =  (int)Time.time;
        if (_curr - _last > _respawnTime)
        {
            SpawnWave();
            _last = _curr;
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
            print(i);
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = _currentPattern[i];
        }
        
    }
    
}
    
