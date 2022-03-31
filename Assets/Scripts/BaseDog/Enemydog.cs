using System;
using UnityEngine;

namespace Assets.Scripts.BaseDog
{
    public class Enemydog : BaseDog , IDamagable
    {
        public event Action OnExploded;
        
        [SerializeField] private float fireRate = 1;

        private float fireCounter = 0;
        private Bullet Bullet;
        
        
        public void Init(int hp, float speed)
        {
            base.Init(hp, speed, defaultBullet);
        }

       

        public override void Fire()
        {
            fireCounter += Time.deltaTime;
            if (fireCounter >= fireRate)
            {
                var bullet = Instantiate(defaultBullet, gunPosition.position, gunPosition.rotation);
                bullet.FireEnemy(Vector2.down);
                fireCounter = 0;
            }
        }

        public void TakeHit(int damage)
        {
            Hp -= damage;
            if(Hp > 0)
            {
                return;
            }

            Explode();
        }

        public void Explode()
        {
            Debug.Assert(Hp <= 0, "Hp is more than zero");
            gameObject.SetActive(false);
            Destroy(gameObject);
            OnExploded?.Invoke();
        }
    }
}
