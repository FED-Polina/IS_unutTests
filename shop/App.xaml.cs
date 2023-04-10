using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Exel = Microsoft.Office.Interop.Excel; //подключение excel
using Word = Microsoft.Office.Interop.Word;

namespace shop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Данные для авторизации администратора
        public static string Login = "admin";
        public static string Password = "shop";

        //Данные для работы с Excel
        public static Exel.Application excelApp; //сервер excel
        public static Exel.Workbook excelBook; //отдельная книга
        public static Exel.Worksheet excelSheet; //один лист
        public static Exel.Range excelCells; //ячейки листа

        //Пути к файлам приложения
        public static string pathExe = Environment.CurrentDirectory; //к файлу exe
        public static string fileMenu = pathExe + @"\PriceList1.xlsx"; //к файлу Exel

        protected override void OnExit(ExitEventArgs e) //для закрытия Excel
        {
            App.excelApp.Quit(); //Выйти из Excel
            //Уничтожить все COM-объекты
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(App.excelApp);
            //Заставляет сборщик мусора произвести сборку мусора
            GC.Collect();
            base.OnExit(e);
        }
    }

    
}
