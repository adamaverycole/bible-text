using Autofac;

namespace TextAnalysis.Cli.Commands
{
    public class CommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<CommandFactory>()
                .As<ICommandFactory>();
            builder
                .RegisterType<TransliterateTanakhCommand>()
                .As<ITransliterateTanakhCommand>();
        }
    }
}