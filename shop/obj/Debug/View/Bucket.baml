   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:shop.View	shop.View  5   	       shop.View.Bucket   5   	   ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:shop.View     5   	     � Title$2  ,Оформить заказ (корзина)��5   	   $	��450��6*   $	��800��67   $	��800��6D   $	��450��6S   .��5
      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   � $��0��6   
������� � ColumnDefinitions 5      �� 5      $��50 �6#   �� 5      $��2* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $B��<C:\Users\FEDPo\Documents\Csharp\shop\shop\Resources\logo.png��6$   $
��Fill=�6j   �� 5      $��1��6   $'��!Оформление заказа��6)   �� 5      -   5         ��Name$ butMainMenu��5      $��2��6*   $��10q�5      $��Главное меню��6!   68   5      � 5   
   $��1��6   ��5       �� 5!       �� ImageSource$A ;C:\Users\FEDPo\Documents\Csharp\shop\shop\Resources\fon.jpg��6    5#      �� 5$      $��* �6    �� 5%      $
��0.2* �6    .+�5(      �� -   5        $ butCreateOrder��5(      $��Каталог��6-   $��4��6?   $
��Left=�6L   $��0,0,10,0q�6g   z�5)      �� 5*       �� AngleX$ 10Q�6$   5,      �� 5-      -   5         ��Name$ tb_fromCardCreate��5-      $&�� Остаток на карте: ��63   
�������$
��Left=�6a   $��
139,16,0,0q�6|   $��4��6�   $
��Wrap=�6�   $	��Top=�6�   �� 5.      -   5        $ tb_summOrder��5.      $��Сумма заказа: ��6.   
�������$
��Left=�6X   $��
527,17,0,0q�6s   $��4��6�   $
��Wrap=�6�   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5/      -   5          Name$ dgOrder��5/      $��Segoe Print)�6(   $��12(�6A   
����������	#FF4E0091$��10,10,10,66q�6z      CanUserAddRows .  	   CanUserResizeColumns	 .  
   AutoGenerateColumns
 .     Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51         
Foreground �	#FF080808,  &System.Windows.Controls.DataGridColumn   Header$ Название��6@      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6R      
FontFamily$ Segoe Print)�6^      
FontWeight$ Normal"�6w   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6�   �� *Name+  52      $ Цена��6)   $	 100 67   $ Segoe Print)�6C    6\   �� *Cost+  53      $ Кол-во��6)   $ 60 69   $ Segoe Print)�6D    6]   �� *
Quantity+  54      $ 
Итого��6)   $	 100 68   $ Segoe Print)�6D    6]   �� *Price+4  .System.Windows.Controls.DataGridTemplateColumn  55      $ Действия��6-   $ * 6?      CellTemplate 56      �� 57      .R�58   "   ��  �� Orientation$ 
Horizontal=�6-   .+�59   &   �� $��btnPlus��6-   -   5        $��40��59   R   $��0,0,5,0q�6]   
 � Tag 6n   �� *Name+.��6�   +6�   �� 5:   &   $��btnMinus��6-   -   5        $��40��5:   T   $��0,0,5,0q�6_    6p   �� *Name+.��6�   -6�   �� 5;   &   $��	btnDelete��6-   -   5        $��40��5;   V    6a   �� *Name+.��6w   X6z   5<   #   5>      5A      5C      �� 5D      -	   5        $ 	but_Check��5D      $��Корзина��6(   $
��Left=�6:   $��
10,250,0,0q�6n   $	��Top=�6�   z�5E      �� 5F      $ 10Q�6$   5H      5J      � 5M   
   $��2��6   
������� 5N      �� 5O      $��* �6#   �� 5P      $��* �6#   .+�5S      �� $��0��6   $��@Федулова П.А��6(   $
��Left=�5T      $��Center=�63   $��Comic Sans MS)�5U      $��14(�63   �� 5V      $��1��6   $��FEDPolina_A@bk.ru��6(   $��Right=�5W      $��Center=�64   $��Comic Sans MS)�5X      $��14(�63   5Y      5Z      5[      