   M S B A M L   `   `   `  ����^  ZPOS and Inventory Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:POS_and_Inventory_Management_System.Windows+POS_and_Inventory_Management_System.Windows  5      <    6POS_and_Inventory_Management_System.Windows.ManageUser   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Klocal9clr-namespace:POS_and_Inventory_Management_System.Windows     5      -   5          � Title$  
ManageUser��5	   	   $	��450��6   $	��800��6)   .��5      � ��5   
   �� 5       �� ImageSource$D >/POS and Inventory Management System;component/Assets/asia.jpg��6    j� Stretch$ UniformToFill=�6f    � ColumnDefinitions 5   
   �� 5      $
��24.8 �6   �� 5      $��424.8 �6   �� 5      .+�5   
   �� $��20q�6   $��0��6!   $��2��61   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridUser��5   �   ��. $��Visible=�6<   $��10q�6�   $	��300��6�      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ User ID:��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6V   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *UserId+6`     5      $ 	Username:��6)   $	 * 6Y   
 .  6<   �� *
Username+6d     5      $ 	Fullname:��6)   $		 200 6Y   
 .  6<   �� *
Fullname+6f     5      $ Role:��6)   $	 * 6V   
 .  68   �� *
RoleName+6`   5      �� 5       -   5         ��Name$ buttonDelete��5       $
��Left=�6F   $��10q�6a   $��Delete��6m   $��80��6~   $��30��6�   5"      �� 5'   
   $��25q�6   $��2��6   
�������$��4q�6B   ��5(      �� 5)      $��	User List��6   $��20(�6-   $��	heveltica)�6;   $��
UltraLight"�6R   $��Center=�6j   .��5-      �� $��2q�6   .+�5.      ��  �� Orientation$ 
Horizontal=�6   $��
10,0,10,10q�66   .+�5/      �� $��User ID:��6    $��18(�60   �� 50      -   5         ��Name$ labelUserId��50       $��25,0,0,0q�65   $
��????��6G   $��18(�6S   51      �� 53      $ 
Horizontal=�6   $��
10,0,10,10q�66   .+�54      �� $��
Full Name:��6    $��18(�62   �� 55      -   5         ��Name$ textBoxFullName��55      $��5,0,0,0q�67   $	��180��6H   $��18(�6T   56      �� 59      $ 
Horizontal=�6   $��
10,0,10,10q�66   .+�5:      �� $��	Username:��6    $��18(�61   �� 5;      -   5        $ textBoxUserName��5;      $��3,0,0,0q�67   $	��180��6H   $��18(�6T   5<      �� 5>      $ 
Horizontal=�6   $��
10,0,10,10q�66   .+�5?      �� $��	Password:��6    $��18(�61   G� 5@      -   5         G�Name$ textBoxPassword��5@   "   $��9,0,0,0q�6;   $	��180��6L   $��18(�6X   5A      �� 5D      $ 
Horizontal=�6   $��
10,0,10,10q�66   .+�5E      �� $��Role:��6    $��18(�6-   �� 5F      -   5         ��Name$ comboBoxRole��5F      $��46,0,0,0q�65   $	��180��6G   $��18(�6S   5H      5I      �� 5J      $ 
Horizontal=�6   $��
10,0,10,10q�66   .+�5K      �� $��Contact:��6    $��18(�60   �� 5L      -	   5        $ textBoxContact��5L      $��22,0,0,0q�66   $	��180��6H   $��18(�6T   5M      �� 5N      $ 
Horizontal=�6   $��
10,0,10,10q�66   .+�5O      �� $��Email:��6    $��18(�6.   �� 5P      -
   5        $ textBoxEmail��5P      $��38,0,0,0q�64   $	��180��6F   $��18(�6R   5Q      �� 5S      $ 
Horizontal=�6   $��0,5,0,0q�66   .+�5T      �� -   5        $ buttonUpdate��5T      $��Update��6N   $��10q�6_   $��80��6k   $��30��6v   �� 5U      -   5        $ 	buttonNew��5U      $��New Account��6H   $��10q�6^   $��30��6j   $��80��6v   �� 5V      -   5        $ buttonClear��5V      $��Clear��6L   $��10q�6\   $��30��6h   $��50��6t   5X      5Y      5\      5_      5`      