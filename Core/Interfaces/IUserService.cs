using UserRegistrationApp.Core.Models;
using System;

namespace UserRegistrationApp.Core.Interfaces
{
    public interface IUserService
    {
        void RegisterUser(User user);
        event Action<User> OnUserCreated;
    }
}