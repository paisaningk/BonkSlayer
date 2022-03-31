using Assets.Scripts.BaseDog;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnEnemy : MonoBehaviour
    {
        private float nextSpawnTime;

        [SerializeField] private Enemydog Enemy;
        [SerializeField] private int EnemyHp;
        [SerializeField] private int EnemySpeed;
        [SerializeField] private float spawnDelay = 0.5f;
        [SerializeField]public AudioClip Enemydie;
        private LevelManager Score;
        private int PlayerScore = 1;
        internal Enemydog spawnedEnemy;

        private void Awake()
        {
            //Spawn();
        }

        private void Update()
        {
            SpawnedEnemy();
        }

        public void SpawnedEnemy()
        {
            if (ShouldSpawn())
            {
                Spawn();
            } 
        }
       

        private void Spawn()
        {
            nextSpawnTime = Time.time + spawnDelay;
            spawnedEnemy = Instantiate(Enemy, transform.position, transform.rotation);
            spawnedEnemy.Init(EnemyHp,EnemySpeed);
            spawnedEnemy.OnExploded += OnEnemyDead;
            
        }

        private void OnEnemyDead()
        {
            AudioSource.PlayClipAtPoint(Enemydie,Camera.main.transform.position);
            Score = GameObject.Find("Level").GetComponent<LevelManager>();
            Score.SetScore(PlayerScore);
        }

        private bool ShouldSpawn()
        {
            return Time.time >= nextSpawnTime;
        }
    }
}
