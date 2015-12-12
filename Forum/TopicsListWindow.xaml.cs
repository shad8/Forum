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
using System.Data;
using System.Collections;

namespace Forum
{
  /// <summary>
  /// Interaction logic for TopicsListWindow.xaml
  /// </summary>
  public partial class TopicsListWindow : Window
  {
    ForumContext db;
    User user;

    public TopicsListWindow(ForumContext content)
    {
      InitializeComponent();
      db = content;
      user = db.Session.First().User;
      initGrid();
      userSetting();
    }

    private void userSetting()
    {
      if(user.Role == Role.User)
      {
        deleteUsersButton.Visibility = Visibility.Hidden;
        topicDataGrid.IsReadOnly = true;
        usersButton.Name = "Edit my topics";
      }
      else
      {
        topicDataGrid.IsReadOnly = false;
      }
    }

   
    private void initGrid()
    {
      List<Topic> topics = db.Topic.ToList();
      try
      {
        topicDataGrid.ItemsSource = topics;
      }
      catch (Exception exp)
      {
        MessageBox.Show(exp.ToString(), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    private void addTopicButton_Click(object sender, RoutedEventArgs e)
    {
      string title = newTopicTextBox.Text;
      if (title != null && title.Length > 3 )
      {
        Topic topic = new Topic()
        {
          Title = title,
          Date = DateTime.Today.Date,
          User = user
        };
        db.Topic.Add(topic);
        try
        {
          db.SaveChanges();
        }
        catch (Exception exp)
        {
          MessageBox.Show(exp.ToString(), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        updateDataGrid();
        newTopicTextBox.Clear();
      }
    }

    private void logOutButton_Click(object sender, RoutedEventArgs e)
    {
      db.Session.Remove(db.Session.First());
      db.SaveChanges();
      new LoginWindow(db).Show();
      Close();
    }

    private void usersButton_Click(object sender, RoutedEventArgs e)
    {
      if(user.Role == Role.Admin)
      {
        // Add User edit
      } else
      {
         // Add Edit topic for user
      }
    }

    private void deleteUsersButton_Click(object sender, RoutedEventArgs e)
    {
      List<Topic> SelectedItemsList = topicDataGrid.SelectedItems.OfType<Topic>().ToList();
      foreach (var item in SelectedItemsList)
        db.Topic.Remove(item);
      db.SaveChanges();
      updateDataGrid();
    }

    private void updateDataGrid()
    {
      topicDataGrid.ItemsSource = db.Topic.ToList();
      topicDataGrid.Items.Refresh();
    }
  }
}