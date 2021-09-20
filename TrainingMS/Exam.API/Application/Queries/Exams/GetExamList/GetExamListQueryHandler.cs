using AutoMapper;
using Exam.Domain.AggregatesModel.ExamAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.API.Application.Queries.Exams.GetExamList
{
    public class GetExamListQueryHandler : IRequestHandler<GetExamListQuery, IEnumerable<ExamDto>>
    {
        private readonly IExamRepository _examRepository;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly IMapper _mapper;
        private readonly ILogger<GetExamListQueryHandler> _logger;
        public GetExamListQueryHandler(IExamRepository examRepository, IClientSessionHandle clientSessionHandle, IMapper mapper, ILogger<GetExamListQueryHandler> logger)
        {
            _examRepository = examRepository;
            _clientSessionHandle = clientSessionHandle;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<ExamDto>> Handle(GetExamListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: Query");
            var exams = await _examRepository.GetExamListAsync();
            var examDtos = _mapper.Map<IEnumerable<ExamDto>>(exams);
            _logger.LogInformation("END: Query");
            return examDtos;
        }
    }
}
