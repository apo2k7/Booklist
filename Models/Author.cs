using Models.Relations;
using System.Collections.Generic;

namespace Models
{
  public class Author
  {
    public string Name { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
  }
}
