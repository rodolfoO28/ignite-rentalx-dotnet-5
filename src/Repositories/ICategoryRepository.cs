using Rentalx.DTOs;
using Rentalx.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentalx.Repositories
{
    public interface ICategoryRepository
    {
        Task<IList<Category>> FindAll();
        Task<Category> FindByName(string name);
        Task Save(Category model);
    }
}