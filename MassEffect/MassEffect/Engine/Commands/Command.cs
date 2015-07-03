namespace MassEffect.Engine.Commands
{

    using MassEffect.Exceptions;
    using MassEffect.Interfaces;

    public class Command
    {
        public Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }


        public IGameEngine GameEngine { get; set; }


        public virtual void Execute(string[] commandArgs)
        {
        }

        public void ValidateAlive(IStarship starship)
        {
            if (starship.Health <= 0)
            {
                throw new ShipException(Messages.ShipDestroyed);
            }
        }

    }
}
