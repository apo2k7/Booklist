using System;
using System.Linq;
using System.Collections.Generic;
using Models.Relations;
using Microsoft.AspNetCore.Identity;
using Models.Base;
using Models.Identity;

namespace Models
{
  public class Book : BaseModel
  {
    public Book()
    {
      BookAuthors = new List<BookAuthor>();
    }
    public string Titel { get; set; }
    public string Subtitel { get; set; }
    public string Series { get; set; }
    public int Seriesnumber { get; set; }
    public string Isbn { get; set; }
    public string Place { get; set; }
    public bool Ebook { get; set; }
    public bool Lent { get; set; }
    public DateTime ReleaseYear { get; set; }
    public ApplicationUser User { get; set; }
    public Publisher Publisher { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }

    public string GetAuthorString()
    {
      var returnVal = String.Join(", ", BookAuthors.Select(ab => ab.Author?.Name));
      return returnVal;
    }
  }
}
