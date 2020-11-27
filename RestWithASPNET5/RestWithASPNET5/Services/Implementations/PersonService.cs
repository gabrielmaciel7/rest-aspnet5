using RestWithASPNET5.Models;
using RestWithASPNET5.Repositories;
using System.Collections.Generic;

namespace RestWithASPNET5.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IGenericRepository<Person> _repository;

        public PersonService(IGenericRepository<Person> repository)
        {
            _repository = repository;
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
