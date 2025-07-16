namespace BookManager
{
    public class NonFictionBook : Book
    {
        private string _subject;

        public NonFictionBook(string title, string author, string subject) 
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
