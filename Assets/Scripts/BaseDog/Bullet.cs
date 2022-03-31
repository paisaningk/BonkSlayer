using UnityEngine;

namespace Assets.Scripts.BaseDog
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] public float speed;
        [SerializeField] private Rigidbody2D rigidbody2D;

        private void Awake()
        {
            Debug.Assert(rigidbody2D != null, "rigibody2D cannot be null");
        }

        private void Update()
        {
            
        }
        
        public void FirePlayer(Vector2 direction , Vector2 rotation)
        {
            rigidbody2D.velocity = direction * rotation * speed;
        }

        public void FireEnemy(Vector2 direction)
        {
            rigidbody2D.velocity = direction * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Destroyer"))
            {
                Destroy(this.gameObject);
                return;
            }
            if (other.CompareTag("Enemy") && CompareTag("BulletPlayer"))
            {
                var target = other.gameObject.GetComponent<IDamagable>();
                target?.TakeHit(damage);
                Destroy(this.gameObject);
                return;
            }
            if (other.CompareTag("Player") && CompareTag("BulletEnemy"))
            {
                var target = other.gameObject.GetComponent<IDamagable>();
                target?.TakeHit(damage);
                Destroy(this.gameObject);
                return;
            }
            
        }
    }
}
