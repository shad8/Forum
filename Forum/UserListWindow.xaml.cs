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
  /// Interaction logic for UserListWindow.xaml
  /// </summary>

  public partial class UserListWindow : Window
  {
    ForumContext db;

    public UserListWindow(ForumContext context)
    {
      InitializeComponent();
      db = context;
      initGrid();
    }

    private void initGrid()
    {
      List<User> users = db.User.ToList();
      try
      {
        userDataGrid.ItemsSource = users;
      }
      catch (Exception exp)
      {
        MessageBox.Show(exp.ToString(), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    private void addUserButton_Click(object sender, RoutedEventArgs e)
    {
      string login = loginTextBox.Text;
      string password = passwordTextBox.Text;
      Role role = roleComboBox.SelectedItem.ToString() == "user" ? Role.User : Role.Admin;

      if (login != null && password != null)
      {
        User user = new User()
        {
          Login = login,
          Password = password,
          Role = role
        };

        db.User.Add(user);
        try
        {
          db.SaveChanges();
        }
        catch (Exception exp)
        {
          MessageBox.Show(exp.ToString(), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        updateDataGrid();
        loginTextBox.Clear();
        passwordTextBox.Clear();
      }
    }

    private void updateDataGrid()
    {
      userDataGrid.ItemsSource = db.User.ToList();
      userDataGrid.Items.Refresh();
    }

    private void logOutButton_Click(object sender, RoutedEventArgs e)
    {
      db.Session.Remove(db.Session.First());
      db.SaveChanges();
      new LoginWindow(db).Show();
      Close();
    }

    private void deleteUsersButton_Click(object sender, RoutedEventArgs e)
    {
      List<User> SelectedItemsList = userDataGrid.SelectedItems.OfType<User>().ToList();
      foreach (var item in SelectedItemsList)
        db.User.Remove(item);
      db.SaveChanges();
      updateDataGrid();
    }
  }
}
