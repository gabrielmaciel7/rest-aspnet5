using RestWithASPNET5.Models;
using RestWithASPNET5.Repositories;
using System.Collections.Generic;

namespace RestWithASPNET5.Services.Implementations
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _bookRepository;

        public BooksService(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Books> FindAll()
        {
            return _bookRepository.FindAll();
        }

        public Books FindById(long id)
        {
            return _bookRepository.FindById(id);
        }

        public Books Create(Books book)
        {
            return _bookRepository.Create(book);
        }

        public Books Update(Books book)
        {
            return _bookRepository.Update(book);
        }

        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }
    }
}
