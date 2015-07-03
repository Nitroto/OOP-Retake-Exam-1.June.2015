using MassEffect.Interfaces;
using System;

namespace MassEffect.GameObjects.Projectiles
{
    public class Laser : Projectile
    {
        public Laser(int damage)
            : base(damage)
        {
        }


        public override void Hit(IStarship ship)
        {
            var diff = this.Damage - ship.Shields;
            if (diff > 0)
            {
                ship.Shields = 0;
                ship.Health -= diff;
            }
            else
            {
                ship.Shields -= this.Damage;
            }
        }
    }
}
