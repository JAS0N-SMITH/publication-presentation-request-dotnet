using Backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Threading;

namespace Backend.Tests
{
    public class RequestsControllerTests
    {
        [Fact]
        public async Task SubmitRequest_ValidRequest_ReturnsCreatedResult()
        {
            // Arrange
            var controller = new RequestsController();
            var requestDto = new RequestDto
            {
                Title = "Test Request",
                Type = "Publication",
                Abstract = "Test Abstract",
                Authors = "Author1, Author2",
                SubmitterId = Guid.NewGuid(),
                CurrentStage = "Draft",
                Status = "Pending"
            };
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await controller.SubmitRequest(requestDto, cancellationToken);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.NotNull(createdResult.Value);
        }

        [Fact]
        public async Task SubmitRequest_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var controller = new RequestsController();
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await controller.SubmitRequest(null, cancellationToken);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetRequestById_ValidId_ReturnsOkResult()
        {
            // Arrange
            var controller = new RequestsController();
            var requestId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await controller.GetRequestById(requestId, cancellationToken);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var request = Assert.IsType<RequestDto>(okResult.Value);
            Assert.Equal(requestId, request.Id);
        }

        [Fact]
        public async Task GetAllRequests_ReturnsOkResultWithList()
        {
            // Arrange
            var controller = new RequestsController();
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await controller.GetAllRequests(cancellationToken);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var requests = Assert.IsAssignableFrom<System.Collections.Generic.List<RequestDto>>(okResult.Value);
            Assert.NotEmpty(requests);
        }
    }
}