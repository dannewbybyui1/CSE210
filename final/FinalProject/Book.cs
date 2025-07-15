namespace BookManager
{
    public class _Book
    {
        protected string _title;
        protected string _author;

        public _Book(string title, string author)
        {
            _title = title;
            _author = author;
        }

        public virtual void DisplayDetails()
        {
            System.Console.WriteLine($"Title: {_title}, Author: {_author}");
        }
    }
}
