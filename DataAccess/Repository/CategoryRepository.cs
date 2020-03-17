using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repository
{
   public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext c): base(c)
        {
            this.context = c;
        }

        public void Update(Category category)
        {
            var c = context.Categories.FirstOrDefault(r => r.Id == category.Id);

            if (c != null)
            {
                c.Name = category.Name;
            }
        }
    }
}
