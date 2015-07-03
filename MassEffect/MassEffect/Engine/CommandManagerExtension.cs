using MassEffect.Engine.Commands;

namespace MassEffect.Engine
{
    class CommandManagerExtension : CommandManager
    {

        public CommandManagerExtension()
            :base()
        {
        }

        public override void SeedCommands()
        {
            this.commandsByName["system-report"] = new SystemReport(this.Engine);
            base.SeedCommands();
        }
    }
}
