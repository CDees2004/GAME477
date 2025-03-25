using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.left*30);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
