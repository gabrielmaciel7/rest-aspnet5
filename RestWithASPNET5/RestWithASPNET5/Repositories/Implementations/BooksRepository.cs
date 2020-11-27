using RestWithASPNET5.Models;
using RestWithASPNET5.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Repositories.Implementations
{
    public class BooksRepository : IBooksRepository
    {
        private MySQLContext _context;

        public BooksRepository(MySQLContext context)
        {
            _context = context;
        }

        public List<Books> FindAll()
        {
            return _context.Books.ToList();
        }

        public Books FindById(long id)
        {
            return _context.Books.SingleOrDefault(Books => Books.Id.Equals(id));
        }

        public Books Create(Books book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return book;
        }

        public Books Update(Books book)
        {
            if (!Exists(book.Id)) return null;

            var result = _context.Books.SingleOrDefault(Books => Books.Id.Equals(book.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(Books => Books.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(Books => Books.Id.Equals(id));
        }
    }
}
