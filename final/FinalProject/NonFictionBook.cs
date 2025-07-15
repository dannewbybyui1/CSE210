namespace BookManager
{
    public class _NonFictionBook : _Book
    {
        private string _subject;

        public _NonFictionBook(string title, string author, string subject) 
            : base(title, author)
        {
            _subject = subject;
        }

        public override void DisplayDetails()
        {
            System.Console.WriteLine($"Non-Fiction - Title: {_title}, Author: {_author}, Subject: {_subject}");
        }
    }
}
