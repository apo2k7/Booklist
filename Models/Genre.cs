using Models.Relations;
using System.Collections.Generic;

namespace Models
{
  public class Genre
  {
    public string Name { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }
  }
}
