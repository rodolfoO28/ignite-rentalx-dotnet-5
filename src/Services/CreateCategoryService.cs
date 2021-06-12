using System;
using System.Threading.Tasks;
using Rentalx.DTOs;
using Rentalx.Models;
using Rentalx.Repositories;

namespace Rentalx.Services
{
    public interface ICreateCategoryService : IService<CreateCategoryDTO, object> { }
    public class CreateCategoryService : ICreateCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<object> Execute(CreateCategoryDTO data)
        {
            var categoryAlreadyExists = await _categoryRepository.FindByName(data.Name);
            if (categoryAlreadyExists != null)
                throw new ArgumentException("Category already exists.");

            var category = new Category(data.Name, data.Description);

            await _categoryRepository.Save(category);

            return new { category.Name, category.Description, category.Id };
        }
    }
}