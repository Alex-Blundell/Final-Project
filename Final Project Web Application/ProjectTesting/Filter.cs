using Final_Project_Web_Application.Models;

namespace ProjectTesting
{
    public class Filter
    {
        public List<Book> SearchBooksByAll(List<Book> SearchBooks, string Query)
        {
            List<Book> results = new List<Book>();

            foreach (Book ThisBook in SearchBooks)
            {
                if (ThisBook.Author.ToString().ToLower().Contains(Query.ToLower()))
                {
                    results.Add(ThisBook);
                }
                else if (ThisBook.Title.ToString().ToLower().Contains(Query.ToLower()))
                {
                    results.Add(ThisBook);
                }
                else if (ThisBook.Description.ToString().ToLower().Contains(Query.ToLower()))
                {
                    results.Add(ThisBook);
                }

            }

            return results;
        }

        public List<Book> SearchBooksByTitle(List<Book> SearchBooks, string Query)
        {
            List<Book> results = new List<Book>();

            foreach (Book ThisBook in SearchBooks)
            {
                if (ThisBook.Title.ToString().ToLower().Contains(Query.ToLower()))
                {
                    results.Add(ThisBook);
                }

            }

            return results;
        }
        public List<Book> SearchBooksByAuthor(List<Book> SearchBooks, string Query)
        {
            List<Book> results = new List<Book>();

            foreach (Book ThisBook in SearchBooks)
            {
                if (ThisBook.Author.ToString().ToLower().Contains(Query.ToLower()))
                {
                    results.Add(ThisBook);
                }

            }

            return results;
        }
        public List<Book> SearchBooksByDescription(List<Book> SearchBooks, string Query)
        {
            List<Book> results = new List<Book>();

            foreach (Book ThisBook in SearchBooks)
            {
                if (ThisBook.Description.ToString().ToLower().Contains(Query.ToLower()))
                {
                    results.Add(ThisBook);
                }

            }

            return results;
        }

    }
}