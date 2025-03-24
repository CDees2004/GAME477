using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Boss : MonoBehaviour
{
    private enum BossState { Hovering, Charging, Attacking, Pass }

    private int counter;
    private Vector3 hoverCenter;
    private float hoverStartTime;
    private BossState state;

    public float floatStrength = 0.5f;
    public float floatSpeed = 1.0f;
    public float floatDistance = 0.5f;
    public float moveSpeed = 2.0f;

    public GameObject fishPrefab;
    public GameObject sharkPrefab;
   
    /*  
     * VERY IMPORTANT NOTE
     * The boss is tuned to start at x = 13 and y = 0, 
     * it has to start here for it's attack pattern to be consistent
     *
     * Please do not mess with any tuning numbers in here, they are that way for a reason,
     * discord me if I need to change something
     * 
     * It's also not completely finished, need sprite for full implemenetation
     * Notably numbers for the attack pattern sequence execution are just for testing rn
     */


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * 200);
        state = BossState.Pass;
        Invoke("beginHover", 1.5f);
        Invoke("spawnFish", 5);
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case BossState.Hovering:
                doHover();
                break;

            //return boss to original position after passing the player
            case BossState.Charging:
                if (transform.position.x < -20)
                {
                    transform.position = new Vector3(13, 0, 0);
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    GetComponent<Rigidbody2D>().AddForce(Vector2.left * 200);
                    Invoke("beginHover", 1.5f);
                    state = BossState.Pass;
                }
                break;  

            //pushes boss back a lil and stops hovering to signal charge attack
            case BossState.Attacking:
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * 250);
                state = BossState.Charging;   
                break;

            //base case to default to --- very important!!!
            case BossState.Pass:
                break;
        }
 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            counter += 1;
            Destroy(collision.gameObject);

            if (counter >= 250) //this seems like a lot, it is not
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
    }

    //does the hover, gets called on every update from the hover case
    void doHover()
    {
        float phase = Time.time - hoverStartTime;
        //I ripped this from a 2D balloon popping game tutorial >:)
        //It uses the angles from the unit circle basically to make the object rotate in a circle I think
        float newX = hoverCenter.x + Mathf.Cos(phase * floatSpeed) * floatDistance;
        float newY = hoverCenter.y + Mathf.Sin(phase * floatSpeed) * floatDistance;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    //starts hover based on location after boss waltz in
    private void beginHover()
    {
        hoverCenter = transform.position;
        hoverCenter.y -= 0.44f;
        hoverStartTime = Time.time;  
        state = BossState.Hovering;
    }


    // just getting functionality working this will be tuned once I get the sprite
    private void spawnFish()
    {
        var shark1 = Instantiate(sharkPrefab);
        shark1.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        var shark2 = Instantiate(sharkPrefab);
        shark2.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, 0);


        var fish1 = Instantiate(fishPrefab);
        fish1.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        var fish2 = Instantiate(fishPrefab);
        fish2.transform.position = new Vector3(transform.position.x, transform.position.y - 1.2f, 0);

        Invoke("startAttack", 1f);
    }


    //switches BossState to attacking so the hovering will stop
    private void startAttack() { state = BossState.Attacking; Invoke("cmereBoy", 2f); }

    //launches that mfer, calls next attack pattern sequence
    private void cmereBoy() { GetComponent<Rigidbody2D>().AddForce(Vector2.left * 800); Invoke("fireCannon", 8f); }
    
    private void fireCannon()
    {
        //not implemented yet, might be swapped with smthn else
        Invoke("spawnFish", 5f);
    }
}
