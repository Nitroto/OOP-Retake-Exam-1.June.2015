namespace MassEffect.Engine.Commands
{
    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Ships;
    using MassEffect.Interfaces;
    using System;
    using System.Linq;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }


        public override void Execute(string[] commandArgs)
        {
            StarshipType type = (StarshipType)Enum.Parse(typeof(StarshipType), commandArgs[1]);
            string shipName = commandArgs[2];
            var starSystem = this.GameEngine.Galaxy.GetStarSystemByName(commandArgs[3]);
            string[] enhancements = new string[commandArgs.Length - 4];
            for (int i = 0; i < enhancements.Length; i++)
            {
                enhancements[i] = commandArgs[4 + i];
            }
            bool shipAlreadyExists = this.GameEngine.Starships.Any(s => s.Name == shipName);

            if (shipAlreadyExists)
            {
                Console.WriteLine(Messages.DuplicateShipName);
            }
            else
            {
                var newShip = this.GameEngine.ShipFactory.CreateShip(type, shipName, starSystem);
                foreach (string enhancement in enhancements)
                {
                    var enhancementType = (EnhancementType)Enum.Parse(typeof(EnhancementType), enhancement);
                    var newEnhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);
                    newShip.AddEnhancement(newEnhancement);
                }
                this.GameEngine.Starships.Add(newShip);

                Console.WriteLine(Messages.CreatedShip, type.ToString(), shipName);
            }
        }
    }
}
