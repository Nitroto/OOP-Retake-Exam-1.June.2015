namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System.Linq;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            var starShip = this.GameEngine.Starships.Where(ship => ship.Name == shipName);
            foreach (var ship in starShip)
            {
                System.Console.WriteLine(ship.ToString());
            }

        }
    }
}
