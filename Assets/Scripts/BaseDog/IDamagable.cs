using System;

namespace Assets.Scripts.BaseDog
{
    public interface IDamagable 
    {
        event Action OnExploded;
        void TakeHit(int damage);
        void Explode();
    }
}
