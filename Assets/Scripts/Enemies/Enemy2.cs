using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

namespace Enemies
{
    public class Enemy2 : MonoBehaviour
    {
        private GameObject player;
        private float distance;

        public GameObject fish1;
        public GameObject fish2;
        public float speed;



        // Start is called before the first frame update
        void Start()
        {
            player = Player.Instance.gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            var angle = Mathf.Atan2(transform.position.y-player.transform.position.y, distance) * Mathf.Rad2Deg;
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(angle, transform.forward);

            if (distance < 8) { fish1.SetActive(false); fish2.SetActive(true); }
            else { fish1.SetActive(true); fish2.SetActive(false); }
        }


        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Game.Instance.updateScore(50);
            }

            if (collision.CompareTag("Player"))
            {
                Player.Instance.UpdateHealth(-3);
            }

            if (collision.CompareTag("Explosion"))
            {
                Destroy(gameObject);
                Game.Instance.updateScore(50);
            }
        }


    }
}
