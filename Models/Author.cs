using Models.Base;
using Models.Relations;
using System.Collections.Generic;

namespace Models
{
  public class Author : BaseModel
  {
    public string Name { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
  }
}
