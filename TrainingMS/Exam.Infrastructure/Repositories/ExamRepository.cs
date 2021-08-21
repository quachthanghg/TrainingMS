using System.Collections.Generic;
using System.Threading.Tasks;
using Exam.Domain.AggregatesModel.ExamAggregate;
using Exam.Infrastructure.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Exam.Infrastructure.Repositories
{
    public class ExamRepository : BaseRepository<Exams>, IExamRepository
    {
        public ExamRepository(
            IMongoClient mongoClient,
            IClientSessionHandle clientSessionHandle,
            IOptions<ExamSettings> settings,
            IMediator mediator)
        : base(mongoClient, clientSessionHandle, settings, mediator, Constants.Collections.Exam)
        {
        }

        public async Task<Exams> GetExamByIdAsync(string id)
        {
            var filter = Builders<Exams>.Filter.Eq(s => s.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Exams>> GetExamListAsync()
        {
            return await Collection.AsQueryable().ToListAsync();
        }
    }
}
