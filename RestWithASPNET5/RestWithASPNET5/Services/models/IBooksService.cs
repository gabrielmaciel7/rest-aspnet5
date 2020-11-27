using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Services
{
    public interface IBooksService
    {
        Books Create(Books book);
        Books FindById(long id);
        List<Books> FindAll();
        Books Update(Books book);
        void Delete(long id);

    }
}
