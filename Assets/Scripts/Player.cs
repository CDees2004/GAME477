using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System.Threading.Tasks;
using System;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class Player : MonoBehaviour {
    public float moveSpeed = 5;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public int upperBound = 4;
    public int lowerBound = -4;
    public float leftBound = -9;
    public float rightBound = 9;
    public Slider healthSlider;
    private int _health = 10;
    private float _last = 0;  
    private float _curr = 0;
    private float _shootCooldown = .12f;
    public GameObject normal; //These are sprites
    public GameObject up;
    public GameObject down;
    private GameObject _currentSprite;
    #region Audio variables
    public AudioClip bulletShot;
    public AudioClip missileShot;
    public AudioClip speedPowerUp;
    public AudioClip healthPowerUp;
    private AudioSource audioSrc;
    #endregion


    // Start is called before the first frame update
    public static Player Instance {get; private set;}
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start() {
        
        audioSrc = GetComponent<AudioSource>();
        _currentSprite = normal;
    }

    // Update is called once per frame
    void Update() {
        _curr = Time.time;
        // Player Controls
        var input = Game.Input.Standard;
        ChangeSprite(normal);
        if (transform.position[1] < upperBound)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime * input.MoveUp.ReadValue<float>());
            if (input.MoveUp.IsPressed())
            {
                ChangeSprite(up);
            }

        }
        if (transform.position[1] > lowerBound)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime * input.MoveDown.ReadValue<float>());
            if (input.MoveDown.IsPressed())
            {
                ChangeSprite(down);
            }

        }

        if (transform.position[0] < rightBound)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * input.MoveRight.ReadValue<float>());
        }

        if (transform.position[0] > leftBound)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime * input.MoveLeft.ReadValue<float>());
        }


        


        // Bullet Functionality
        if ((input.ShootBullet.IsPressed() & (_curr - _last > _shootCooldown))) {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = new  Vector3( transform.position.x + 1.5f, transform.position.y, 0);
            _last = _curr;
            audioSrc.clip = bulletShot;
            audioSrc.Play();
        }

        if (input.ShootMissile.WasPressedThisFrame()) {
            var missile = Instantiate(missilePrefab);
            missile.transform.position = transform.position+Vector3.right;
            audioSrc.clip = missileShot;
            audioSrc.Play();
        }
        
        //This Quits the game when health reaches zero, implement UI later
        if (_health <= 0)
        {
            //#if UNITY_STANDALONE
            //Application.Quit();
            //#endif
           // #if UNITY_EDITOR
            //UnityEditor.EditorApplication.isPlaying = false;
            //#endif
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void updateHealth(int x)
    {
        _health += x;
        healthSlider.value = _health;
        
    }

    public async Task updateSpeed(int x){
        moveSpeed *= x;
        print("Move Speed up!");
        await Task.Delay(TimeSpan.FromSeconds(5));
        print("Move Speed down");
        moveSpeed = moveSpeed / x;
    }
    public int getHealth()
    {
        return _health;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("HealthPowerUp")){
            print("Health up!");
            updateHealth(2);
            Destroy(collision.gameObject);
            audioSrc.clip = healthPowerUp;
            audioSrc.Play();
        }
        if (collision.CompareTag("SpeedPowerUp")){
            print("Speed up!");
            updateSpeed(2);
            Destroy(collision.gameObject);
            audioSrc.clip = speedPowerUp;
            audioSrc.Play();
        }
        
    }

    public void ChangeSprite(GameObject sprite)
    {
        if (sprite != _currentSprite)
        {
            _currentSprite.SetActive(false);
            sprite.SetActive(true);
            _currentSprite = sprite;
        }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }
}
