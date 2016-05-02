
namespace LibraryManagementSystem.Model
{
    public class Book : Entity
    {
        public Book(string name
            , Author author
            , Genere genere
            , Publisher publisher
            , double price)
            : base(name)
        {

            Author = author;
            Genere = genere;
            Publisher = publisher;
            Price = price;
        }

        public Author Author { get; private set; }

        public Genere Genere { get; private set; }

        public Publisher Publisher { get; private set; }

        public double Price { get; private set; }
    }
}
