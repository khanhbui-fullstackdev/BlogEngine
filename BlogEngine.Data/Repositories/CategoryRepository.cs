using BlogEngine.Data.Infrastrutures;
using BlogEngine.Data.Repositories.IRepositories;
using BlogEngine.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlogEngine.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Category> GetAllCategoriesWithSubCategories()
        {
            return this.DbContext.Categories
                .Include(x => x.SubCategories) // when apply eager loading, Subcategory of navigation property should be change to ICollection
                .Where(x => x.Status);
        }
    }
}
