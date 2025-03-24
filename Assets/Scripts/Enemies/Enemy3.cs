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
    public float moveSpeed = 2.0f;
    public GameObject squid1;
    public GameObject squid2;

    private Vector3 startPosition;




    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Invoke("changeSpriteUp", 3f);

    }

    // Update is called once per frame
    void Update()
    {
        // Floating motion
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatDistance;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // x movement
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);

       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Game.Instance.updateScore(5);
        }
        else if (collision.CompareTag("Player"))
        {
            Player.Instance.updateHealth(-1);
            Destroy(gameObject);
        }
    }

    //set to going up sprite
    private void changeSpriteUp() { squid1.SetActive(true); squid2.SetActive(false);  Invoke("changeSpriteDown", 3f); }

    //set to going down sprite
    private void changeSpriteDown() { squid1.SetActive(false); squid2.SetActive(true); Invoke("changeSpriteUp", 3f); }
    
}
