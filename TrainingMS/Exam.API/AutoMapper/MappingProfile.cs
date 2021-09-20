using AutoMapper;
using Exam.API.Application.Queries.Exams.GetExamList;
using Exam.Common.Dtos.Exam.Categories;
using Exam.Domain.AggregatesModel.CategoryAggregate;
using Exam.Domain.AggregatesModel.ExamAggregate;

namespace Exam.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exams, ExamDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
