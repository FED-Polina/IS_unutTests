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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Exel = Microsoft.Office.Interop.Excel; //подключение excel
using Word = Microsoft.Office.Interop.Word;


namespace shop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double sumCard = 10000.0;
        public MainWindow() //конструктор главного окна
        {
            InitializeComponent();
            try //обработка исключения
            {
                App.excelApp = new Exel.Application();  //создать объект Exel
                App.excelApp.Visible = false;   //не отображать Exel
                MessageBox.Show("У Вас установлен MS Excel");

                if (File.Exists(App.fileMenu)) //проверка наличия документа
                {
                    //открыть книгу Excel
                    App.excelBook = App.excelApp.Workbooks.Open(App.fileMenu);
                }
                else
                {
                    MessageBox.Show("Файл спрайс-листом отсутствует");
                    this.Close();
                }
            }
            catch 
            {
                MessageBox.Show("Установите MS Excel");
                this.Close();
            }

            
        }

        // Завершить работу приложения
        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            App.excelApp.Quit(); //Выйти из Excel
            //Уничтожить все COM-объекты
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(App.excelApp);
            //Заставляет сборщик мусора произвести сборку мусора
            GC.Collect();
            this.Close(); //Закрыть главное окно
        }

        // Пункт меню Прайс-лист
        private void butPriceList_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");

            App.excelApp.Visible = true; //сделать видимым Excel
        }
       
        // Пункт меню Заказ
        private void butOrder_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Мы заглянули на вашу карту. На ней сумма {sumCard}");

            View.CreateOrderWindow createOrderWindow = new View.CreateOrderWindow(sumCard); //создание объекта окна для конструктора с параметром

            //Получить число листов в книге и список названий листов
            //List<string> listCat = new List<string>();  //Список названий листов книги
            //int countSheet = App.excelBook.Worksheets.Count;    //Число листов
            ////Цикл по индексам листов
            //for (int i = 1; i <= countSheet; i++)
            //{
            //    listCat.Add(App.excelBook.Worksheets[i].Name);  
            //}

            this.Hide();
            createOrderWindow.Show(); //Показать модальное дополнительное
            //this.Show(); //После закрытия доп окна - показать главное


        }

        void getRandomSumCard()
        {
            var rand = new Random();
            sumCard = Math.Round(rand.NextDouble() * 10000.0, 2) + 10000;
        }

        // Пункт меню Каталог
        private void butWorkWithCatalog_Click(object sender, RoutedEventArgs e)
        {
            //StreamReader f = new StreamReader("password.txt");
            //while (!f.EndOfStream)
            //{
            //    string s = f.ReadLine();
            //    MessageBox.Show($"Для редактирования каталога товаров требуется ввод пароля {s}");
            //}
            //f.Close();

            View.Authorization authorization = new View.Authorization(); //создание объекта окна
            this.Hide();
            authorization.ShowDialog(); //Показать модальное дополнительное
            //this.Show(); //После закрытия доп окна - показать главное

        }
    }
}
