using System;
using UnityEngine;

namespace Assets.Scripts.BaseDog
{
    public class PlayerDog : BaseDog, IDamagable
    {
        public event Action OnExploded;

        private HealthBar healthBar;
        private int maxHP;
        
        public void Init(int hp, float speed)
        {
            base.Init(hp, speed, defaultBullet);
        }

        private void Start()
        {
            maxHP = LevelManager.Instance.spawnedPlayerDog.Hp;
            healthBar = LevelManager.Instance.healthBar;
            healthBar.SetMaxHealth(maxHP);
        }
        public override void Fire()
        {
            
        }

        public void TakeHit(int damage)
        {
            Hp -= damage;
            healthBar.SetHealth(Hp);
            if(Hp > 0)
            {
                return;
            }
            Explode();
        }

        public void Explode()
        {
            Destroy(gameObject);
            OnExploded?.Invoke();
        }
    }
}
