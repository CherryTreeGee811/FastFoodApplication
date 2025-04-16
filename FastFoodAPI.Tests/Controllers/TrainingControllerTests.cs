using FastFoodAPI.Controllers;
using FastFoodAPI.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using FastFoodAPI.Services;

namespace FastFoodAPI.Tests.Controllers
{
    [TestFixture]
    public class TrainingControllerTests
    {
        private Mock<ITrainingService> _mockTrainingService;
        private Mock<ILogger<TrainingController>> _mockLogger;
        private TrainingController _controller;

        [SetUp]
        public void Setup()
        {
            // Create mocks for dependencies
            _mockTrainingService = new Mock<ITrainingService>();
            _mockLogger = new Mock<ILogger<TrainingController>>();
            
            // Create controller with mocked dependencies
            _controller = new TrainingController(_mockTrainingService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetEmployeeTrainings_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var employeeId = "1";
            var trainings = new List<TrainingModuleDTO>
            {
                new TrainingModuleDTO { 
                    TrainingId = 1, 
                    TrainingName = "Food Safety", 
                    TrainingDescription = "Basic food handling and safety procedures",
                    CompletedTraining = true,
                    DateCompleted = DateTime.Now.AddMonths(-1)
                },
                new TrainingModuleDTO { 
                    TrainingId = 2, 
                    TrainingName = "Customer Service", 
                    TrainingDescription = "Effective customer interaction",
                    CompletedTraining = false,
                    DateCompleted = null
                }
            };
            
            _mockTrainingService
                .Setup(service => service.GetEmployeeTrainingsAsync(employeeId))
                .ReturnsAsync(trainings);

            // Act
            var result = await _controller.GetEmployeeTrainings(employeeId);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(trainings);
        }

        [Test]
        public async Task GetEmployeeTrainings_WhenExceptionOccurs_ReturnsStatusCode500()
        {
            // Arrange
            var employeeId = "1";
            
            _mockTrainingService
                .Setup(service => service.GetEmployeeTrainingsAsync(employeeId))
                .ThrowsAsync(new Exception("Database connection failed"));

            // Act
            var result = await _controller.GetEmployeeTrainings(employeeId);

            // Assert
            result.Should().BeOfType<ObjectResult>();
            var statusCodeResult = result as ObjectResult;
            statusCodeResult.StatusCode.Should().Be(500);
            statusCodeResult.Value.Should().Be("An error occurred while retrieving employee trainings.");
        }

        [Test]
        public async Task CompleteTraining_WithValidIdAndTraining_ReturnsOkResult()
        {
            // Arrange
            var employeeId = "1";
            var trainingId = 2;
            var training = new TrainingModuleDTO { 
                TrainingId = trainingId, 
                TrainingName = "Customer Service", 
                CompletedTraining = true,
                DateCompleted = DateTime.Now
            };
            
            _mockTrainingService
                .Setup(service => service.CompleteTrainingAsync(employeeId, trainingId))
                .ReturnsAsync((training, true, string.Empty));

            // Act
            var result = await _controller.CompleteTraining(employeeId, trainingId);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(training);
        }

        [Test]
        public async Task CompleteTraining_WithInvalidTraining_ReturnsNotFound()
        {
            // Arrange
            var employeeId = "1";
            var trainingId = 99;
            
            _mockTrainingService
                .Setup(service => service.CompleteTrainingAsync(employeeId, trainingId))
                .ReturnsAsync((null, false, "Training with ID 99 not found for employee 1"));

            // Act
            var result = await _controller.CompleteTraining(employeeId, trainingId);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
            var notFoundResult = result as NotFoundObjectResult;
            notFoundResult.Value.Should().Be("Training with ID 99 not found for employee 1");
        }

        [Test]
        public async Task CompleteTraining_WithAlreadyCompletedTraining_ReturnsBadRequest()
        {
            // Arrange
            var employeeId = "1";
            var trainingId = 1;
            
            _mockTrainingService
                .Setup(service => service.CompleteTrainingAsync(employeeId, trainingId))
                .ReturnsAsync((null, false, "Training is already completed"));

            // Act
            var result = await _controller.CompleteTraining(employeeId, trainingId);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
            var badRequestResult = result as BadRequestObjectResult;
            badRequestResult.Value.Should().Be("Training is already completed");
        }

        [Test]
        public async Task CompleteTraining_WhenExceptionOccurs_ReturnsStatusCode500()
        {
            // Arrange
            var employeeId = "1";
            var trainingId = 2;
            
            _mockTrainingService
                .Setup(service => service.CompleteTrainingAsync(employeeId, trainingId))
                .ThrowsAsync(new Exception("Database connection failed"));

            // Act
            var result = await _controller.CompleteTraining(employeeId, trainingId);

            // Assert
            result.Should().BeOfType<ObjectResult>();
            var statusCodeResult = result as ObjectResult;
            statusCodeResult.StatusCode.Should().Be(500);
            statusCodeResult.Value.Should().Be("An error occurred while updating the training status.");
        }
    }
}
