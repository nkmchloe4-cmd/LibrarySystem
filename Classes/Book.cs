using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.Classes
{
    public class Book : ISearchable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; }
        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }

        //Constructor that runs when a new Book is created
        public Book(string title, string author, string isbn, int publishedYear)
        {
            
            Title = title;
            Author = author;
            ISBN = isbn;
            PublishedYear = publishedYear;
            IsAvailable = true;
        }


        //Method to display book info
        public string GetInfo()
        {
            return $"{Title} by {Author}, year: {PublishedYear}, ISBN: {ISBN}, Available: {IsAvailable} ";
        }


        public bool Matches(string searchTerm) // search method from ISearchable
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return false;

            searchTerm = searchTerm.ToLower();

            return Title.ToLower().Contains(searchTerm)
                || Author.ToLower().Contains(searchTerm)
                || ISBN.ToLower().Contains(searchTerm);
        }



    }
}
