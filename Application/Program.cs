using UserRegistrationApp.Core.Interfaces;
using UserRegistrationApp.Core.Models;
using UserRegistrationApp.Core.Services;
using UserRegistrationApp.Infrastructure.Repositories;
using UserRegistrationApp.Core.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Настройка зависимостей
            IUserRepository repository = new FileUserRepository();
            IUserService userService = new UserService(repository);

            // Подписка на событие
            userService.OnUserCreated += OnUserCreated;

            try
            {
                Console.WriteLine("Добро пожаловать в систему регистрации!");

                // Ввод данных пользователя
                var user = GetUserInput();

                // Регистрация пользователя
                userService.RegisterUser(user);

                Console.WriteLine("Регистрация завершена успешно!");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"Ошибка валидации: {ex.Message}");
            }
            catch (RepositoryException ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
                Console.WriteLine($"Детали: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
            }
        }

        private static User GetUserInput()
        {
            var user = new User();

            Console.Write("Введите ваше имя: ");
            user.Name = Console.ReadLine();

            Console.Write("Введите ваш возраст: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                throw new ValidationException("Некорректный формат возраста");
            }
            user.Age = age;

            return user;
        }

        private static void OnUserCreated(User user)
        {
            Console.WriteLine($"Создан пользователь: {user.Name} ({user.Age} лет)");
            Console.WriteLine($"Статус: {(user.IsAdult ? "Совершеннолетний" : "Несовершеннолетний")}");
        }
    }
}