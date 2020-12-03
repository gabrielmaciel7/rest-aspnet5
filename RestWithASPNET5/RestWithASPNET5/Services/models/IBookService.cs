using RestWithASPNET5.Models;
using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET5.Services
{
    public interface IBookService
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);

    }
}
