using Microsoft.EntityFrameworkCore;
using Rentalx.DTOs;
using Rentalx.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentalx.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RentalxContext _context;

        public CategoryRepository(RentalxContext context)
        {
            _context = context;
        }

        public async Task<IList<Category>> FindAll()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> FindByName(string name)
        {
            return await _context.Category.FirstOrDefaultAsync(category => category.Name == name);
        }

        public async Task Save(Category model)
        {
            _context.Category.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}