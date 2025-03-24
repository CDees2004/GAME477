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
    private int _last = 0;  
    private int _curr = 0;
    private bool _isEnabled = false;
    private Vector3[] _currentPattern;
    private readonly List<Vector3[]> _patterns = new List<Vector3[]>();
    public  List<GameObject> enemies = new List<GameObject>();
    
    

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
    
    private readonly Vector3[] _pattern4 = {
        new Vector3(10f, -4f, 0f),
        new Vector3(11f, -3f, 0f),
        new Vector3(12f, -2f, 0f),
        new Vector3(13f, -1f, 0f),
        new Vector3(14f, 0f, 0f),
        new Vector3(13f, 1f, 0f),
        new Vector3(12f, 2f, 0f),
        new Vector3(11f, 3f, 0f),
        new Vector3(10f, 4f, 0f)
    };
    
    private readonly Vector3[] _pattern5 = {
        new Vector3(14f, -4f, 0f),
        new Vector3(13f, -3f, 0f),
        new Vector3(12f, -2f, 0f),
        new Vector3(11f, -1f, 0f),
        new Vector3(10f, 0f, 0f),
        new Vector3(11f, 1f, 0f),
        new Vector3(12f, 2f, 0f),
        new Vector3(13f, 3f, 0f),
        new Vector3(14f, 4f, 0f)
    };
    private readonly Vector3[] _pattern6 = {
        new Vector3(11f, -2f, 0f),
        new Vector3(11f, -1f, 0f),
        new Vector3(12f, 0f, 0f),
        new Vector3(12f, 1f, 0f),
        new Vector3(13f, 2f, 0f),
        new Vector3(13f, 3f, 0f),

    };
    private readonly Vector3[] _pattern7 = {
        new Vector3(11f, -1f, 0f),
        new Vector3(10f, -1f, 0f),
        new Vector3(11f, 0f, 0f),
        new Vector3(10f, 0f, 0f),
        new Vector3(11f, 1f, 0f),
        new Vector3(10f, 1f, 0f),
    };
    private readonly Vector3[] _pattern8 = {
        new Vector3(9f, 0f, 0f),
        new Vector3(10f, 0f, 0f),
        new Vector3(11f, 0f, 0f),
        new Vector3(12f, 0f, 0f),
        new Vector3(13f, 0f, 0f),
        new Vector3(14f, 0f, 0f),
        new Vector3(15f, 0f, 0f),
        new Vector3(16f, 0f, 0f),
        new Vector3(17f, 0f, 0f)
    };
    private readonly Vector3[] _pattern9 = {
        new Vector3(9f, 1f, 0f),
        new Vector3(10f, 1f, 0f),
        new Vector3(10f, 2f, 0f),
        new Vector3(9f, 2f, 0f),
        new Vector3(9f, 1f, 0f),
    };
    private readonly Vector3[] _pattern10 = {
        new Vector3(9f,  0f, 0f),
        new Vector3(10f, 1f, 0f),
        new Vector3(11f, 2f, 0f),
        new Vector3(12f, 3f, 0f),
        new Vector3(13f, 4f, 0f),
        new Vector3(14f, 3f, 0f),
        new Vector3(15f, 2f, 0f),
        new Vector3(16f, 1f, 0f),
        new Vector3(17f, 0f, 0f),
    };
    
    void Start()
    {
        _patterns.Add(_pattern1);
        _patterns.Add(_pattern2);
        _patterns.Add(_pattern3);
        _patterns.Add(_pattern4);
        _patterns.Add(_pattern5);
        _patterns.Add(_pattern6);
        _patterns.Add(_pattern7);
        _patterns.Add(_pattern8);
        _patterns.Add(_pattern9);
        _patterns.Add(_pattern10);
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
                UpdateRespawnTime();
            }
        }
    }

    private void UpdateRespawnTime()
    {
        var x = Game.Instance.getScore();
        if (x >= 10000)
        {
            //SpawnBoss
            //STOP all other spawns
            _isEnabled = false;
        }
        else if (x >= 7500)
        {
            _respawnTime = Random.Range(1f, 3f);
        }
        else if (x >= 5000)
        {
            _respawnTime = Random.Range(2f, 5f);
        }
        else if (x >= 2500)
        {
            _respawnTime = Random.Range(3f, 6f);
        }
        else if (x >= 1500)
        {
            _respawnTime = Random.Range(4f, 6f);
        }
        else
        {
            _respawnTime = Random.Range(5f, 7f);
        }


}

    private GameObject PickEType()
    {
        return enemies[Random.Range(0, enemies.Count)];
    }
    private void SpawnWave()
    {
        
        _currentPattern = _patterns[Random.Range(1,_patterns.Count)];
        var etype = PickEType();

        for (int i = 0; i < _currentPattern.Length; i++)
        {
            var e = Instantiate(etype);
            e.transform.position = _currentPattern[i];
        }
        _currentPattern = null;

        

    }

    public void Enable()
    {
        _isEnabled = !_isEnabled;
    }
}
    
