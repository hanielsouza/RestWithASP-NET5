using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Model;

namespace RestWithASPNET5Udemy.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string userName);

        bool RevokeToken(string username);
        User RefreshUserInfo(User user);

    }
}
