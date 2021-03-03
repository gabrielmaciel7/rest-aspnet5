using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Entities;
using RestWithASPNET5.Models.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNET5.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());

            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        public User ValidateCredentials(string userName)
        {
            return _context.Users.SingleOrDefault(u => (u.UserName == userName));
        }

        public User RefreshUserInfo(User user)
        {
            var result = _context.Users.Where(x => x.Id.Equals(user.Id)).FirstOrDefault();

            if (result == null) return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(user);
                _context.SaveChanges();

                return result;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
