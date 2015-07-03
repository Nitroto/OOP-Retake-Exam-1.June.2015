using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Cruiser : Starship
    {
        private const int CruiserInitialHealth = 100;
        private const int CruiserInitiaShields = 100;
        private const int CruisereInitiaDamage = 50;
        private const double CruiserInitiaFuel = 300.0;


        public Cruiser(string name, StarSystem location)
            : base(name, location, CruiserInitialHealth, CruiserInitiaShields, CruisereInitiaDamage, CruiserInitiaFuel)
        {
        }


        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}
