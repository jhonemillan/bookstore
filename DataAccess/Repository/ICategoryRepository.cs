using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        void Update(Category category);
    }
}
