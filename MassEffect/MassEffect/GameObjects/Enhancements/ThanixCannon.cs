namespace MassEffect.GameObjects.Enhancements
{
    public class ThanixCannon : Enhancement
    {
        private const int ThanixCannonShieldBonus = 0;
        private const int ThanixCannonDamageBonus = 50;
        private const int ThanixCannonFuelBonus = 0;

        public ThanixCannon(string name)
            : base(name, ThanixCannonShieldBonus, ThanixCannonDamageBonus, ThanixCannonFuelBonus)
        {
        }
    }
}
