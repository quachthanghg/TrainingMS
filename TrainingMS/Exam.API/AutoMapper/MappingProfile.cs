using AutoMapper;
using Exam.API.Application.Queries.GetExamList;
using Exam.Domain.AggregatesModel.ExamAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Exams, ExamDto>().ReverseMap();
            //CreateMap<UserDto, User>();
        }
    }
}
