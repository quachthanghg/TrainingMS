﻿using Exam.Common.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exam.Common.Dtos.Exam.Questions
{
    public class UpdateQuestionRequest
    {
        [Required]
        public string Id { get; set; }

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
