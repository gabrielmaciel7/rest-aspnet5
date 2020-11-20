using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Services
{
    interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);

    }
}
