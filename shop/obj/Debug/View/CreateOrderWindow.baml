   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:shop.View	shop.View  5   	   ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration 5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5	   	   m iSystem.Windows.Forms.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�mclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization/System.Windows.Forms.DataVisualization.Charting 5
   	   !    shop.View.CreateOrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:shop.View     5   	   _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5	   	   }dvcmclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization     5
   	   -   5          � Title$  Создать заказ��5   	   $	��450��6   $	��800��6,   $	��800��68   $	��450��6G   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   � $��0��6   
������� � ColumnDefinitions 5      �� 5      $��50 �6#   �� 5      $��2* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $B��<C:\Users\FEDPo\Documents\Csharp\shop\shop\Resources\logo.png��6$   $
��Fill=�6j   �� 5      $��1��6   $#��Создание заказа��6)   �� 5      -   5         ��Name$ butMainMenu��5      $��2��6*   $��10q�5      $��Главное меню��6!   68   5      � 5"   
   $��1��6   ��5#      �� 5$       �� ImageSource$A ;C:\Users\FEDPo\Documents\Csharp\shop\shop\Resources\fon.jpg��6    5&      �� 5'      $
��0.5* �6    �� 5(      $��* �6    �� 5)      $��* �6    �� 5*      $��* �6    �� 5+      $
��0.5* �6    .+�5.      �� -   5        $ butCreateOrder��5.      $!��Оформить заказ��6-   $��4��6F   $��Right=�6S   $��0,0,10,0q�6o   z�5/      �� 50       �� AngleX$ 10Q�6$   52      �� 53      -   5         ��Name$ tb_fromCard��53      $"��Сумма на карте: ��6-   
�������$
��Left=�6Y   $��30,0,0,0q�6t   $��4��6�   $
��Wrap=�6�   $��Center=�6�   �� 54      -   5         ��Name$ listCategoty��54      $��1��6W   $��2��6d   
�������$	��167��55      $	��212��6#   $
��Left=�6/   $��	30,10,0,0q�6J   $	��Top=�6]   58      �� 5;       �� Orientation$ 
Horizontal=�6   $��3��62   $��0��6?   $��Stretch=�5<      $��Stretch=�63   $
��30,5q�6O   ��5;   O   Z� .+�5=      �� $ Vertical=�6   $��2��64   $��0��6A   5>      7  1System.Windows.Forms.Integration.WindowsFormsHost  5?      $��70��69   $��83��6E   	   
Background	 6#   Z� 
   Child.
 5@      ;  5System.Windows.Forms.DataVisualization.Charting.Chart  -   5        
chartSumma��"  System.Windows.Forms.Control   Width$	 100��5@   4      Height$ 50��6@   5A      5B      �� 5E      -   5        $ tb_fromCard_Copy��5E      $6��0Список категорий товаров: ��62   
�������$
��Left=�6h   $��	30,10,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   �� 5F      -   5        $ tb_fromCard_Copy1��5F      $6��0Список выбранных товаров: ��63   
�������$
��Left=�6i   $��	479,0,0,0q�6�   $
��Wrap=�6�   �� 5G      -	   5        $ listViewClothes��5G      $��1��60   
�������$	��216��5H      $	��497��6#   $
��Left=�6/   $��
276,10,0,0q�6J   $	��Top=�6^   $��3��6v   ��5I      �� 5J      .R�5K      �  5L      �� 5M   "   $��* �63   �� 5N   "   $��3* �63   �� 5O   "   $��* �63   .+�5Q      �� $��0��6$   $��70��66   $��70��6A   $
��Fill=�6l   $��0,0,20,0q�6{   ��6N   ��  �� Path$ Photo�6{   �� 5R      $��1��6)   $ Vertical=�6;   $��Center=�6R   .+�5S   "   �� $��12(�6,   �� 5T   &   $�Название: ��6*    �� 5U   &   �6*   �� $
 Name�5V   #   �� 5W   "   $��Strikethrough{�6,   $��12(�6L   �� 5X   &   $�
Цена: ��6*    �� 5Y   &   �6*   �� $
 Cost�5Z   #   �� 5[   "   $��12(�6,   �� 5\   &   $$�Цена со скидкой: ��6*    �� 5]   &   �6*   �� $ Discount�5^   #   �� 5_   "   $��12(�6,   �� 5`   &   $�Рейтинг: ��6*    �� 5a   &   �6*   �� $ Rating�5b   #   5c      �� 5d      -
   5        $��2��5d   %   $(��"Добавить в корзину��65   $��12(�6R   $��Right=�6`   6|   5e      5g      5i      �� 5k      -   5        $ tb_summOrder��5k      $��Сумма заказа: ��6.   
�������$��3��6W   $
��Wrap=�6d   $��-161,79,161,10q�6x   $��2��6�   5m      � 5r   
   $��2��6   
������� 5s      �� 5t      $��* �6#   �� 5u      $��* �6#   .+�5x      �� $��0��6   $��@Федулова П.А��6(   $
��Left=�5y      $��Center=�63   $��Comic Sans MS)�5z      $��14(�63   �� 5{      $��1��6   $��FEDPolina_A@bk.ru��6(   $��Right=�5|      $��Center=�64   $��Comic Sans MS)�5}      $��14(�63   5~      5�      5�      