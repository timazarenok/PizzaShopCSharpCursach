   M S B A M L   `   `   `  ����D  @PizzaShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PizzaShop	PizzaShop  5   	       PizzaShop.SizesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PizzaShop     5   	     � Title$  SizesWindow��5   	   $	��450��6   $	��800��6*   .��5	      � .+�5
   
   �� $	��Top=�6   $��Center=�6(   $��30(�6E   .��6S   #!Размеры продуктов6f   �� 5   
   $��Center=�6   $
��Left=�6+   $��17(�6F   $��
60,0,0,170q�6T   .��6h   Наименование6v   �� 5   
   -   5         ��Name$
 Name��5      $	��200��6    $��30��6,   $��Center=�68   $
��Left=�6S   $��
60,0,0,100q�6n   �� 5   
   $��Center=�6   $
��Left=�6+   $��17(�6F   $��	60,0,0,20q�6T   .��6g   Граммы6o   �� 5   
   -   5        $ Gramms��5      $	��200��6"   $��30��6.   $��Center=�6:   $
��Left=�6U   $��	60,50,0,0q�6p   6�   �� 5   
   $��Center=�6   $
��Left=�6+   $��17(�6F   $��
360,0,0,20q�6T   .��6h   ID6l   �� 5   
   -   5        $ ID��5      $��50��6   $��30��6)   $��Center=�65   $
��Left=�6P   $��
360,50,0,0q�6k   6   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ Sizes��5      $	��200��6"   $	��200��6.   $��	400,0,0,0q�6;      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ��  �� Path$ ID�6M     5      $ Наименование��6%    6;   �� $
 Name�  5      $ Граммы��6%    65   �� $ Gramms�5      �� 5   
   -   5        	 ��Name$		 Add��5      $	��120��6   $��25��6*   $
��Left=�66   $��Center=�6Q   $��
60,150,0,0q�6l   .��6�   Добавить6�   �� 5   
   -   5        $	 Delete��5      $	��120��6!   $��25��6-   $
��Left=�69   $��Center=�6T   $��330,150,0,0q�6o   .��6�   Удалить6�   5      5      