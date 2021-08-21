﻿using Exam.Domain.AggregatesModel.ExamResultAggregate;
using Exam.Infrastructure.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Infrastructure.Repositories
{
    public class ExamResultRepository : BaseRepository<ExamResult>, IExamResultRepository
    {
        public ExamResultRepository(IMongoClient mongoClient, IClientSessionHandle clientSessionHandle, IOptions<ExamSettings> settings, IMediator mediator) : base(mongoClient, clientSessionHandle, settings, mediator, Constants.Collections.ExamResult)
        {
        }

        public async Task<ExamResult> GetDetails(string userId, string examId)
        {
            var filter = Builders<ExamResult>.Filter.Where(s => s.ExamId == examId && s.UserId == userId);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
