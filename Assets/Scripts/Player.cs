using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float moveSpeed = 5;
    public GameObject bulletPrefab;
   
    public GameObject missilePrefab;
    public int upperBound = 4;
    public int lowerBound = -4;
    public float leftBound = -9;
    public float rightBound = 9;
    public Slider healthSlider;
    private AudioSource _audioSrc;
    private int _health = 10;

    // Start is called before the first frame update
    void Start() {
        _audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

        // Player Controls
        var input = Game.Input.Standard;
        if (transform.position[1] < upperBound)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime * input.MoveUp.ReadValue<float>());
        }

        if (transform.position[1] > lowerBound)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime * input.MoveDown.ReadValue<float>());
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
        if (input.ShootBullet.WasPressedThisFrame()) {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position+Vector3.right; }

        if (input.ShootMissile.WasPressedThisFrame()) {
            var missile = Instantiate(missilePrefab);
            missile.transform.position = transform.position+Vector3.right;
        }
        
        //This Quits the game when health reaches zero, implement UI later
        if (_health <= 0)
        {
            #if UNITY_STANDALONE
            Application.Quit();
            #endif
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
    public void updateHealth(int x)
    {
        _health += x;
        healthSlider.value = _health;
        
    }
    public int getHealth()
    {
        return _health;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            print("Collided");
            updateHealth(-1);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("HealthPowerUp")){
            print("Health up!");
            updateHealth(2);
            Destroy(collision.gameObject);
        }
        
    }
}
