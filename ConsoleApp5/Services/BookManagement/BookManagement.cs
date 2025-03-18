using System;
using System.Collections.Generic;
using LibraryManagement.Entities;

namespace LibraryManagement.BookManagement
{
    public class BookManager
    {
        private List<Book> books = new List<Book>();

        // Добавление книги
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Книга '{book.Title}' добавлена.");
        }

        // Редактирование книги
        public void EditBook(int bookId, string newTitle, string newAuthor, int newYear)
        {
            var book = books.Find(b => b.Id == bookId);
            if (book != null)
            {
                book.Title = newTitle;
                book.Author = newAuthor;
                book.Year = newYear;
                Console.WriteLine($"Книга '{book.Title}' отредактирована.");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }

        // Удаление книги
        public void RemoveBook(int bookId)
        {
            var book = books.Find(b => b.Id == bookId);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine($"Книга '{book.Title}' удалена.");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }

        // Получение всех книг
        public List<Book> GetAllBooks()
        {
            return books;
        }
    }
}