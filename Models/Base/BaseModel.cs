using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Base
{
  internal abstract class BaseModel
  {
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
  }
}
