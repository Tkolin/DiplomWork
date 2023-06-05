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

namespace ShiraRDKWork
{
    /// <summary>
    /// Логика взаимодействия для AddEditItemPage.xaml
    /// </summary>
    public partial class AddEditItemPage : Page
    {
        Item _item = new Item();
        bool add = true;
        public AddEditItemPage()
        {
            InitializeComponent();
        }
        public AddEditItemPage(Item item)
        {
            this._item = item;
            InitializeComponent();
        }

        private void imageUpdateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
