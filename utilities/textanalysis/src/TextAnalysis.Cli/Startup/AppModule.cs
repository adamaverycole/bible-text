using Autofac;
using TextAnalysis.Cli.CommandLine.Commands;
using TextAnalysis.Cli.Commands;

namespace TextAnalysis.Cli.Startup
{
    internal class AppModule
    {
        public readonly IContainer AppContainer;

        public AppModule()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<CommandsModule>();
            builder.RegisterModule<CommandLineCommandsModule>();
                
            AppContainer = builder.Build();
        }
    }
}