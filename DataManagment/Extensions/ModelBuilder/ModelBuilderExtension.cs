using Models.Relations;

namespace Microsoft.EntityFrameworkCore
{
  public static class ModelBuilderExtension
  {
    /// <summary>
    /// Relational configuration for Books and Authors
    /// </summary>
    /// <param name="builder"></param>
    public static void ConfigureBookAuthors(this ModelBuilder builder)
    {
      builder.Entity<BookAuthor>()
          .HasKey(ab => new { ab.AuthorId, ab.BookId });

      builder.Entity<BookAuthor>()
          .HasOne(ab => ab.Author)
          .WithMany(a => a.BookAuthors)
          .HasForeignKey(a => a.AuthorId);

      builder.Entity<BookAuthor>()
          .HasOne(ab => ab.Book)
          .WithMany(b => b.BookAuthors)
          .HasForeignKey(b => b.BookId);

    }

    /// <summary>
    /// Relational configuration for Books and Genres
    /// </summary>
    /// <param name="builder"></param>
    public static void ConfigureBookGenres(this ModelBuilder builder)
    {
      builder.Entity<BookGenre>()
          .HasKey(ab => new { ab.GenreId, ab.BookId });

      builder.Entity<BookGenre>()
          .HasOne(bg => bg.Genre)
          .WithMany(g => g.BookGenres)
          .HasForeignKey(a => a.GenreId);

      builder.Entity<BookGenre>()
          .HasOne(bg => bg.Book)
          .WithMany(b => b.BookGenres)
          .HasForeignKey(bg => bg.BookId);
    }
  }
}
