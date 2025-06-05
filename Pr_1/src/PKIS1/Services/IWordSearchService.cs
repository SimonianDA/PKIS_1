using Programming_of_corporate_industrial_systems_Practice_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_of_corporate_industrial_systems_Practice_1.Services
{
    /// <summary>
    /// Сервис для работы с текстовыми файлами.
    /// </summary>
    public interface IWordSearchService
    {
        /// <summary>
        /// Получает количество слов и поиск заданного слова в тексте.
        /// </summary>
        /// <param name="filePath">Путь к текстовому файлу.</param>
        /// <param name="word">Заданное слово для поиска.</param>
        /// <returns>Общее количество слов и количество повторений заданного слова в файле</returns>
        WordSearchResult CountOccurrencesAndTotalWords(string filePath, string word);
    }
}
