using UserRegistrationApp.Core.Models;

namespace UserRegistrationApp.Core.Interfaces
{
    public interface IUserRepository
    {
        void Save(User user);
    }
}