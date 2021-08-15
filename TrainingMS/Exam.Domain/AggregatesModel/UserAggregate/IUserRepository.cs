using System.Threading.Tasks;

namespace Exam.Domain.AggregatesModel.UserAggregate
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string externalId);
    }
}
