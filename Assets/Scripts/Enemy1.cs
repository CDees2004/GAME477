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




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < 5) { GetComponent<Rigidbody2D>().AddForce(Vector2.right * 3); }
        if (transform.position.x > 7) { GetComponent<Rigidbody2D>().AddForce(Vector2.left * 3); }

        if (transform.position.y > 4) { GetComponent<Rigidbody2D>().AddForce(Vector2.down / 2); }
        if (transform.position.y < -4) { GetComponent<Rigidbody2D>().AddForce(Vector2.up / 2); }



        //if (rb.velocity.x < 1)
        //{

        //}
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
    }
}
