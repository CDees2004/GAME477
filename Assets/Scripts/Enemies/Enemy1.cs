using UnityEngine;

namespace Enemies
{
    public class Enemy1 : MonoBehaviour
    {

        private int _counter;
        private bool _isHovering;
        private Vector3 _startPosition;

        public GameObject fishPrefab;
        public GameObject shark1;
        public GameObject shark2;

        public float floatStrength = 0.5f;
        public float floatSpeed = 1.0f;
        public float floatDistance = 0.5f;
        public float moveSpeed = 2.0f;
        public AudioClip explosion;
        private AudioSource audioSrc;


        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * 200);
            Invoke(nameof(SpawnFish), 5);
            Invoke(nameof(StartHovering), 2);

        }

        // Update is called once per frame
        void Update()
        {
            if (_isHovering) { 
                var newY = _startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatDistance;
                var tmpx = new Vector3(transform.position.x, newY, transform.position.z);
                Vector3.MoveTowards(transform.position, tmpx,1 );
            

                // Apply horizontal movement
                var newX = _startPosition.x + Mathf.Cos(Time.time * floatSpeed) * floatDistance;
                var tmpy = new Vector3(newX, transform.position.y, transform.position.z);
                Vector3.MoveTowards(transform.position, tmpy, 1 );
            }
        }

        void OnTriggerEnter2D(Collider2D collision) 
        {
            if (collision.CompareTag("Bullet")|| collision.CompareTag("Explosion"))
            {
                _counter += 1;
                if (collision.CompareTag("Bullet"))
                {
                    Destroy(collision.gameObject);
                }

                if (_counter >= 3)
                {
                    audioSrc.clip = explosion;
                    audioSrc.Play();
                    Destroy(gameObject);
                    Game.Instance.updateScore(100);
                }

            }
    
            if (collision.CompareTag("Player"))
            {
                Player.Instance.UpdateHealth(-3);
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Explosion"))
            {
                Destroy(gameObject);
                Game.Instance.updateScore(50);
                audioSrc.clip = explosion;
                audioSrc.Play();
            }
        }


        private void StartHovering()
        {
            //get hovering position
            _startPosition = transform.position;

            // adjust position for hovering so it's not so jank
            _startPosition.y = _startPosition.y - 0.43f;
            _startPosition.x = _startPosition.x + 0.15f;

            _isHovering = true;
        }

        private void SpawnFish()
        {
            //change sprites
            shark1.SetActive(false); shark2.SetActive(true);
            //send fishes out
            var fish = Instantiate(fishPrefab);
            fish.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            //recursion!!!
            Invoke(nameof(ChangeSprite), 1f);
            Invoke(nameof(SpawnFish), 5);
        }

        //set sprite back to normal
        private void ChangeSprite() { shark1.SetActive(true); shark2.SetActive(false); }
    
    }
}
