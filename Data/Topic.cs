using System;
using System.Collections.Generic;

namespace Data
{
    public class Topic
    {
      public long Id { get; set; }
      public string Title { get; set; }
      public List<Message> Messages { get; set; }
      public DateTime? Date { get; set; }
      public User User { get; set; }
  }
}