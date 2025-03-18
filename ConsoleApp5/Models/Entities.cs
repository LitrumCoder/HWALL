namespace LibraryManagement.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class Library
    { 
        public int LibraryID { get; set;}
        public string UserVersion { get; set;}
        public int LibraryVersion { get; set;}  
        public List<Book> books { get; set;}
    }
}