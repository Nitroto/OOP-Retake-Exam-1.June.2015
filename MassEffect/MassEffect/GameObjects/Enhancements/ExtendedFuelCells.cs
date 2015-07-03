namespace MassEffect.GameObjects.Enhancements
{
    public class ExtendedFuelCells : Enhancement
    {
        private const int ExtendedFuelCellShieldBonus = 0;
        private const int ExtendedFuelCellsDamageBonus = 0;
        private const int ExtendedFuelCellsFuelBonus = 200;

        public ExtendedFuelCells(string name)
            : base(name, ExtendedFuelCellShieldBonus, ExtendedFuelCellsDamageBonus, ExtendedFuelCellsFuelBonus)
        {
        }
    }
}
