using Programming_of_corporate_industrial_systems_Practice_1.ErrorHandling.ErrorsTypes;
using Programming_of_corporate_industrial_systems_Practice_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_of_corporate_industrial_systems_Practice_1.Services
{
    public class WordSearchService : IWordSearchService
    {
        private static readonly string _fileNotFoundExceptionMessage = "Файл не найден: ";

        public WordSearchResult CountOccurrencesAndTotalWords(string filePath, string searchWord)
        {
            if (!File.Exists(filePath))
                throw new CommonException($"{_fileNotFoundExceptionMessage}{filePath}");

            int targetWordCount = 0;
            int totalWordsCount = 0;

            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    targetWordCount += CountTargetWord(line, searchWord);
                    totalWordsCount += CountTotalWords(line);
                }
            }
            WordSearchResult wordSearchResult = new WordSearchResult();
            wordSearchResult.TotalWordCount = totalWordsCount;
            wordSearchResult.TargetWordCount = targetWordCount;
            return wordSearchResult;
        }

        private int CountTargetWord(string line, string word)
        {
            int count = 0;
            int index = 0;

            while ((index = line.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }

            return count;
        }

        private int CountTotalWords(string line)
        {
            var words = line.Split(new char[] { ' ', '\t', '\n', '\r', ',', '.', '!', '?' },
                                    StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }
}
