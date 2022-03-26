using MinimalJWT.Models;

namespace MinimalJWT.Services;

public interface IUserService
{
    User Get(UserLogin userLogin);
}