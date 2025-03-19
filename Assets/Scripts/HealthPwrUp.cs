using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPwrUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(100f, 500f));
        Vector3 initPos = new Vector3(Random.Range(-8, 6), 6, 0);
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.GetComponent<Player>() != null){
            Destroy(GameObject);
            updateHealth(1);
            print("Health up!");
        }
    }
}
