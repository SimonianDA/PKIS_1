using Programming_of_corporate_industrial_systems_Practice_1.ErrorHandling.ErrorsTypes;
using Programming_of_corporate_industrial_systems_Practice_1.Models;
using Programming_of_corporate_industrial_systems_Practice_1.Services;

namespace Programming_of_corporate_industrial_systems_Practice_1.Controllers
{
    public class WordSearchController
    {
        private const string _totalWordText = "Общее количество слов в файле: ";
        private const string _targetWordText = "Количество повторений заданного слова ";
        private const string _emptyFilePathError = "Путь к файлу не может быть пустым.";
        private const string _fileNotFoundError = "Файл не найден: ";
        private const string _emptyWordError = "Искомое слово не может быть пустым.";
        private const string _promptFilePath = "Введите путь к файлу: ";
        private const string _promptWord = "Введите искомое слово: ";

        private readonly IWordSearchService _wordSearchService;

        public WordSearchController(IWordSearchService wordSearchService)
        {
            _wordSearchService = wordSearchService ?? throw new ArgumentNullException(nameof(wordSearchService));
        }

        public void Execute()
        {
            Console.Write(_promptFilePath);
            string? filePath = Console.ReadLine();
            ValidateFilePath(filePath);

            Console.Write(_promptWord);
            string? word = Console.ReadLine();
            ValidateWord(word);

            WordSearchResult result = _wordSearchService.CountOccurrencesAndTotalWords(filePath, word);

            Console.WriteLine($"{_totalWordText} {result.TotalWordCount}");
            Console.WriteLine($"{_targetWordText}'{word}' : {result.TargetWordCount}");
        }

        private void ValidateFilePath(string? filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new CommonException(_emptyFilePathError);
            }

            if (!System.IO.File.Exists(filePath))
            {
                throw new CommonException($"{_fileNotFoundError}{filePath}");
            }
        }

        private void ValidateWord(string? word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new CommonException(_emptyWordError);
            }
        }
    }
}
