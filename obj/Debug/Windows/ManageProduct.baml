   M S B A M L   `   `   `  ����^  ZPOS and Inventory Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:POS_and_Inventory_Management_System.Windows+POS_and_Inventory_Management_System.Windows  5   	   ?    9POS_and_Inventory_Management_System.Windows.ManageProduct   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Klocal9clr-namespace:POS_and_Inventory_Management_System.Windows     5   	   -   5          � Title$  ManageProduct��5   	   $	��650��6   $
��1000��6,    � 	Resources 5
      ��%    5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��1.7* �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   ��5      �� 5       �� ImageSource$D >/POS and Inventory Management System;component/Assets/asia.jpg��6    j� Stretch$
 None=�6j    �� Opacity$ 0.499Q�6y   .+�5!      �� $��40(�6    $��Center=�6.   Manage Product6\   �� 5#      $ 
Horizontal=�6   $��Center=�66   .+�5%      �� $
��auto��6!   $ Vertical=�6.   $
��Left=�6E   .+�5'      �� $ 
Horizontal=�6%   $��	10,10,0,0q�6?   .+�5(      �� -   5         ��Name$ textBlockProductCode��5(   )   $��Product Code:��6G   $��16(�6\   �� 5)      -   5         ��Name$ textBoxProductCode��5)   9   $��10,0,0,0q�6'   $	��200��6U   $��25��6a   $
��Left=�6m   $��Center=�6�   5*      �� 51      $ Horizontal =�6%   $��	10,10,0,0q�6?   .+�52      �� -   5        $ textBlockBrand��52   (   $��Brand:��6@   $��16(�6N   �� 53      -   5        	 ��Name$	 comboBoxBrand��53   :   $��60,0,0,0q�6(   $	��200��6Q   $��25��6]   $
��Left=�6i   $��Center=�6�   54      �� 56      $ Horizontal =�6%   $��	10,10,0,0q�6?   .+�57      �� -   5        $ textBlockCategory��57   (   $��	Category:��6C   $��16(�6T   �� 58      -   5        $	 comboBoxCategory��58   :   $��40,0,0,0q�6(   $	��200��6T   $��25��6`   $
��Left=�6l   $��Center=�6�   59      �� 5;      $ Horizontal =�6%   $��	10,10,0,0q�6?   .+�5<      �� -   5        $ textBlockPrice��5<   (   $��Price:��6@   $��16(�6N   �� 5=      -	   5        $ textBoxPrice��5=   9   $��66,0,0,0q�6'   $	��200��6O   $��25��6[   $
��Left=�6g   $��Center=�6�   5>      �� 5C      -
   5        
 ��Name$
 buttonClear��5C   !   $
��Left=�67   $��20,0,0,0q�6R   $��Clear��6d   $��12(�6t   $��50��6�   $��20��6�   {�. 6�   5F      �� 5H      $ Vertical=�6!   $��	20,10,0,0q�68   .+�5I      �� -   5        $ textBlockDesc��5I   $   $��Description:��6;   $��16(�6O   �� 5J      -   5        $ textBoxDesc��5J   "   $��0,20,0,0q�67   $	��120��6I   $	��300��6V   5K      �� 5M      $��Center=�6!   $��20,0,0,0q�6>   .+�5N      �� -   5        $
 buttonAddProduct��5N   !   $��0,10,0,0q�6<   $��Add Product��6N   $��15(�6d   $	��100��6r   $��40��6~   6�   �� 5O      -   5        $
 buttonUpdateProduct��5O   !   $��0,10,0,0q�6>   $��Update��6P   $��15(�6a   $	��100��6o   $��40��6{   {�.  6�   �� 5P      -   5        $
 buttonDeleteProduct��5P   !   $��0,10,0,0q�6>   $��Delete��6P   $��15(�6a   $	��100��6o   $��40��6{   {�.  6�   5S      5T      5^      �� 5`   
   $��3q�6   
�������$��10q�6;   $��1��6G   ��5b      �� 5c      $��PRODUCT LIST��6   $��18(�60   $��
ExtraBlack"�6>   $
��Left=�6V   .��5g      �� 
�������.+�5h      �� $ 
Horizontal=�6   $��0,0,0,10q�66   .+�5j      �� $��20,2,0,0q�6$   $��Search Product: ��66   $��15(�6N   $
��Left=�6]   �� 5k      $��0,5,0,0q�6   $	��150��61   $
��auto��6=   5l      &   System.Windows.Controls.DataGrid  5o      -   5          Name$ dataGridProduct��5o   s   ��. $��Visible=�6@   $	��310��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   5q      5t      5v      5}      5~      