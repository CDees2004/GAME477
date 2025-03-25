using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Enemy3 : MonoBehaviour
{
    public float floatStrength = 0.5f; 
    public float floatSpeed = 1.0f;   
    public float floatDistance = 0.5f;  
    public float speed = 2.0f;
    public GameObject squid1;
    public GameObject squid2;
    private int _health = 4;


    private Vector3 _startPosition;




    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
        Invoke(nameof(ChangeSpriteUp), 3f);

    }

    // Update is called once per frame
    void Update()
    {
        // Floating motion
        float newY = _startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatDistance;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // x movement
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("Explosion") )
        {
            if (collision.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
            }
            
            if (collision.CompareTag("Explosion"))
            {
                Destroy(gameObject);
                Game.Instance.updateScore(50);
            }

            _health--;
            if (_health <= 0)
            {
                Destroy(gameObject);
                Game.Instance.updateScore(50);
            }
           
        }
        if (collision.CompareTag("Player"))
        {
            Player.Instance.UpdateHealth(-3);
            Destroy(gameObject);
        }

    }


    //set to going up sprite
    private void ChangeSpriteUp() { squid1.SetActive(true); squid2.SetActive(false);  Invoke(nameof(ChangeSpriteDown), 3f); }

    //set to going down sprite
    private void ChangeSpriteDown() { squid1.SetActive(false); squid2.SetActive(true); Invoke(nameof(ChangeSpriteUp), 3f); }
    
}
