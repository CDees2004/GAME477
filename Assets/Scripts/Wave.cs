using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Wave : MonoBehaviour
{
    private float _respawnTime = 3f;
    public GameObject enemyPrefab;
    private int _last = 0;  
    private int _curr = 0;
    private bool _isEnabled = false;
    private Vector3[] _currentPattern;
    private readonly Vector3[] _pattern1 = {
        new Vector3(11f, -3f, 0f), 
        new Vector3(11f, 3f , 0f), 
        new Vector3(12f, 2f , 0f), 
        new Vector3(12f, -2f, 0f),
        new Vector3(13f, 1f, 0f),
        new Vector3(13f, -1f, 0f)
    };
    

    private readonly Vector3[] _pattern2 = {
        new Vector3(13f, -3f, 0f), 
        new Vector3(13f, 3f , 0f), 
        new Vector3(12f, 2f , 0f), 
        new Vector3(12f, -2f, 0f),
        new Vector3(11f, 1f, 0f),
        new Vector3(11f, -1f, 0f)
    };

    private readonly Vector3[] _pattern3 = {
        new Vector3(10f, -4f, 0f),
        new Vector3(10f, -3f, 0f),
        new Vector3(10f, -2f, 0f),
        new Vector3(10f, -1f, 0f),
        new Vector3(10f, 0f, 0f),
        new Vector3(10f, 1f, 0f),
        new Vector3(10f, 2f, 0f),
        new Vector3(10f, 3f, 0f),
        new Vector3(10f, 4f, 0f)
    };
    
    
    void Start()
    {

    }

    void Update()
    {
        if (_isEnabled)
        {
            _curr = (int)Time.time;
            if (_curr - _last > _respawnTime)
            {
                SpawnWave();
                _last = _curr;
                _respawnTime = Random.Range(1f, 3f);
            }
        }
    }
    private void SpawnWave()
    {
        
        switch (Random.Range(1, 4))
        {
            case 1:
                print("Wave 1");
                _currentPattern = _pattern1;
                break;
            case 2:
                print("Wave 2");
                _currentPattern = _pattern2;
                break;
            case 3:
                print("Wave 3");
                _currentPattern = _pattern3;
                break;

        }


        for (int i = 0; i < _currentPattern.Length; i++)
        {
            Instantiate(enemyPrefab).transform.position = _currentPattern[i];
        }
        _currentPattern = null;

        

    }

    public void Enable()
    {
        _isEnabled = true;
    }
}
    
