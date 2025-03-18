using System;
using LibraryManagement.Entities;
using LibraryManagement.BookManagement;
using LibraryManagement.UserManagement;
using LibraryManagement.SearchModule;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация менеджеров
            var bookManager = new BookManager();
            var userManager = new UserManager();
            var searchManager = new SearchManager();

            // Добавление книг
            bookManager.AddBook(new Book { Id = 1, Title = "Война и мир", Author = "Лев Толстой", Year = 1869 });
            bookManager.AddBook(new Book { Id = 2, Title = "1984", Author = "Джордж Оруэлл", Year = 1949 });

            // Редактирование книги
            bookManager.EditBook(1, "Война и мир (изд. 2023)", "Лев Толстой", 2023);

            // Добавление пользователей
            userManager.AddUser(new User { Id = 1, Name = "Иван Иванов", Email = "ivan@example.com" });
            userManager.AddUser(new User { Id = 2, Name = "Мария Петрова", Email = "maria@example.com" });

            // Поиск книг по автору
            var booksByAuthor = searchManager.SearchBooksByAuthor(bookManager.GetAllBooks(), "Толстой");
            Console.WriteLine("Найденные книги по автору 'Толстой':");
            foreach (var book in booksByAuthor)
            {
                Console.WriteLine($"{book.Title} ({book.Year})");
            }

            // Поиск пользователей по имени
            var usersByName = searchManager.SearchUsersByName(userManager.GetAllUsers(), "Иван");
            Console.WriteLine("Найденные пользователи по имени 'Иван':");
            foreach (var user in usersByName)
            {
                Console.WriteLine($"{user.Name} ({user.Email})");
            }

            // Удаление книги
            bookManager.RemoveBook(2);

            // Удаление пользователя
            userManager.RemoveUser(2);
        }
    }
}