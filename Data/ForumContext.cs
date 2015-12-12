using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data
{
  public class ForumContext: DbContext
  {
    public ForumContext() : base("ForumContext")
    {
      Database.SetInitializer<ForumContext>(new ForumDBInitializer<ForumContext>());
    }

    public DbSet<User> User { get; set; }
    public DbSet<Message> Message { get; set; }
    public DbSet<Topic> Thread { get; set; }
   
  }
}
