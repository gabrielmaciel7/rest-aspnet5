using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Repositories
{
    public interface IBooksRepository
    {
        Books Create(Books person);
        Books FindById(long id);
        List<Books> FindAll();
        Books Update(Books person);
        void Delete(long id);
        bool Exists(long id);

    }
}
