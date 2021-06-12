using Microsoft.AspNetCore.Mvc;
using Rentalx.DTOs;
using Rentalx.Models;
using Rentalx.Repositories;
using Rentalx.Services;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Rentalx.Controllers
{
    [ApiController]
    [Route("/categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICreateCategoryService _createCategoryService;

        public CategoryController(ICategoryRepository categoryRepository, ICreateCategoryService createCategoryService)
        {
            _categoryRepository = categoryRepository;
            _createCategoryService = createCategoryService;
        }

        [HttpGet]
        public async Task<IList<Category>> Index()
        {
            return await _categoryRepository.FindAll();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCategoryDTO data)
        {
            try
            {
                var category = await _createCategoryService.Execute(data);

                return CreatedAtAction(nameof(Index), category);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}