using UnityEngine;

namespace Assets.Scripts.BaseDog
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Enemydog enemydog;
        private float movespeed = 5;
        private Rigidbody2D rb;
        private Vector2 movement;
        private LevelManager playerOnPostiton;
        private Transform Player;

        void Start()
        {
            rb = this.GetComponent<Rigidbody2D>();
            playerOnPostiton = GameObject.Find("Level").GetComponent<LevelManager>();
            Player = playerOnPostiton.playerOnPostiton;
        }

        void Update()
        {
            enemydog.Fire();
            Vector3 direction = Player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }

        private void FixedUpdate()
        {
            moveCharacter(movement);
        }

        private void moveCharacter(Vector2 diretion)
        {
            rb.MovePosition((Vector2)transform.position + (diretion * movespeed * Time.deltaTime));
        }
        
        
    }
}
