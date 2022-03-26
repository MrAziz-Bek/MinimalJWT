using MinimalJWT.Models;
using MinimalJWT.Repositories;

namespace MinimalJWT.Services;

public class UserService : IUserService
{
    public User Get(UserLogin userLogin)
        => UserRepository.Users.FirstOrDefault(u =>
            u.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) && u.Password.Equals(userLogin.Password));

    
}