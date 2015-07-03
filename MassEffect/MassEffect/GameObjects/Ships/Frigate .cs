using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;
using System.Text;

namespace MassEffect.GameObjects.Ships
{
    public class Frigate : Starship
    {

        private const int FrigateInitialHealth = 60;
        private const int FrigateInitiaShields = 50;
        private const int FrigateInitiaDamage = 30;
        private const double FrigateInitiaFuel = 220.0;
        private int numberOfFiredProjectiles;


        public Frigate(string name, StarSystem location)
            : base(name, location, FrigateInitialHealth, FrigateInitiaShields, FrigateInitiaDamage, FrigateInitiaFuel)
        {
            this.numberOfFiredProjectiles = 0;
        }


        public override IProjectile ProduceAttack()
        {
            this.numberOfFiredProjectiles++;
            return new ShieldReaver(this.Damage);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());
            if (this.Health > 0)
            {
                output.Append(string.Format("-Projectiles fired: {0}", this.numberOfFiredProjectiles));
            }
            return output.ToString();
        }
    }
}
