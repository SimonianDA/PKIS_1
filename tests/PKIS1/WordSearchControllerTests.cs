using Moq;
using Programming_of_corporate_industrial_systems_Practice_1.Controllers;
using Programming_of_corporate_industrial_systems_Practice_1.ErrorHandling.ErrorsTypes;
using Programming_of_corporate_industrial_systems_Practice_1.Services;
using Xunit;

namespace Programming_of_corporate_industrial_systems_Practice_1.Tests
{
    public class WordSearchControllerTests
    {
        private readonly Mock<IWordSearchService> _mockWordSearchService;
        private readonly WordSearchController _controller;

        public WordSearchControllerTests()
        {
            _mockWordSearchService = new Mock<IWordSearchService>();
            _controller = new WordSearchController(_mockWordSearchService.Object);
        }

        [Fact]
        public void Execute_EmptyFilePath_ThrowsCommonException()
        {
            // Arrange
            Console.SetIn(new System.IO.StringReader(""));
            Console.SetOut(new System.IO.StringWriter());

            // Act & Assert
            var exception = Assert.Throws<CommonException>(() => _controller.Execute());
            Assert.Equal("Путь к файлу не может быть пустым.", exception.Message);
        }

        [Fact]
        public void Execute_FileNotFound_ThrowsCommonException()
        {
            // Arrange
            Console.SetIn(new System.IO.StringReader("invalidPath.txt"));
            Console.SetOut(new System.IO.StringWriter());

            // Act & Assert
            var exception = Assert.Throws<CommonException>(() => _controller.Execute());
            Assert.Equal("Файл не найден: invalidPath.txt", exception.Message);
        }

        [Fact]
        public void Execute_EmptyWord_ThrowsCommonException()
        {
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
            string filePath = Path.Combine(projectRoot, "test.txt");
            // Arrange
            Console.SetIn(new System.IO.StringReader(filePath));
            Console.SetOut(new System.IO.StringWriter());

            // Act & Assert
            var exception = Assert.Throws<CommonException>(() => _controller.Execute());
            Assert.Equal("Искомое слово не может быть пустым.", exception.Message);
        }
    }
}