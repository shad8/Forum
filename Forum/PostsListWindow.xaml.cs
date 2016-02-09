using Data;
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

namespace Forum
{
  /// <summary>
  /// Interaction logic for PostsListWindow.xaml
  /// </summary>
  public partial class PostsListWindow : Window
  {
    ForumContext db;
    User user;

    public PostsListWindow(ForumContext content)
    {
      InitializeComponent();
      db = content;
      user = db.Session.First().User;
      initGrid();
    }

    private void deleteUsersButton_Click(object sender, RoutedEventArgs e)
    {
      List<Post> SelectedItemsList = postDataGrid.SelectedItems.OfType<Post>().ToList();
      foreach (var item in SelectedItemsList)
        db.Post.Remove(item);
      db.SaveChanges();
      updateDataGrid();
    }

    private void initGrid()
    {
      List<Topic> topics = db.Topic.ToList();
      try
      {
        postDataGrid.ItemsSource = topics;
      }
      catch (Exception exp)
      {
        MessageBox.Show(exp.ToString(), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    private void updateDataGrid()
    {
      topicDataGrid.ItemsSource = db.Topic.ToList();
      topicDataGrid.Items.Refresh();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {

      System.Windows.Data.CollectionViewSource postViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("postViewSource")));
      // Load data by setting the CollectionViewSource.Source property:
      // postViewSource.Source = [generic data source]
    }
  }
}
