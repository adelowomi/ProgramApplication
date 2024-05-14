using Xunit;
using NSubstitute;
using ProgramApplication;
using NSubstitute.ExceptionExtensions;

namespace ProgramApplicationTests
{
    public class QuestionTypeServiceTest
    {
        private readonly IBaseRepository<QuestionType> _questionTypeRepository;
        private readonly QuestionTypeService _questionTypeService;

        public QuestionTypeServiceTest()
        {
            _questionTypeRepository = Substitute.For<IBaseRepository<QuestionType>>();
            _questionTypeService = new QuestionTypeService(_questionTypeRepository);
        }

        [Fact]
        public async Task CreateQuestionType_PositiveTest()
        {
            // Arrange
            var questionTypeModel = new QuestionTypeModel();
            questionTypeModel.Name = "Test Question Type";
            questionTypeModel.Description = "Test Question Type Description";

            _questionTypeRepository.CreateAndReturn(Arg.Any<QuestionType>()).Returns(new QuestionType
            {
                Id = Guid.NewGuid(),
                Name = questionTypeModel.Name,
                Description = questionTypeModel.Description
            });

            // Act
            var result = await _questionTypeService.CreateQuestionType(questionTypeModel);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Status);
            Assert.NotNull(result.Data);
            // Add more assertions as needed
        }

        [Fact]
        public async Task CreateQuestionType_NegativeTest()
        {
            // Arrange
            var questionTypeModel = new QuestionTypeModel();

            // Mock the repository to throw an exception or return a specific result
            _questionTypeRepository.CreateAndReturn(Arg.Any<QuestionType>()).Throws(new Exception("Failed to create question type"));

            // Act
            var result = await _questionTypeService.CreateQuestionType(questionTypeModel);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Status);
            Assert.Null(result.Data);
            // Add more assertions as needed
        }

        [Fact]
        public async Task GetAllQuestionTypes_PositiveTest()
        {
            // Arrange
            _questionTypeRepository.GetAll().Returns(new List<QuestionType>
            {
                new QuestionType
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Question Type 1",
                    Description = "Test Question Type Description 1"
                },
                new QuestionType
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Question Type 2",
                    Description = "Test Question Type Description 2"
                }
            });

            // Act
            var result = await _questionTypeService.GetAllQuestionTypes();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Status);
            Assert.NotNull(result.Data);
            Assert.Equal(2, result.Data.Count());
            // Add more assertions as needed
        }

        [Fact]
        public async Task GetAllQuestionTypes_NegativeTest()
        {
            // Arrange

            // Mock the repository to throw an exception or return a specific result
            _questionTypeRepository.GetAll().Throws(new Exception("Failed to get question types"));

            // Act
            var result = await _questionTypeService.GetAllQuestionTypes();

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Status);
            Assert.Null(result.Data);
            // Add more assertions as needed
        }

        [Fact]
        public async Task UpdateQuestionType_PositiveTest()
        {
            // Arrange
            var questionTypeModel = new QuestionTypeModel();
            questionTypeModel.Id = Guid.NewGuid();
            questionTypeModel.Name = "Test Question Type";
            questionTypeModel.Description = "Test Question Type Description";

            _questionTypeRepository.Update(Arg.Any<QuestionType>()).Returns(new QuestionType
            {
                Id = questionTypeModel.Id,
                Name = questionTypeModel.Name,
                Description = questionTypeModel.Description
            });

            // Act
            var result = await _questionTypeService.UpdateQuestionType(questionTypeModel);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Status);
            Assert.NotNull(result.Data);
            // Add more assertions as needed
        }

        [Fact]
        public async Task UpdateQuestionType_NegativeTest()
        {
            // Arrange
            var questionTypeModel = new QuestionTypeModel();

            // Mock the repository to throw an exception or return a specific result
            _questionTypeRepository.Update(Arg.Any<QuestionType>()).Throws(new Exception("Failed to update question type"));

            // Act
            var result = await _questionTypeService.UpdateQuestionType(questionTypeModel);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Status);
            Assert.Null(result.Data);
            // Add more assertions as needed
        }
    }
}
