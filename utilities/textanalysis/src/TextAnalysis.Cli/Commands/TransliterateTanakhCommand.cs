namespace TextAnalysis.Cli.Commands
{
    internal class TransliterateTanakhCommand : ITransliterateTanakhCommand
    {
        private string _books;
        private string _sourceFile;
        private string _outputFile;
        private string _type;
        
        public TransliterateTanakhCommand(string books, string sourceFile, string outputFile, string type)
        {
            _books = books;
            _type = type;
            _outputFile = outputFile;
            _sourceFile = sourceFile;
        }
        
        public void Execute()
        {
            System.Console.WriteLine("Books: {0}", _books);
            System.Console.WriteLine("SourceFile: {0}", _sourceFile);
            System.Console.WriteLine("OutputFile: {0}", _outputFile);
            System.Console.WriteLine("Type: {0}", _type);
        }
    }

    internal interface ITransliterateTanakhCommand : ICommand
    {
    }
}