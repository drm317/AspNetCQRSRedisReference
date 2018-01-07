using System;
using System.Collections.Generic;

namespace AspNetCoreCqrsRedis.Model.ReadModel.Repository
{
    public interface IBaseRepository<T>
    {
        T GetByID(Guid id);
        List<T> GetMultiple(List<Guid> ids);
        bool Exists(Guid id);
        void Save(T item);
    }
}