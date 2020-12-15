using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Entities;

namespace RestWithASPNET5.Repositories
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
    }
}
