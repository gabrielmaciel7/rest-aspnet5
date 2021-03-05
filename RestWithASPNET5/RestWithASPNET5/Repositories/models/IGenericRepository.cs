using RestWithASPNET5.Entities;
using System.Collections.Generic;

namespace RestWithASPNET5.Repositories
{
    public interface IGenericRepository<T> where T : Base
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        List<T> FindWithPagedSearch(string query);
        T Update(T item);
        void Delete(long id);

        bool Exists(long id);
        int GetCount(string query);

    }
}
