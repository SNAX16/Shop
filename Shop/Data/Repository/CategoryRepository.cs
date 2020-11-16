using Shop.Data.Interfacas;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent) => this.appDBContent = appDBContent;
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
