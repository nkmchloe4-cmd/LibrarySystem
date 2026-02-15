namespace LibrarySystem.Classes
{
    public interface ISearchable
    {
        // Returns true if the object matches the search term
        bool Matches(string searchTerm);


        string GetInfo();
    }
}
