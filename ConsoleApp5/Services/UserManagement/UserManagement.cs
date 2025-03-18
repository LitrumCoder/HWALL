using System;
using System.Collections.Generic;
using LibraryManagement.Entities;

namespace LibraryManagement.UserManagement
{
    public class UserManager
    {
        private List<User> users = new List<User>();

        // Добавление пользователя
        public void AddUser(User user)
        {
            users.Add(user);
            Console.WriteLine($"Пользователь {user.Name} добавлен.");
        }

        // Редактирование пользователя
        public void EditUser(int userId, string newName, string newEmail)
        {
            var user = users.Find(u => u.Id == userId);
            if (user != null)
            {
                user.Name = newName;
                user.Email = newEmail;
                Console.WriteLine($"Пользователь {user.Name} отредактирован.");
            }
            else
            {
                Console.WriteLine("Пользователь не найден.");
            }
        }

        // Удаление пользователя
        public void RemoveUser(int userId)
        {
            var user = users.Find(u => u.Id == userId);
            if (user != null)
            {
                users.Remove(user);
                Console.WriteLine($"Пользователь {user.Name} удален.");
            }
            else
            {
                Console.WriteLine("Пользователь не найден.");
            }
        }

        // Получение всех пользователей
        public List<User> GetAllUsers()
        {
            return users;
        }
    }
}