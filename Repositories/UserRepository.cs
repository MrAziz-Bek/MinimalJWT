using MinimalJWT.Models;

namespace MinimalJWT.Repositories;

public class UserRepository
{
    public static List<User> Users = new()
    {
        new User()
        {
            Username = "aziz_admin",
            EmailAddress = "aziz.admin@email.com",
            Password = "Pa$$w0rd",
            Firstname = "Aziz",
            Lastname = "Rogers",
            Role = "Administrator"
        },
        new User()
        {
            Username = "lydia_standart",
            EmailAddress = "lydia.standart@email.com",
            Password = "MyPass_w0rd",
            Firstname = "Elyse",
            Lastname = "Burton",
            Role = "Standart"
        }
    };
}