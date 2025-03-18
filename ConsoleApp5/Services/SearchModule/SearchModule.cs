using System;
using System.Collections.Generic;
using LibraryManagement.Entities;

namespace LibraryManagement.SearchModule
{
    public class SearchManager
    {
        // Поиск книг по названию
        public List<Book> SearchBooksByTitle(List<Book> books, string title)
        {
            return books.FindAll(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        // Поиск книг по автору
        public List<Book> SearchBooksByAuthor(List<Book> books, string author)
        {
            return books.FindAll(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
        }

        // Поиск пользователей по имени
        public List<User> SearchUsersByName(List<User> users, string name)
        {
            return users.FindAll(u => u.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        // Поиск пользователей по email
        public List<User> SearchUsersByEmail(List<User> users, string email)
        {
            return users.FindAll(u => u.Email.Contains(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}