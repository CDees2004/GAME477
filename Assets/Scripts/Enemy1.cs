using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class Enemy1 : MonoBehaviour
{

    private int counter;
    private int release;

    Rigidbody2D rb;

    public GameObject fishPrefab;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawnFish", 5);

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < 6) { GetComponent<Rigidbody2D>().AddForce(Vector2.right); }
        if (transform.position.x > 7) { GetComponent<Rigidbody2D>().AddForce(Vector2.left); }

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
                Game.Instance.updateScore(100);
            }

        }

        if (collision.CompareTag("Player"))
        {
            Player.Instance.updateHealth(-2);
        }
    }

    public void spawnFish()
    {
        var fish = Instantiate(fishPrefab);
        fish.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Invoke("spawnFish", 5);

    }
        
}
