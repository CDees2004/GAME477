    using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.VFX;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Boss : MonoBehaviour
{
    private enum BossState {Hovering, Charging, Attacking, Pass }

    private int counter;
    private Vector3 hoverCenter;
    private float hoverStartTime;
    private BossState state;
    private bool spawning;
    private bool isDead = false;
    public float floatStrength = 0.5f;
    public float floatSpeed = 1.0f;
    public float floatDistance = 0.5f;
    public float moveSpeed = 2.0f;

    //enemy prefabs
    public GameObject fishPrefab;
    public GameObject sharkPrefab;
    public GameObject squidPrefab;
    public VisualEffect vfx;

    public GameObject deadBoss; 
    //boss Sprites
    public GameObject restingSprite;
    public GameObject attackingSprite;
    public GameObject summoningSprite;
   


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * 200);
        state = BossState.Pass;
        Invoke(nameof(BeginHover), 1.5f);
        Invoke(nameof(SpawnFish), 5);
        counter = 0;
        spawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            switch (state)
            {
                case BossState.Hovering:

                    DoHover();
                    break;

                //return boss to original position after passing the player
                case BossState.Charging:

                    if (transform.position.x < -20)
                    {
                        transform.position = new Vector3(15, 0, 0);
                        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        GetComponent<Rigidbody2D>().AddForce(Vector2.left * 800);
                        Invoke(nameof(BeginHover), 0.5f);
                        state = BossState.Pass;
                    }

                    break;

                //pushes boss back a lil and stops hovering to signal charge attack
                case BossState.Attacking:
                    spawning = false;
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    GetComponent<Rigidbody2D>().AddForce(Vector2.right * 250);
                    state = BossState.Charging;
                    break;

                //base case to default to --- very important!!!
                case BossState.Pass:
                    break;
            }
        }
        if (isDead)
        {
            Invoke("Dead", 1f);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            counter += 1;
            Destroy(collision.gameObject);


        }

        if (collision.CompareTag("Player"))
        {
            Player.Instance.UpdateHealth(-3);
        }

        if (collision.CompareTag("Explosion"))
        {
            counter += 2;
           
        }
        if (counter >= 300) //this seems like a lot, it is not              
        {
            isDead =  true;
            Game.Instance.Win(gameObject);

        }                                                                    
    }


    //does the hover, gets called on every update from the hover case
    void DoHover()
    {
        if (spawning == false)
        {
            float phase = Time.time - hoverStartTime;
            //I ripped this from a 2D balloon popping game tutorial >:)
            //It uses the angles from the unit circle basically to make the object rotate in a circle I think
            float newX = hoverCenter.x + Mathf.Cos(phase * floatSpeed) * floatDistance;
            float newY = hoverCenter.y + Mathf.Sin(phase * floatSpeed) * floatDistance;

            transform.position = new Vector3(newX, newY, transform.position.z);
            attackingSprite.SetActive(false); restingSprite.SetActive(true);
        }
        else if (spawning == true)
        {
            float phase = Time.time - hoverStartTime;
            //I ripped this from a 2D balloon popping game tutorial >:)
            //It uses the angles from the unit circle basically to make the object rotate in a circle I think
            float newX = hoverCenter.x + Mathf.Cos(phase * floatSpeed) * floatDistance;
            float newY = hoverCenter.y + Mathf.Sin(phase * floatSpeed) * floatDistance;

            transform.position = new Vector3(newX, newY, transform.position.z);
            summoningSprite.SetActive(true); restingSprite.SetActive(false);
        }

    }

    //starts hover based on location after boss waltz in
    private void BeginHover()
    {
        hoverCenter = transform.position;
        hoverCenter.y -= 0.44f;
        hoverStartTime = Time.time;  
        state = BossState.Hovering;
    }


    // just getting functionality working this will be tuned once I get the sprite
    private void SpawnFish()
    {
        //spawn sharks
        var shark1 = Instantiate(sharkPrefab);
        shark1.transform.position = new Vector3(12, 3.5f, 0);
        var shark2 = Instantiate(sharkPrefab);
        shark2.transform.position = new Vector3(12, -3.5f, 0);
        var shark3 = Instantiate(sharkPrefab);
        shark3.transform.position = new Vector3(12, 2.5f, 0);
        var shark4 = Instantiate(sharkPrefab);
        shark4.transform.position = new Vector3(12, -2.5f, 0);
        
        // just a heads-up there is a faster way to do this - Dylan
        //Instantiate(sharkPrefab).transform.position = new Vector3(12, -1.5f, 0);

        //spawn fish
        var fish1 = Instantiate(fishPrefab);
        fish1.transform.position = new Vector3(12, 2, 0);
        var fish2 = Instantiate(fishPrefab);
        fish2.transform.position = new Vector3(12, -2, 0);
        var fish3 = Instantiate(fishPrefab);
        fish3.transform.position = new Vector3(12, 0.5f, 0);
        var fish4 = Instantiate(fishPrefab);
        fish4.transform.position = new Vector3(12, -0.5f, 0);

        //spawn squids
        var squid1 = Instantiate(squidPrefab);
        squid1.transform.position = new Vector3(12, 3, 0);
        var squid2 = Instantiate(squidPrefab);
        squid2.transform.position = new Vector3(12, -3, 0);
        var squid3 = Instantiate(squidPrefab);
        squid3.transform.position = new Vector3(12, 1f, 0);
        var squid4 = Instantiate(squidPrefab);
        squid4.transform.position = new Vector3(12, -1f, 0);

        spawning = true;
        Invoke(nameof(StartAttack), 5f);
    }


    //switches BossState to attacking so the hovering will stop
    private void StartAttack() 
    {
        attackingSprite.SetActive(false); restingSprite.SetActive(true); summoningSprite.SetActive(false);
        state = BossState.Attacking; Invoke(nameof(CmereBoy), 2f); 
    }

    //launches that mfer, calls next attack pattern sequence
    private void CmereBoy() 
    {
        attackingSprite.SetActive(true); restingSprite.SetActive(false); summoningSprite.SetActive(false);
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1200); 
        Invoke(nameof(SpawnFish), 10f); 
    }
    
    void Dead()
    {
        attackingSprite.SetActive(false); restingSprite.SetActive(false); summoningSprite.SetActive(false);
    }
}
