namespace TextAnalysis.Cli.Commands
{
    internal class CommandFactory : ICommandFactory
    {
        public ITransliterateTanakhCommand CreateTransliterateTanakhCommand(string books, string sourceFile,
            string outputFile, string type)
        {
            return new TransliterateTanakhCommand(books, sourceFile, outputFile, type);
        }
    }

    internal interface ICommandFactory
    {
        ITransliterateTanakhCommand CreateTransliterateTanakhCommand(string books, string sourceFile,
            string outputFile, string type);
    }
}