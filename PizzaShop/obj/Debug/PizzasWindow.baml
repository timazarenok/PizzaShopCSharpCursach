   M S B A M L   `   `   `  ����D  @PizzaShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PizzaShop	PizzaShop  5   	       PizzaShop.PizzasWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PizzaShop     5   	     � Title$  PizzasWindow��5   	   $	��500��6   $	��800��6+   .��5	      � .+�5
   
   �� $	��Top=�6   $��Center=�6(   $��30(�6E   .��6S   Продукты6]   �� 5   
   $��Center=�6   $
��Left=�6+   $��17(�6F   $��
60,0,0,270q�6T   .��6h   Наименование6v   �� 5   
   -   5         ��Name$
 Name��5      $	��200��6    $��30��6,   $��Center=�68   $
��Left=�6S   $��
60,0,0,200q�6n   �� 5   
   $��Center=�6   $
��Left=�6+   $��17(�6F   $��
60,0,0,120q�6T   .��6h   
Цена6n   �� 5   
   -   5        $ Price��5      $	��200��6!   $��30��6-   $��Center=�69   $
��Left=�6T   $��60,50,0,100q�6o   6�   �� 5   
   $��Center=�6   $
��Left=�6+   $��17(�6F   $��60,130,0,100q�6T   .��6j   Размер6r   �� 5   
   -   5         ��Name$
 Size��5      $	��200��6!   $��30��6-   $��
60,100,0,0q�69   $��Center=�6M   $
��Left=�6h   �� 5   
   $��Center=�6   $
��Left=�6+   $��17(�6F   $��
60,170,0,0q�6T   .��6h   Тип6m   �� 5   
   -   5        $
 Type��5      $	��200��6!   $��30��6-   $��
60,250,0,0q�69   $��Center=�6M   $
��Left=�6h   �� 5   
   $��Center=�6   $��Center=�6+   $��17(�6H   $��360,200,0,20q�6V   .��6l   ID6p   �� 5   
   -   5        $ ID��5      $��50��6   $��30��6)   $��Center=�65   $��Center=�6P   $��360,250,0,0q�6m   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ Sizes��5      $	��300��6"   $	��200��6.   $��
400,0,0,50q�6;      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� 	 �� Path$	 ID�6M     5      $ Наименование��6%    6;   �� $
	 Name�  5      $ Цена��6%    63   �� $	 Price�  5      $ Размер��6%    65   �� $
	 Size�  5      $ Тип��6%    62   �� $
	 Type�5      �� 5   
   -   5        
 ��Name$	
 Add��5      $	��120��6   $��25��6*   $
��Left=�66   $��Center=�6Q   $��
60,350,0,0q�6l   .��6�   Добавить6�   �� 5   
   -   5        $
 Delete��5      $	��120��6!   $��25��6-   $��Center=�69   $��Center=�6V   $��370,350,0,0q�6q   .��6�   Удалить6�   5       5!      