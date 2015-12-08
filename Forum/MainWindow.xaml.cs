using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Data;

namespace Forum
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    public void init()
    {

      using (var db = new ForumContext())
      {
        var user = db.User.FirstOrDefault(x => x.Id == 1);
        MainWindow mw = new MainWindow();
        mw.DataContext = user;
        mw.Show();

      }


      using (var db = new ForumContext())
      {
        db.User.Add(new User()
        {
          Login = "ula",
          Password = "qwerty",
          Role = Role.Admin
        });
        
        db.SaveChanges();
      }
    }
  }
}
