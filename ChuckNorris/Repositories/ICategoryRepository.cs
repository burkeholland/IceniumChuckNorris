using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RelationalChuck.Models;

namespace ChuckNorris.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDto GetCategory(int id);
    }
}