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

namespace shop.View
{
    /// <summary>
    /// Логика взаимодействия для WorkWithCatalog.xaml
    /// </summary>
    public partial class WorkWithCatalog : Window
    {
        public WorkWithCatalog()
        {
            InitializeComponent();
        }

        private void butMainMenu_Click(object sender, RoutedEventArgs e)
        {
            //foreach (Window window in App.Current.Windows)
            //{
            //    if(!(window is MainWindow))
            //    {
            //        window.Close();
            //    }
            //}

            this.Close();
            
        }
    }
}
