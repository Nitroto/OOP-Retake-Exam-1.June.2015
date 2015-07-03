using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    public abstract class Projectile : IProjectile
    {
        private int damage;

        protected Projectile(int damage)
        {
            this.Damage = damage;
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                this.damage = value;
            }
        }

        public abstract void Hit(IStarship ship);
    }
}
