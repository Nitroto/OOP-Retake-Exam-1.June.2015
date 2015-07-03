namespace MassEffect.GameObjects.Enhancements
{
    public class KineticBarrier : Enhancement
    {
        private const int KineticBarrierShieldBonus = 100;
        private const int KineticBarrierDamageBonus = 0;
        private const int KineticBarrierFuelBonus = 0;

        public KineticBarrier(string name)
            : base(name, KineticBarrierShieldBonus, KineticBarrierDamageBonus, KineticBarrierFuelBonus)
        {
        }
    }
}
