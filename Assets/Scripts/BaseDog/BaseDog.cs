using UnityEngine;

namespace Assets.Scripts.BaseDog
{
    public abstract class BaseDog : MonoBehaviour
    {
        [SerializeField] protected internal Bullet defaultBullet;
        [SerializeField] public Transform gunPosition;

        public int Hp { get; protected set; }
        public float Speed { get; private set; }
        public Bullet Bullet { get; private set; }

        protected void Init(int hp, float speed, Bullet bullet)
        {
            Hp = hp;
            Speed = speed;
            Bullet = bullet;
        }

        public abstract void Fire();
        
        
    }
}
