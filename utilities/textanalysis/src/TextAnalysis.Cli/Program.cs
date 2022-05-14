using System;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using Autofac;
using TextAnalysis.Cli.CommandLine.Commands;
using TextAnalysis.Cli.Startup;

namespace TextAnalysis.Cli
{
    class Program
    {
        
        public static async Task<int> Main(string[] args)
        {
            // Expected Help and Usage
            // usage: textanalysis <command> [<args>]
            // 
            // These are the commands that are available:
            // 
            // Working with the text
            //    transliterate    Convert the text from the original language
            //        usage: textanalysis transliterate [--text] [--output]
            
            try
            {
                var appModule = new AppModule();
                var commandStructureFactory = appModule.AppContainer.Resolve<ICommandStructureFactory>();
                var rootCommand = commandStructureFactory.GetCommandStructure();
                var commandBuilder = commandStructureFactory.GetCommandLineBuilder(rootCommand);

                return await 
                    commandBuilder
                        .Build()
                        .InvokeAsync(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
