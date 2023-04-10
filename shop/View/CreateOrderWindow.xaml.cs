using shop.Classes;
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

using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;

namespace shop.View
{
    /// <summary>
    /// Логика взаимодействия для CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {
        public double sumCard = 0; //в величину передается значение
        public double sumOrder = 0;

        //public double SummaBankCard { get; set; } //сумма на карте
       // public double SummaOrder { get; set; } //сумма на заказа

        List<Classes.Clothes> listClothes; //глобальный списокодежды

        List<Classes.Clothes> listBasketClothes = new List<Clothes>();

        public List<OrderItem> listClothesInOrders;

        Clothes currentItem;

        ChartArea area; //площадь диаграммы
        Series series; //серия точек

        //конструктор с параметром - переданное из окна значение
        public CreateOrderWindow(double sumCard)
        {
            InitializeComponent();
            this.sumCard = sumCard; //инициализация
            tb_fromCard.Text += sumCard.ToString();

            listClothesInOrders= new List<OrderItem>();

            //настройка диаграммы
            //area = new ChartArea("Default");
            //chartSumma.ChartAreas.Add(area);
            //series = new Series("Summa");
            //chartSumma.Series.Add(series);
            //chartSumma.Series["Summa"].ChartArea = "Default";
            //chartSumma.Series["Summa"].ChartType = SeriesChartType.Pie;
            //chartSumma.Series["Summa"].Points.Clear();
            //chartSumma.Series["Summa"].Points.AddXY(0, sumCard - sumOrder); //Осталось
            //chartSumma.Series["Summa"].Points.AddXY(0, sumOrder); //сумма заказа
            //chartSumma.Series["Summa"].IsValueShownAsLabel = false; //не отображать данные
        }



        private void butMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void butCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            var rand = new Random();
            //sumOrder = Math.Round(rand.NextDouble() * sumCard, 2);

                MessageBox.Show($"Сумма Вашего заказа составила {sumOrder}");
                View.Bucket bucket = new Bucket(listClothesInOrders); //создание объекта окна
                //bucket.Owner = this; //Указать владельца у дополнительного окна
                this.Hide();
                //bucket.ShowDialog(); //Показать модальное дополнительное
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Получить все категории
            listCategoty.Items.Clear();
            //Перебрать все листы
            //for (int i = 1; i <= App.excelBook.Worksheets.Count; i++)
            //{
            //    //Добавить в листбокс названия всех листов
            //    listCategoty.Items.Add(App.excelBook.Worksheets[i].Name);
            //}
        }

        private void listCategoty_SelectionChenged(object sender, SelectionChangedEventArgs e)
        {
            string categoryName = listCategoty.SelectedItem.ToString();
            App.excelSheet = App.excelBook.Sheets[categoryName];
            //MessageBox.Show(categoryName);

            

            listClothes = new List<Classes.Clothes>(); //Создать список одежды
            Classes.Clothes clothes; //объявить отдельную вещь

            //связь с листом Excel с названием выбранной категории

            //обработанные ячейки на листе
            App.excelCells = App.excelSheet.UsedRange;

            //получить все заполненные ячейки листа в цикле
            for (int i = 1; i <= App.excelSheet.UsedRange.Rows.Count; i++)
            {
                clothes = new Classes.Clothes(); //создать отдельную вещь
                //заполнить поля объекта clothes из ячеек Excel
                clothes.Name = (string)App.excelCells.Cells[i, 1].Value2; //название вещи в объект
                clothes.Cost = (int)App.excelCells.Cells[i, 2].Value2; //название вещи в объект
                clothes.Discount = int.Parse(((double)clothes.Cost * (1.0 - (double)App.excelCells.Cells[i, 3].Value2 / 100.0)).ToString());                
                clothes.Rating = (int)App.excelCells.Cells[i, 4].Value2; //название вещи в объект
                clothes.Photo = App.pathExe + $"\\{categoryName}\\{App.excelCells.Cells[i, 5].Value2}.png";
                listClothes.Add(clothes); //занесение вещи в список
                
            }

            ////считываем все данные из ячеек и заполняем объект
            //for (int row = 0; row <= App.excelCells.Rows.Count; row++)
            //{
                
            //}
            listViewClothes.ItemsSource = listClothes; //привязать список к элементу интерфейса



        }

        private void ButtonAddInBasket_Click(object sender, RoutedEventArgs e)
        {
            //Grid parent = (Grid)(sender as Button).Parent;
            //int i = listViewClothes.Items.IndexOf(parent.DataContext);

            //if (sumOrder + listClothes[i].Discount < sumCard)
            //{
            //    listBasketClothes.Add(listClothes[i]);
            //    sumOrder += listClothes[i].Discount;

            //    tb_summOrder.Text = $"Сумма заказа: {sumOrder}";
            //} 
            //else
            //{
            //    MessageBox.Show("У Выс недостаточно денег на карте");
            //}

           
            Classes.Clothes clothes = (sender as Button).DataContext as Classes.Clothes;
            string clothesName = clothes.Name; //название одежды
            int clothesCostDiscount = clothes.Discount;
            if (sumOrder + clothesCostDiscount <= sumCard)
            {
                sumOrder += clothesCostDiscount; //общая сумма в заказе
                tb_summOrder.Text = $"Сумма заказа: {sumOrder}";
                //поиск этой вещи среди добавленных в корзину
                int index = listClothesInOrders.FindIndex(x => x.Name == clothesName);

                if (index < 0) //такого товара еще в заказе нет
                {
                    //создаем новый элемент списка
                    OrderItem clothesInOrder = new OrderItem();
                    clothesInOrder.Name = clothesName;
                    clothesInOrder.Cost = clothesCostDiscount;
                    clothesInOrder.Quantity = 1; //для нового
                    clothesInOrder.Price = clothesCostDiscount; //стоимость
                    listClothesInOrders.Add(clothesInOrder); //добавляем в список

                }
                else
                {
                    listClothesInOrders[index].Quantity++;
                    listClothesInOrders[index].Price = listClothesInOrders[index].Cost * listClothesInOrders[index].Quantity;
                }
            }
                else
            {
                MessageBox.Show("У Выс недостаточно денег на карте");
            }
            ChartShow();
        }

        private void ChartShow()
        {
            chartSumma.Series["Summa"].Points.Clear();
            chartSumma.Series["Summa"].Points.AddXY(0, sumCard - sumOrder); //Осталось
            chartSumma.Series["Summa"].Points.AddXY(0, sumOrder); //сумма заказа
        }

        private void listViewClothes_MouseEnter(object sender, MouseEventArgs e)
        {
            //currentItem = listViewClothes.sele
        }
    }
}
