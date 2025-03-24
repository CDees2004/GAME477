using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = (float)20;
    
    // Start is called before the first frame update
    void Start()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * speed);
    }

    // Update is called once per frame
    void Update( )
    {

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")|| collision.CompareTag("Explosion"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Game.Instance.updateScore(10);
            speed = 0;
            
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Player.Instance.UpdateHealth(-1);
        }
    }
}
