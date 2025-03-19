using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = (float)2;
   
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * -speed * Time.deltaTime);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Game.Instance.updateScore(10);
            speed = 0;
            
        }
    }
}
