using System;

namespace Models.Base
{
  public abstract class BaseModel
  {
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
  }
}
