using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using RestWithASPNET5.Repositories;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET5.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IGenericRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonService(IGenericRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, int pageSize, int page)
        {          
            var size = pageSize < 1 ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            var query = @"select * from person p where 1 = 1 ";
            query += !string.IsNullOrWhiteSpace(name) ? $"and p.first_name like '%{name}%' " : "";
            query += $"order by p.first_name asc limit {size} offset {offset}";

            var countQuery = @"select count(*) from person p where 1 = 1 ";
            countQuery += !string.IsNullOrWhiteSpace(name) ? $"and p.first_name like '%{name}%' " : "";

            var people = _repository.FindWithPagedSearch(query);
            var totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO>() 
            { 
                CurrentPage = page,
                List = _converter.Parse(people),
                PageSize = size,
                TotalResults = totalResults
            };
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);

            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);

            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
