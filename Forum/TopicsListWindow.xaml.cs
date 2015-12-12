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

namespace Forum
{
  /// <summary>
  /// Interaction logic for TopicsListWindow.xaml
  /// </summary>
  public partial class TopicsListWindow : Window
  {
    ForumContext db;

    public TopicsListWindow(ForumContext content)
    {
      InitializeComponent();
      db = content;
      initGrid();
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
          Date = DateTime.Today.Date
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
        topicDataGrid.ItemsSource = db.Topic.ToList();
        topicDataGrid.Items.Refresh();
        newTopicTextBox.Clear();
      }
    }
  }
}