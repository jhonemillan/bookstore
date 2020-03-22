using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Repository
{
    public class CoverTypeRepository: Repository<CoverType>, ICoverTypeRepository
    {
         private readonly ApplicationDbContext context;
        public CoverTypeRepository(ApplicationDbContext c): base(c)
        {
            this.context = c;
        }

        public void Update(CoverType cover)
        {
            var c = context.CoverTypes.FirstOrDefault(r => r.Id == cover.Id);

            if (c != null)
            {
                c.Name = cover.Name;
            }
        }
    }
}