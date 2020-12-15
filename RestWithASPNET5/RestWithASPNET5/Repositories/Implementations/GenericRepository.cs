using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Entities;
using RestWithASPNET5.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Base
    {
        private readonly MySQLContext _context;
        private readonly DbSet<T> _dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.SingleOrDefault(item => item.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return item;
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;

            var result = _dataset.SingleOrDefault(x => x.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();

                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return null;
        }

        public void Delete(long id)
        {
            var result = _dataset.SingleOrDefault(T => T.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _dataset.Remove(result);
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
            return _dataset.Any(item => item.Id.Equals(id));
        }
    }
}
