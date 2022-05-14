using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using TextAnalysis.Cli.Commands;

namespace TextAnalysis.Cli.CommandLine.Commands
{
    internal class CommandStructureFactory : ICommandStructureFactory
    {
        private readonly ICommandFactory _commandFactory;
        
        public CommandStructureFactory(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public RootCommand GetCommandStructure()
        {
            var rootCommand = new RootCommand("Performing analysis of The Text of the Holy Bible");
            var textAnalysisCommand = new Command("textanalysis");
            textAnalysisCommand.HasAlias("ta");
            rootCommand.AddCommand(textAnalysisCommand);

            var transliterateCommand = CreateTransliterateCommand();
            textAnalysisCommand.AddCommand(transliterateCommand);

            return rootCommand;
        }

        public Command CreateTransliterateCommand()
        {
            var transliterateCommand = new Command("transliterate", "Transliterate the Biblical text from its original languages");
            transliterateCommand.HasAlias("t");
            transliterateCommand.AddArgument(
                
                new Argument<string>("books") { Description = "Comma separated list of books to transliterate"});
            transliterateCommand.AddOption(
                new Option<string>(new [] { "--sourceFile", "-s" }, "Path to the source text file containing the text to transliterate") { IsRequired = true });
            transliterateCommand.AddOption(
                new Option<string>(new [] { "--outputFile", "-o" }, "Path to the output file containing the results of the transliteration") { IsRequired = true });
            transliterateCommand.AddOption(
                new Option<string>(new [] { "--type", "-tp" }, "`transliterate` (default) for traditional transliteration; `pronunciation` to replace with with proper pronunciation") { IsRequired = false });

            transliterateCommand.Handler = CommandHandler.Create<string, string, string, string>(
                (books, sourceFile, outputFile, type) =>
                {
                    var command = _commandFactory.CreateTransliterateTanakhCommand(books, sourceFile, outputFile, type);
                    command.Execute();
                });
            return transliterateCommand;
        }

        public Command CreateGenerateTanakhCommand()
        {
            var command = new Command("generate-tanakh", "Aggregate the entire Tanakh into a single file");
            command.HasAlias("gt");
            command.AddOption(
                new Option<string>(new [] { "--outputFile", "-o" }, "Path to the output file containing Tanakh") { IsRequired = false });

            command.Handler = CommandHandler.Create<string>(
                x =>
                {
                    // DO A THING
                });
            return command;
        }

        public CommandLineBuilder GetCommandLineBuilder(RootCommand rootCommand)
        {
            return new CommandLineBuilder(rootCommand)
                .UseDefaults()
                .RegisterWithDotnetSuggest()
                .CancelOnProcessTermination()
                .UseHelp();
        }
    }

    internal interface ICommandStructureFactory
    {
        RootCommand GetCommandStructure();
        Command CreateTransliterateCommand();

        Command CreateGenerateTanakhCommand();
        
        CommandLineBuilder GetCommandLineBuilder(RootCommand rootCommand);
    }
}