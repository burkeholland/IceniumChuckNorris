using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RelationalChuck.Models;

namespace ChuckNorris.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var cats = new List<CategoryDto>();
            using (var db = new ChuckNorrisContext())
            {
                cats.AddRange(
                    db.Categories.Select(x => new CategoryDto()
                    {
                        CategoryId = x.CategoryId,
                        Description = x.Description
                    })
                );
            }
            return cats;
        }

        public CategoryDto GetCategory(int id)
        {
            CategoryDto cat;
            using (var db = new ChuckNorrisContext())
            {
                var result = db.Categories.First(x => x.CategoryId == id);
                cat = new CategoryDto()
                {
                    CategoryId = result.CategoryId, 
                    Description = result.Description
                };
            }
            return cat;
        }
    }
}