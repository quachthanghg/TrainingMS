using Exam.Common.Dtos.Exam.Questions;
using Exam.Common.Enums;
using Exam.Common.SeedWork;
using MediatR;
using System.Collections.Generic;

namespace Exam.API.Application.Commands.Questions
{
    public class UpdateQuestionCommand : IRequest<ApiResult<bool>>
    {
        public string Id { get; set; }

        public string Content { get; set; }


        public QuestionType QuestionType { get; set; }


        public Level Level { set; get; }


        public string CategoryId { get; set; }


        public List<AnswerDto> Answers { set; get; } = new List<AnswerDto>();

        public string Explain { get; set; }
    }
}
