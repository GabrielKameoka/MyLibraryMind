using MyLibraryMind.Domain.Models.Enums;

namespace MyLibraryMind.Domain.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Genre Genres { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public int AvailableCopies { get; set; }
    
    public Author Author { get; set; }
    public Guid AuthorId { get; set; }
}