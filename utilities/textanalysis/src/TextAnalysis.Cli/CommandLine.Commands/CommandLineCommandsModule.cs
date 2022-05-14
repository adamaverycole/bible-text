using Autofac;

namespace TextAnalysis.Cli.CommandLine.Commands
{
    public class CommandLineCommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<CommandStructureFactory>()
                .As<ICommandStructureFactory>();
        }
    }
}