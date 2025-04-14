using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        // POST: api/Requests
        [HttpPost]
        public async Task<IActionResult> SubmitRequest([FromBody] RequestDto requestDto, CancellationToken cancellationToken)
        {
            // Validate the request
            if (requestDto == null || string.IsNullOrEmpty(requestDto.Title))
            {
                return BadRequest("Invalid request data.");
            }

            // Simulate saving the request to the database
            var requestId = await Task.Run(() => Guid.NewGuid(), cancellationToken);

            // Return the created request ID
            return CreatedAtAction(nameof(GetRequestById), new { id = requestId }, new { Id = requestId });
        }

        // GET: api/Requests/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestById(Guid id, CancellationToken cancellationToken)
        {
            // Simulate fetching the request from the database
            var request = await Task.Run(() => new RequestDto
            {
                Id = id,
                Title = "Sample Request",
                Type = "Publication",
                Abstract = "This is a sample abstract.",
                Authors = "Author1, Author2",
                SubmitterId = Guid.NewGuid(),
                CurrentStage = "Draft",
                Status = "Pending"
            }, cancellationToken);

            return Ok(request);
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<IActionResult> GetAllRequests(CancellationToken cancellationToken)
        {
            // Simulate fetching all requests from the database
            var requests = await Task.Run(() => new List<RequestDto>
            {
                new RequestDto
                {
                    Id = Guid.NewGuid(),
                    Title = "Sample Request 1",
                    Type = "Publication",
                    Abstract = "Abstract 1",
                    Authors = "Author1, Author2",
                    SubmitterId = Guid.NewGuid(),
                    CurrentStage = "Draft",
                    Status = "Pending"
                },
                new RequestDto
                {
                    Id = Guid.NewGuid(),
                    Title = "Sample Request 2",
                    Type = "Presentation",
                    Abstract = "Abstract 2",
                    Authors = "Author3, Author4",
                    SubmitterId = Guid.NewGuid(),
                    CurrentStage = "Review",
                    Status = "Approved"
                }
            }, cancellationToken);

            return Ok(requests);
        }
    }

    public class RequestDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Abstract { get; set; } = string.Empty;
        public string Authors { get; set; } = string.Empty;
        public Guid SubmitterId { get; set; }
        public string CurrentStage { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}