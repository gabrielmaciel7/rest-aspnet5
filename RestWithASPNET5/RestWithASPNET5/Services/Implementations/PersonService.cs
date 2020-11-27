using RestWithASPNET5.Models;
using RestWithASPNET5.Repositories;
using System.Collections.Generic;

namespace RestWithASPNET5.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<Person> FindAll()
        {
            return _personRepository.FindAll();
        }

        public Person FindById(long id)
        {
            return _personRepository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }

        public Person Update(Person person)
        {
            return _personRepository.Update(person);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }
    }
}
