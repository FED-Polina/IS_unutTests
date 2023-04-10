using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        int countTry;
        public Authorization()
        {
            InitializeComponent();
            countTry = 3;
        }

        private void butMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void butEnter_Click(object sender, RoutedEventArgs e)
        {
            //if (checkAuth(tbLogin.Text, tbPassword.Password))
            //{
            //    View.WorkWithCatalog workWithCatalog = new WorkWithCatalog(); //создание объекта окна
            //    this.Hide();
            //    workWithCatalog.ShowDialog(); //Показать модальное дополнительное
            //}
            string login = tbLogin.Text;
            string password = tbPassword.Password;
            if (login==App.Login && password==App.Password)
            {
                View.WorkWithCatalog workWithCatalog = new WorkWithCatalog(); //создание объекта окна
                this.Close();
                workWithCatalog.ShowDialog(); //Показать модальное дополнительное
            }
            else
            {
                countTry--;
                if (countTry == 0)
                {
                    MessageBox.Show("Все попытки исчерпаны.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Введены неверные данные. Осталось {countTry} попыток.");
                }
                
            }
            
        }

        //private bool checkAuth(string login, string password)
        //{
        //    string[] authorization = File.ReadAllText("authorization.txt").Split(':');
        //    if (authorization[0] == login && authorization[1] == password)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
