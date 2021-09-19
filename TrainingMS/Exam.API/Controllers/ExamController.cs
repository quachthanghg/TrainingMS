using Exam.API.Application.Queries.GetExamList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ExamController> _logger;
        public ExamController(IMediator mediator, ILogger<ExamController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetExams()
        {
            _logger.LogInformation("BEGIN: GetExams");

            var query = new GetExamListQuery();
            var result = await _mediator.Send(query);

            _logger.LogInformation("END: GetExams");
            return Ok(result);
        }
    }
}
