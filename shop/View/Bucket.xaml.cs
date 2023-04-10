using shop.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using Word = Microsoft.Office.Interop.Word;

namespace shop.View
{
    /// <summary>
    /// Логика взаимодействия для Bucket.xaml
    /// </summary>
    public partial class Bucket : Window
    {
        private double finalSumCard = 0.0;
        private double sumOrder = 0.0;
        private List<OrderItem> inBucket;
        public Bucket(List<OrderItem> inBucket)
        {
            InitializeComponent();
            this.inBucket = inBucket;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.sumOrder = (this.Owner as CreateOrderWindow).sumOrder;
            tb_summOrder.Text = $"Сумма заказа: {sumOrder}";
            finalSumCard = (this.Owner as CreateOrderWindow).sumCard - sumOrder;
            tb_fromCardCreate.Text = $"Сукма на карте: {Math.Round(finalSumCard)}";

            dgOrder.ItemsSource = inBucket;
        }

        private void butMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void butCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            View.CreateOrderWindow createOrderWindow = new CreateOrderWindow(finalSumCard); //создание объекта окна
            this.Hide();
            createOrderWindow.ShowDialog(); //Показать модальное дополнительное
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            OrderItem item = inBucket.Find(x => (sender as Button).Tag == x.Name);
            if (item.Cost < finalSumCard)
            {
                item.Quantity++;
                item.Price = item.Cost * item.Quantity;
                sumOrder += item.Cost;
                finalSumCard -= item.Cost;
            }
            else
            {
                MessageBox.Show("У Вас недостаточно денег на карте");
            }
            dgOrder.Items.Refresh();
            tb_summOrder.Text = $"Сумма заказа: {sumOrder}";
            tb_fromCardCreate.Text = $"Сумма на карте: {Math.Round(finalSumCard)}";
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            OrderItem item = inBucket.Find(x => (sender as Button).Tag == x.Name);
            if (item.Quantity > 1)
            {
                item.Quantity--;
                item.Price = item.Cost * item.Quantity;
                sumOrder -= item.Cost;
                finalSumCard += item.Cost;
            }
            else
            {
                inBucket.Remove(item);
                sumOrder -= item.Cost;
                finalSumCard += item.Cost;
            }
            dgOrder.Items.Refresh();
            tb_summOrder.Text = $"Сумма заказа: {sumOrder}";
            tb_fromCardCreate.Text = $"Сумма на карте: {Math.Round(finalSumCard)}";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            OrderItem item = inBucket.Find(x => (sender as Button).Tag == x.Name);
            sumOrder -= item.Price;
            finalSumCard += item.Price;
            inBucket.Remove(item);
            dgOrder.Items.Refresh();
            tb_summOrder.Text = $"Сумма заказа: {sumOrder}";
            tb_fromCardCreate.Text = $"Сумма на карте: {Math.Round(finalSumCard)}";
        }

        private void but_Check_Click(object sender, RoutedEventArgs e)
        {
            //создание чека заказа
            //объявление необходимых величин
            Word.Application wordApp;   //сервер Word
            Word.Document wordDoc;
            Word.Paragraph wordPar;     //абзац документа
            Word.Range wordRange;       //тест абзаца
            Word.Table wordTable;
            Word.InlineShape wordShape; //рисунок
            //создание сервера Word
            try
            {
                wordApp= new Word.Application();
                wordApp.Visible= false;
            }
            catch
            {
                MessageBox.Show("Товарный чек в Word создать не удалось");
                return;
            }
            //Создание документа Word
            wordDoc = wordApp.Documents.Add(); //добавить новый пустой документ
            wordDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;

            //**************Первый параграф - заголовок документа: логотип и дата
            wordPar = wordDoc.Paragraphs.Add();
            wordPar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            wordRange = wordPar.Range;
            wordPar.set_Style("Заголовок 1"); //Стиль взятый из Word
            //Текст первого абзаца - заголовка документа
            wordRange.Text = "Дата заказа: " + DateTime.Now.ToLongDateString();
            //Добавить логотип
            wordShape = wordDoc.InlineShapes.AddPicture(@"C:\Users\FEDPo\Documents\Csharp\shop\shop\Resources\logo.png", Type.Missing, Type.Missing);
            wordShape.Width= 100;
            wordShape.Height= 100;
            //************Второй параграф - текст
            wordRange.InsertParagraphAfter();
            wordPar = wordDoc.Paragraphs.Add();
            wordPar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            wordRange = wordPar.Range;
            wordRange.Font.Size = 16;
            wordRange.Font.Color = Word.WdColor.wdColorBlue;
            wordRange.Font.Name = "Time New Roman";
            wordRange.Text = "Список купленных вещей";
            //**********Третий параграф - таблица
            wordRange = wordPar.Range;
            //Число строк в таблице совпадает с числом строк в таблице заказов формы
            wordTable = wordDoc.Tables.Add(wordRange, inBucket.Count + 1, 4);
            wordTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            wordTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleDouble;
            //Заголовок таблицы из DataGrid
            Word.Range cellRange;
            for (int col = 1; col <= 4; col++)
            {
                cellRange = wordTable.Cell(1, col).Range;
                cellRange.Text = dgOrder.Columns[col - 1].Header.ToString();
            }
            //Заливка заголовка таблицы
            wordTable.Rows[1].Shading.ForegroundPatternColor = Word.WdColor.wdColorLightYellow;
            wordTable.Rows[1].Shading.BackgroundPatternColorIndex = Word.WdColorIndex.wdBlue;
            wordTable.Rows[1].Range.Bold = 1;
            wordTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            wordRange.Font.Size = 14;
            wordRange.Font.Color = Word.WdColor.wdColorBlue;
            wordRange.Font.Name = "Time New Roman";
            //wordRange.Font.Italic= 1;
            //Заполнение ячеек таблицы из списка заказов
            wordPar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            //wordPar.set_Style("Заголовок 2");
            for (int row = 2; row <= inBucket.Count+1 ; row++)
            {
                cellRange = wordTable.Cell(row, 1).Range;
                cellRange.Text = inBucket[row - 2].Name;
                wordRange.Font.Size = 14;
                wordRange.Font.Color = Word.WdColor.wdColorBlack;
                wordRange.Font.Name = "Time New Roman";
                //wordRange.Font.Italic= 0;
                cellRange = wordTable.Cell(row, 2).Range;
                cellRange.Text = inBucket[row - 2].Cost.ToString();
                cellRange = wordTable.Cell(row, 3).Range;
                cellRange.Text = inBucket[row - 2].Quantity.ToString();
                cellRange = wordTable.Cell(row, 4).Range;
                cellRange.Text = inBucket[row - 2].Price.ToString();

            }
            //***********Четвертый параграф - итоги
            wordRange.InsertParagraphAfter();
            wordPar = wordDoc.Paragraphs.Add();
            wordRange = wordPar.Range;
            wordPar.set_Style("Заголовок 1"); //Стиль взятый из Word
            wordRange.Font.Size = 20;
            wordRange.Font.Color = Word.WdColor.wdColorRed;
            wordRange.Bold = 3;
            wordRange.Text = "Стоимость заказа: " + sumOrder.ToString() + " рублей";
            wordApp.Visible = true;
            //Сохранение документа
            string fileName = App.pathExe + @"\Чек";
            wordDoc.SaveAs2(fileName + ".docx");
            wordDoc.SaveAs2(fileName + ".pdf", Word.WdExportFormat.wdExportFormatPDF);
            //Завершение работы с Word
            wordDoc.Close(true, null, null); //сначала закрыть документ
            wordApp.Quit(); //выход из Word
            //Вызвать свою подпрограмму уничтожения процессов
            releaseObject(wordPar);         //уничтожить абзац
            releaseObject(wordDoc);          //уничтожить документ
            releaseObject(wordApp);                                    //удалить из Диспетчера задач


        }

        private void releaseObject (object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch(Exception e) 
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
