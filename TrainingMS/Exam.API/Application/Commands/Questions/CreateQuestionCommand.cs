using Exam.Common.Dtos.Exam.Questions;
using Exam.Common.Enums;
using Exam.Common.SeedWork;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exam.API.Application.Commands.Questions
{
    public class CreateQuestionCommand : IRequest<ApiResult<QuestionDto>>
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public QuestionType QuestionType { get; set; }

        [Required]
        public Level Level { set; get; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public List<AnswerDto> Answers { set; get; } = new List<AnswerDto>();

        public string Explain { get; set; }
    }
}
