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
    public ForumContext():base("ForumContext")
    {

    }

    public DbSet<User> User { get; set; }
    public DbSet<Message> Message { get; set; }
    public DbSet<Thread> Thread { get; set; }
   
  }
}
