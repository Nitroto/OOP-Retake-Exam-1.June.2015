namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System;
    using System.Linq;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }


        public override void Execute(string[] commandArgs)
        {
            IStarship attacker = this.GameEngine.Starships.Where(ship => ship.Name == commandArgs[1]).FirstOrDefault();
            IStarship target = this.GameEngine.Starships.Where(ship => ship.Name == commandArgs[2]).FirstOrDefault();
            this.ProcessStarshipBattle(attacker, target);
        }

        private void ProcessStarshipBattle(IStarship attacker, IStarship target)
        {
            base.ValidateAlive(attacker);
            base.ValidateAlive(target);
            if (attacker.Location.Name == target.Location.Name)
            {
                IProjectile attackProjectile = attacker.ProduceAttack();
                target.RespondToAttack(attackProjectile);
                Console.WriteLine(Messages.ShipAttacked, attacker.Name, target.Name);
                if (target.Health == 0)
                {
                    Console.WriteLine(Messages.ShipDestroyed, target.Name);
                }
            }
            else
            {
                Console.WriteLine(Messages.NoSuchShipInStarSystem);
            }
        }
    }
}
