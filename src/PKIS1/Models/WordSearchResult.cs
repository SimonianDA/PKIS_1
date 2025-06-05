using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_of_corporate_industrial_systems_Practice_1.Models
{
    /// <summary>
    /// Результат анализа текстового файла, содержащий общее количество слов и количество вхождений заданного слова.
    /// </summary>
    public class WordSearchResult
    {
        /// <summary>
        /// Общее количество слов в тексте.
        /// </summary>
        public int TotalWordCount { get; set; }

        /// <summary>
        /// Количество повторений искомого слова в тексте.
        /// </summary>
        public int TargetWordCount { get; set; }
    }
}
