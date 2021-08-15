using Exam.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.AggregatesModel.ExamAggregate
{
    public interface IExamRepository : IRepositoryBase<Exams>
    {
        Task<IEnumerable<Exams>> GetExamListAsync();
        Task<Exams> GetExamByIdAsync(string id);
    }
}
