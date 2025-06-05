using Programming_of_corporate_industrial_systems_Practice_1.ErrorHandling.ErrorsTypes;
using Programming_of_corporate_industrial_systems_Practice_1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Programming_of_corporate_industrial_systems_Practice_1.Tests
{
    public class WordSearchServiceTests
    {
        private readonly WordSearchService _service;

        public WordSearchServiceTests()
        {
            _service = new WordSearchService();
        }

        [Fact]
        public void CountOccurrencesAndTotalWords_ValidFile_ReturnsCorrectCounts()
        {
            // Arrange
            string filePath = "test.txt";
            string searchWord = "test";
            File.WriteAllText(filePath, "This is a test. This test is only a test.");

            // Act
            var result = _service.CountOccurrencesAndTotalWords(filePath, searchWord);

            // Assert
            Assert.Equal(3, result.TargetWordCount); // "test" встречается 3 раза
            Assert.Equal(10, result.TotalWordCount); // Всего слов 10

            // Cleanup
            File.Delete(filePath);
        }

        [Fact]
        public void CountOccurrencesAndTotalWords_FileNotFound_ThrowsCommonException()
        {
            // Arrange
            string filePath = "invalidPath.txt";
            string searchWord = "test";

            // Act & Assert
            var exception = Assert.Throws<CommonException>(() => _service.CountOccurrencesAndTotalWords(filePath, searchWord));
            Assert.Equal($"Файл не найден: {filePath}", exception.Message);
        }

        [Fact]
        public void CountOccurrencesAndTotalWords_EmptyFile_ReturnsZeroCounts()
        {
            // Arrange
            string filePath = "empty.txt";
            File.WriteAllText(filePath, "");

            // Act
            var result = _service.CountOccurrencesAndTotalWords(filePath, "test");

            // Assert
            Assert.Equal(0, result.TargetWordCount); // "test" не встречается
            Assert.Equal(0, result.TotalWordCount); // Всего слов 0

            // Cleanup
            File.Delete(filePath);
        }
    }
}
