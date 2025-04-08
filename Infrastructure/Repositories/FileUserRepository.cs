using UserRegistrationApp.Core.Interfaces;
using UserRegistrationApp.Core.Models;
using System;
using System.IO;
using UserRegistrationApp.Core.Exceptions;

namespace UserRegistrationApp.Infrastructure.Repositories
{
    public class FileUserRepository : IUserRepository
    {
        private const string FilePath = "users.txt";

        public void Save(User user)
        {
            try
            {
                var userData = $"{DateTime.Now}: {user.Name}, {user.Age} лет";
                File.AppendAllText(FilePath, userData + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Ошибка при сохранении пользователя", ex);
            }
        }
    }
}