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
using System.Windows.Shapes;
using Data;

namespace Forum
{
  /// <summary>
  /// Interaction logic for LoginWindow.xaml
  /// </summary>
  public partial class LoginWindow : Window
  {
    ForumContext db;

    public LoginWindow(ForumContext context)
    {
      InitializeComponent();
      db = context;
    }

    private void loginButton_Click(object sender, RoutedEventArgs e)
    {
      string login = loginTextBox.Text;
      string password = passwordBox.Password;

      User user = db.User.Where(a => a.Login == login && a.Password == password).FirstOrDefault();
      if(user != null)
      {
        db.Session.Add(new Session() { User = user });
        new TopicsListWindow(db).Show();
        Hide();
      } else
      {
        MessageBox.Show("You are not a member. Contact administrator to request permission.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }
  }
}
