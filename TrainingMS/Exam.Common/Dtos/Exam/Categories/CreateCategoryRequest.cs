using System.ComponentModel.DataAnnotations;

namespace Exam.Common.Dtos.Exam.Categories
{
    public class CreateCategoryRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UrlPath { get; set; }
    }
}
