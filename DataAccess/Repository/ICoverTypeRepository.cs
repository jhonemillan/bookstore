using Models;

namespace DataAccess.Repository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
         void Update(CoverType entity);
    }
}