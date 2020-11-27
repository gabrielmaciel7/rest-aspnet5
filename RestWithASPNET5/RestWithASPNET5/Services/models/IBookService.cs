using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Services
{
    public interface IBookService
    {
        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);

    }
}
