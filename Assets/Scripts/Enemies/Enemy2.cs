using UnityEngine;

namespace Enemies
{
    public class Enemy2 : MonoBehaviour
    {
        private GameObject _player;
        public GameObject fish1;
        public GameObject fish2;

        public float speed;

        private float _distance;
        public AudioClip explosion;
        private AudioSource audioSrc;



        // Start is called before the first frame update
        void Start()
        {
            _player = Player.Instance.gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            _distance = Vector3.Distance(transform.position, _player.transform.position);
            Vector3 direction = _player.transform.position - transform.position;
            direction.Normalize();
            var angle = Mathf.Atan2(transform.position.y-_player.transform.position.y, _distance) * Mathf.Rad2Deg;
            transform.position = Vector3.MoveTowards(this.transform.position, _player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(angle, transform.forward);

            if (_distance < 8) { fish1.SetActive(false); fish2.SetActive(true); }
            else { fish1.SetActive(true); fish2.SetActive(false); }
        }


        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Bullet") || collision.CompareTag("Explosion") )
            {
                if (collision.CompareTag("Bullet"))
                {
                    Destroy(collision.gameObject);
                }
                audioSrc.clip = explosion;
                audioSrc.Play();
                Destroy(gameObject);
                Game.Instance.updateScore(5);
            }
            else if (collision.CompareTag("Player"))
            {
                Player.Instance.UpdateHealth(-1);
                Destroy(gameObject);
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

    
    }
}
