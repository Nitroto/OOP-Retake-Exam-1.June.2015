using MassEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MassEffect.Engine.Commands
{
    class SystemReport : Command
    {
        public SystemReport(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }


        public override void Execute(string[] commandArgs)
        {
            string locationName = commandArgs[1];
            IEnumerable<IStarship> intactShip = null;
            intactShip = this.GameEngine.Starships.Where(s => s.Location.Name == locationName && s.Health > 0).OrderByDescending(s => s.Health).ThenByDescending(s => s.Shields);
            StringBuilder output = new StringBuilder();
            output.AppendLine("Intact ships:");
            output.AppendLine(intactShip.Any() ? string.Join("\n\r", intactShip) : "N/A");
            IEnumerable<IStarship> destroyedShips = null;
            destroyedShips = this.GameEngine.Starships.Where(s => s.Location.Name == locationName && s.Health == 0).OrderBy(s => s.Name);
            output.AppendLine("Destroyed ships:");
            output.Append(destroyedShips.Any() ? string.Join("\n\r", destroyedShips) : "N/A");

            Console.WriteLine(RemoveEmptyLines(output.ToString()));
        }


        // empty line fix
        private string RemoveEmptyLines(string lines)
        {
            return Regex.Replace(lines, @"^\s*$\n|\r", "", RegexOptions.Multiline).TrimEnd();
        }
    }
}
