using RestWithASPNET5.Models;
using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET5.Services
{
    public interface IPersonService
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);

    }
}
