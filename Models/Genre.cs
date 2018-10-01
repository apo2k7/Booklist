using Models.Base;
using Models.Relations;
using System.Collections.Generic;

namespace Models
{
  public class Genre : BaseModel
  {
    public string Name { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }
  }
}
