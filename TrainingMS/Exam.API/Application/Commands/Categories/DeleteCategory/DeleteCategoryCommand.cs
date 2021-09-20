using MediatR;

namespace Exam.API.Application.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public DeleteCategoryCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
