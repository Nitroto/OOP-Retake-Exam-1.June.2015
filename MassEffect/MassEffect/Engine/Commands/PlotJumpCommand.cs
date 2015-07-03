namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System;
    using System.Linq;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }


        public override void Execute(string[] commandArgs)
        {
            IStarship jumper = this.GameEngine.Starships.Where(ship => ship.Name == commandArgs[1]).FirstOrDefault();
            var destination = this.GameEngine.Galaxy.GetStarSystemByName(commandArgs[2]);
            var currentLocation = jumper.Location;
            base.ValidateAlive(jumper);
            if (currentLocation.Name != destination.Name)
            {
                this.GameEngine.Galaxy.TravelTo(jumper, destination);
                Console.WriteLine(Messages.ShipTraveled, jumper.Name, currentLocation.Name, destination.Name);
            }
            else
            {
                Console.WriteLine(Messages.ShipAlreadyInStarSystem, destination.Name);
            }
            base.Execute(commandArgs);
        }
    }
}
