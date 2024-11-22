using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task3_c_
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }

        public  Book(string title="none", string author = "none", string iSBN = "none", bool availability=true)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Availability = availability;
        }
    }
    class Library
    {
       

        public List<Book> books { get; set; }= new List<Book>();
        public void AddBook(Book book)
        {
            books.Add(new Book()
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,


            });
                
        }
        public bool BorrowBook(string name)
        {
            for (int i = 0; i < books.Count(); i++)
            {
                if (books[i].Title == name || books[i].Title.Contains(name))
                {
                    Console.WriteLine($"{name} Book Available");
                    books[i].Availability = false;
                    return true;
                    

                }
                else if (books[i].Author == name|| books[i].Author.Contains(name))
                {
                    Console.WriteLine($"{name} Book Available");
                    books[i].Availability = false;
                    return true;

                }
            }
            Console.WriteLine($"*{name}* This book is not in the library");
            return false;
        }
        public bool ReturnBook(string name)
        {
            for (int i = 0; i < books.Count(); i++)
            {
                if (books[i].Title == name || books[i].Title.Contains(name))
                {
                    Console.WriteLine($"{name} Book Became Available Again");
                    books[i].Availability = true;
                    return true;


                }
                else if (books[i].Author == name || books[i].Author.Contains(name))
                {
                    Console.WriteLine($"{name} Book Became Available Again");
                    books[i].Availability = true;
                    return true;
                }
            }
            Console.WriteLine($"*{name}* This book is not borrowed");
            return false;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));
            for (int i = 0; i < library.books.Count; i++)
            {
                Console.WriteLine(library.books[i].Title);
                Console.WriteLine(library.books[i].Author);
                Console.WriteLine(library.books[i].ISBN);
                Console.WriteLine("============================================");
            }
            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library
                                                // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed
        }
    }
}
