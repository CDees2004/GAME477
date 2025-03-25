using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using UnityEngine.Windows;

public class Enemy1 : MonoBehaviour
{

    private int counter;
    private bool isHovering;
    private Vector3 startPosition;

    public GameObject fishPrefab;
    public GameObject shark1;
    public GameObject shark2;

    public float floatStrength = 0.5f;
    public float floatSpeed = 1.0f;
    public float floatDistance = 0.5f;
    public float moveSpeed = 2.0f;




    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * 200);
        Invoke("spawnFish", 5);
        Invoke("startHovering", 2);

    }

    // Update is called once per frame
    void Update()
    {
        if (isHovering)
        {
            float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatDistance;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Apply horizontal movement
            float newX = startPosition.x + Mathf.Cos(Time.time * floatSpeed) * floatDistance;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            counter += 1;
            Destroy(collision.gameObject);

            if (counter >= 3)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Game.Instance.updateScore(1000);
            }

        }

        if (collision.CompareTag("Player"))
        {
            Player.Instance.UpdateHealth(-3);
        }

        if (collision.CompareTag("Explosion"))
        {
            counter += 2;
            if (counter >= 3)
            {
                Destroy(gameObject);
                Game.Instance.updateScore(100);
            }

        }
    }



    private void startHovering()
    {
        //get hovering position
        startPosition = transform.position;

        // adjust position for hovering so it's not so jank


        isHovering = true;
    }

    private void spawnFish()
    {
        //change sprites
        shark1.SetActive(false); shark2.SetActive(true);
        //send fishes out
        var fish = Instantiate(fishPrefab);
        fish.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //recursion!!!
        Invoke("changeSprite", 1f);
        Invoke("spawnFish", 5);
    }

    //set sprite back to normal
    private void changeSprite() { shark1.SetActive(true); shark2.SetActive(false); }

}
