﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API.Application.Queries.GetExamList
{
    public class GetExamListQuery : IRequest<IEnumerable<ExamDto>>
    {
    }
}
