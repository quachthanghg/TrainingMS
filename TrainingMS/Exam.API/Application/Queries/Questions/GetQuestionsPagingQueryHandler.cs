﻿using AutoMapper;
using Exam.Common.Dtos.Exam.Questions;
using Exam.Common.SeedWork;
using Exam.Domain.AggregatesModel.QuestionAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.API.Application.Queries.Questions
{
    public class GetQuestionsPagingQueryHandler : IRequestHandler<GetQuestionsPagingQuery, PagedList<QuestionDto>>
    {

        private readonly IQuestionRepository _QuestionRepository;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly IMapper _mapper;
        private readonly ILogger<GetQuestionsPagingQueryHandler> _logger;

        public GetQuestionsPagingQueryHandler(
                IQuestionRepository QuestionRepository,
                IMapper mapper,
                ILogger<GetQuestionsPagingQueryHandler> logger,
                IClientSessionHandle clientSessionHandle
            )
        {
            _QuestionRepository = QuestionRepository ?? throw new ArgumentNullException(nameof(QuestionRepository));
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(_clientSessionHandle));
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<PagedList<QuestionDto>> Handle(GetQuestionsPagingQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetHomeExamListQueryHandler");

            var result = await _QuestionRepository.GetQuestionsPagingAsync(request.CategoryId,
                request.SearchKeyword,
                request.PageIndex,
                request.PageSize);

            var items = _mapper.Map<List<QuestionDto>>(result.Items);

            _logger.LogInformation("END: GetHomeExamListQueryHandler");

            return new PagedList<QuestionDto>(items, result.MetaData.TotalCount, request.PageIndex, request.PageSize);
        }
    }
}
