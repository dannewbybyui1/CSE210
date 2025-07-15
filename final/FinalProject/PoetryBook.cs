namespace BookManager
{
    public class _PoetryBook : _Book
    {
        private int _poemCount;

        public _PoetryBook(string title, string author, int poemCount) 
            : base(title, author)
        {
            _poemCount = poemCount;
        }

        public override void DisplayDetails()
        {
            System.Console.WriteLine($"Poetry - Title: {_title}, Author: {_author}, Number of Poems: {_poemCount}");
        }
    }
}
