namespace BookManager
{
    public class FictionBook : Book
    {
        private string _genre;

        public FictionBook(string title, string author, string genre) 
            : base(title, author)
        {
            _genre = genre;
        }

        public override void DisplayDetails()
        {
            System.Console.WriteLine($"Fiction - Title: {_title}, Author: {_author}, Genre: {_genre}");
        }
    }
}
