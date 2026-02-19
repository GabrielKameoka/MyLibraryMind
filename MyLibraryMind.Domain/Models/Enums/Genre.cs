namespace MyLibraryMind.Domain.Models.Enums;

[Flags]
public enum Genre
{
    None = 0,
    Fiction = 1 << 0,
    NonFiction = 1 << 1,
    Mystery = 1 << 2,
    Fantasy = 1 << 3,
    ScienceFiction = 1 << 4,
    Biography = 1 << 5,
    History = 1 << 6,
    Romance = 1 << 7,
    Thriller = 1 << 8,
    Horror = 1 << 9,
    Poetry = 1 << 10,
    SelfHelp = 1 << 11,
    Philosophy = 1 << 12,
    Children = 1 << 13,
    YoungAdult = 1 << 14
}