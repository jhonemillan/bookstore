using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext c)
        {
            this.context = c;
            Category = new CategoryRepository(this.context);
            CoverType = new CoverTypeRepository(this.context);
        }

        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType {get; private set;}

        public void Dispose()
        {
            context.Dispose();
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
