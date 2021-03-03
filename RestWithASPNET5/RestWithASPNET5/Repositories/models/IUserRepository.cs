using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Entities;
using System.Security.Cryptography;

namespace RestWithASPNET5.Repositories
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string userName);
        User RefreshUserInfo(User user);
    }
}
