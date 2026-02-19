namespace MyLibraryMind.Domain.Models;

public class Author
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Nationality { get; set; }
    
    public List<Book> Books { get; set; }
}