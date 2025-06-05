using Programming_of_corporate_industrial_systems_Practice_1.Controllers;
using Programming_of_corporate_industrial_systems_Practice_1.ErrorHandling;
using Programming_of_corporate_industrial_systems_Practice_1.Services;

namespace Programming_of_corporate_industrial_systems_Practice_1
{
    internal class Program
    {
        private static IErrorHandler _errorHandler = new ErrorHandler();

        static void Main(string[] args)
        {
            _errorHandler.ExecuteWithErrorHandling(() =>
            {
                IWordSearchService wordSearchService = new WordSearchService();
                var controller = new WordSearchController(wordSearchService);
                controller.Execute();
            });
        }
    }
}
