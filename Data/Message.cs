using System;

namespace Data
{
  public class Message
  {
    public long Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime? Date { get; set; }
    public User User { get; set; }
  }
}