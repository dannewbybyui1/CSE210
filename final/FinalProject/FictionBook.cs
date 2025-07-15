namespace BookManager
{
    public class _FictionBook : _Book
    {
        private string _genre;

        public _FictionBook(string title, string author, string genre) 
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
