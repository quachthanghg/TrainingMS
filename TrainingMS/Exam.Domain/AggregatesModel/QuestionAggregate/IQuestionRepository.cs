using Exam.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.AggregatesModel.QuestionAggregate
{
    public interface IQuestionRepository : IRepositoryBase<Question>
    {
    }
}
