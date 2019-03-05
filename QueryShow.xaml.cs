using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for QueryShow.xaml
    /// </summary>
    public partial class QueryShow : Window
    {
        public QueryShow(DataTable dt)
        {
            InitializeComponent();
            _datagrid.ItemsSource = dt.DefaultView;
        }
    }
}
