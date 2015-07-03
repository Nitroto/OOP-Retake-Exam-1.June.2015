using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Dreadnought : Starship
    {
        private const int DreadnoughtInitialHealth = 200;
        private const int DreadnoughtInitiaShields = 300;
        private const int DreadnoughtInitiaDamage = 150;
        private const double DreadnoughtInitiaFuel = 700.0;


        public Dreadnought(string name, StarSystem location)
            : base(name, location, DreadnoughtInitialHealth, DreadnoughtInitiaShields, DreadnoughtInitiaDamage, DreadnoughtInitiaFuel)
        {
        }


        public override IProjectile ProduceAttack()
        {
            return new Laser((this.Shields/2)+this.Damage);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;
            base.RespondToAttack(attack);
            this.Shields -= 50;
        }
    }
}
