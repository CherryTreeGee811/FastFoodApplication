using FastFoodAPI.Controllers;
using FastFoodAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using FluentAssertions;
using FastFoodAPI.Messages;
using FastFoodAPI.Entities;


namespace FastFoodAPI.Tests.Controllers
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeManagerService> _mockEmployeeService;
        private EmployeeController _controller;


        [SetUp]
        public void Setup()
        {
            // Create mock for the service
            _mockEmployeeService = new Mock<IEmployeeManagerService>();
            
            // Create controller with mocked service
            _controller = new EmployeeController(_mockEmployeeService.Object);
        }


        [Test]
        public async Task GetAllEmployees_ReturnsOkResult_WithListOfEmployees()
        {
            // Arrange
            var employees = new List<EmployeeListDTO>
            {
                new() {
                    EmployeeId = "1", 
                    FirstName = "John", 
                    LastName = "Doe", 
                    EmailAddress = "john@example.com",
                    JobTitle = "Manager",
                    StationName = "Main Counter"
                }
            };
            
            _mockEmployeeService
                .Setup(service => service.GetAllEmployees())
                .ReturnsAsync(employees);

            // Act
            var result = await _controller.GetAllEmployees();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult?.Value.Should().BeEquivalentTo(employees);
        }


        [Test]
        public async Task GetEmployee_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var id = "1";
            var employee = new EmployeeListDTO { 
                EmployeeId = id, 
                FirstName = "John", 
                LastName = "Doe" 
            };
            
            _mockEmployeeService
                .Setup(service => service.GetEmployee(id))
                .ReturnsAsync(employee);

            // Act
            var result = await _controller.GetEmployee(id);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult?.Value.Should().BeEquivalentTo(employee);
        }


        [Test]
        public async Task GetEmployee_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var id = "999";
            _mockEmployeeService
                .Setup(service => service.GetEmployee(id))
                .ReturnsAsync((EmployeeListDTO)null!);

            // Act
            var result = await _controller.GetEmployee(id);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }


        [Test]
        public async Task UpdateEmployee_WithValidIdAndData_ReturnsOkResult()
        {
            // Arrange
            var id = "1";
            var updateDto = new UpdateEmployeeDto
            {
                FirstName = "Updated",
                LastName = "Name"
            };
            
            var employee = new Employee { Id = id, FirstName = "Updated", LastName = "Name" };
            
            _mockEmployeeService
                .Setup(service => service.UpdateEmployee(id, updateDto))
                .ReturnsAsync((employee, true, string.Empty));

            // Act
            var result = await _controller.UpdateEmployee(id, updateDto);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }


        [Test]
        public async Task DeleteEmployee_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var id = "1";
            
            _mockEmployeeService
                .Setup(service => service.DeleteEmployee(id))
                .ReturnsAsync((true, string.Empty));

            // Act
            var result = await _controller.DeleteEmployee(id);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
