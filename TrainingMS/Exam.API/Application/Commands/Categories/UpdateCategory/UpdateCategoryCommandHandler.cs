using Exam.Domain.AggregatesModel.CategoryAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.API.Application.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(
                ICategoryRepository categoryRepository,
                ILogger<UpdateCategoryCommandHandler> logger
            )
        {
            _categoryRepository = categoryRepository;
            _logger = logger;

        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _categoryRepository.GetCategoriesByIdAsync(request.Id);
            if (itemToUpdate == null)
            {
                _logger.LogError($"Item is not found {request.Id}");
                return false;
            }

            itemToUpdate.Name = request.Name;
            itemToUpdate.UrlPath = request.UrlPath;
            try
            {
                await _categoryRepository.UpdateAsync(itemToUpdate);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                throw;
            }

            return true;
        }
    }
}
