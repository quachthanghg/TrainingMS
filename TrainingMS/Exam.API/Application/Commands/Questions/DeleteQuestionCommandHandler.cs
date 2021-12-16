using MediatR;
using Microsoft.Extensions.Logging;
using Exam.Common.SeedWork;
using System.Threading;
using System.Threading.Tasks;
using Exam.Domain.AggregatesModel.QuestionAggregate;

namespace Exam.API.Application.Commands.Questions
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, ApiResult<bool>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ILogger<DeleteQuestionCommandHandler> _logger;

        public DeleteQuestionCommandHandler(
                IQuestionRepository QuestionRepository,
                ILogger<DeleteQuestionCommandHandler> logger
            )
        {
            _questionRepository = QuestionRepository;
            _logger = logger;

        }

        public async Task<ApiResult<bool>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _questionRepository.GetQuestionsByIdAsync(request.Id);
            if (itemToUpdate == null)
            {
                _logger.LogError($"Item is not found {request.Id}");
                return new ApiErrorResult<bool>($"Item is not found {request.Id}");
            }

            await _questionRepository.DeleteAsync(request.Id);
            return new ApiSuccessResult<bool>(true, "Delete successful");
        }
    }
}
