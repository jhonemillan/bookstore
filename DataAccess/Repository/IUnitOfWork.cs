using System;

namespace DataAccess.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        ICategoryRepository Category { get; }
        ICoverTypeRepository CoverType {get;}

        void Save();
    }
}