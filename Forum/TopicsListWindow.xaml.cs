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
    }


    private void Window_Loaded(object sender, RoutedEventArgs e)
    {

      System.Windows.Data.CollectionViewSource topicViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("topicViewSource")));
      // Load data by setting the CollectionViewSource.Source property:
      // topicViewSource.Source = [generic data source]
    }
  }
}