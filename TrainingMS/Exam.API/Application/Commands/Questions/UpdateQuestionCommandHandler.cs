﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Exam.Common.Dtos.Exam.Questions;
using Exam.Common.SeedWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Exam.Domain.AggregatesModel.QuestionAggregate;

namespace Exam.API.Application.Commands.Questions
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, ApiResult<bool>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ILogger<UpdateQuestionCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateQuestionCommandHandler(
                IQuestionRepository QuestionRepository,
                ILogger<UpdateQuestionCommandHandler> logger, IMapper mapper
            )
        {
            _questionRepository = QuestionRepository;
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<ApiResult<bool>> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _questionRepository.GetQuestionsByIdAsync(request.Id);
            if (itemToUpdate == null)
            {
                _logger.LogError($"Item is not found {request.Id}");
                return new ApiErrorResult<bool>($"Item is not found {request.Id}");
            }

            itemToUpdate.Content = request.Content;
            itemToUpdate.QuestionType = request.QuestionType;
            itemToUpdate.Level = request.Level;
            itemToUpdate.CategoryId = request.CategoryId;
            var answers = _mapper.Map<List<AnswerDto>, List<Answer>>(request.Answers);
            itemToUpdate.Answers = answers;

            itemToUpdate.Explain = request.Explain;


            await _questionRepository.UpdateAsync(itemToUpdate);

            return new ApiSuccessResult<bool>(true, "Delete successful");
        }
    }
}
