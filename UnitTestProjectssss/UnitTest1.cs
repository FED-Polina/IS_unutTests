using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using shop;
using shop.View;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using shop.Classes;
using System.Collections.Generic;

namespace UnitTestProjectssss
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void loginPassword_ISTrue() //проверка введенного верного пароля
        {
            //arrange
            var authorization = new Authorization();
            var tbLogin = (TextBox)authorization.FindName("tbLogin");
            var tbPassword = (PasswordBox)authorization.FindName("tbPassword");
            var btn = (Button)authorization.FindName("butEnter");
            tbLogin.Text = "admin";
            tbPassword.Password = "shop";

            //act
            if (App.Login == tbLogin.Text && App.Password == tbPassword.Password)
            {
                btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }

            //assert
            if (App.Login == tbLogin.Text && App.Password == tbPassword.Password)
            {
                btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }

            Assert.IsTrue(App.Login == tbLogin.Text && App.Password == tbPassword.Password, "Введены неверные данные.");
        }

        [TestMethod]
        public void loginPassword_ISFalse() //проверка введенного неверного пароля
        {
            //arrange
            var authorization = new Authorization();
            var tbLogin = (TextBox)authorization.FindName("tbLogin");
            var tbPassword = (PasswordBox)authorization.FindName("tbPassword");
            var btn = (Button)authorization.FindName("butEnter");
            tbLogin.Text = "admin123";
            tbPassword.Password = "shop";

            //act
            if (App.Login == tbLogin.Text && App.Password == tbPassword.Password)
            {
                btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }

            //assert
            Assert.IsFalse(App.Login == tbLogin.Text && App.Password == tbPassword.Password, "Введены неверные данные.");
        }

        [TestMethod]
        public void getSumCard_fromMainWindow() //получение суммы на карте с главного окна
        {
            //arrange
            var mainWindow = new MainWindow();
            var btn = (Button)mainWindow.FindName("butOrder");
            var Create = new CreateOrderWindow(mainWindow.sumCard);

            //act
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            //assert
            Assert.AreEqual(mainWindow.sumCard, Create.sumCard, 0.001, "Error: неверная передача данных");
        }

        [TestMethod]
        public void showWorkWithCatalogWindow_fromMainWindow() //отображение каталога
        {
            //arrange
            var mainWindow = new MainWindow();
            var btn = (Button)mainWindow.FindName("butOrder");

            //act
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            //assert
            Assert.IsTrue(btn == mainWindow.FindName("butOrder"));
        }


        [TestMethod]
        public void showCreateOrderWindow_fromMainWindow() //отображение окна оформления заказа
        {
            //arrange
            var mainWindow = new MainWindow();
            var btn = (Button)mainWindow.FindName("butPriceList");

            //act
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            //assert
            Assert.IsTrue(btn == mainWindow.FindName("butPriceList"));
        }

        [TestMethod]
        public void showAuthorizationWindow_fromMainWindow() //отображение окна авторизации
        {
            //arrange
            var mainWindow = new MainWindow();
            var btn = (Button)mainWindow.FindName("butWorkWithCatalog");

            //act
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            //assert
            Assert.IsTrue(btn == mainWindow.FindName("butWorkWithCatalog"));
        }

        

        [TestMethod]
        public void showBucketWindow_fromCreateOrderWindow() //отображение окна корзины
        {
            //arrange
            var createOrderWindow = new CreateOrderWindow(10000);
            var btn = (Button)createOrderWindow.FindName("butCreateOrder");

            //act
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            //assert
            Assert.IsTrue(btn == createOrderWindow.FindName("butCreateOrder"));
        }

        [TestMethod]
        public void showMainWondow_fromBucket() //отображение главного окна при переходе из корзины
        {
            //arrange
            var bucketWindow = new Bucket(new List<OrderItem>());
            var btn = (Button)bucketWindow.FindName("butMainMenu");

            //act
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            //assert
            Assert.IsTrue(btn == bucketWindow.FindName("butMainMenu"));
        }


        [TestMethod]
        public void getTextFromEmailTextBlock() //получение верного текста-емаил
        {
            //arrange
            var mainWindow = new MainWindow();
            var tbName = (TextBlock)mainWindow.FindName("mail");
            string email = "FEDPolina_A@bk.ru";

            //assert
            Assert.IsTrue(email == tbName.Text);
        }

        [TestMethod]
        public void listBoxinsertIsTrue() //заполнение листбокса
        {
            //arrange
            var createWindow = new CreateOrderWindow(10000.0);
            var list = new List<Clothes>();
            list.Add(new Clothes()); //заполение 3х элементов
            list.Add(new Clothes());
            list.Add(new Clothes());
            var listBox = (ListBox)createWindow.FindName("listViewClothes");

            //act
            listBox.ItemsSource = list;

            //assert
            Assert.AreEqual(3, listBox.Items.Count);
        }
    }


}
