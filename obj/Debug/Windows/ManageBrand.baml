   M S B A M L   `   `   `  ����^  ZPOS and Inventory Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:POS_and_Inventory_Management_System.Windows+POS_and_Inventory_Management_System.Windows  5   	   =    7POS_and_Inventory_Management_System.Windows.ManageBrand   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Klocal9clr-namespace:POS_and_Inventory_Management_System.Windows     5   	   -   5          � Title$  ManageBrand��5   	   $	��750��6   $
��1400��6*    � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName��%�  '��       '�� ?    �� 5   
   " ��6   .�5      ��  � ��$ 5q�6(   �� 5       � ��$ 5q�6'   �� 5       � ��$ 15(�6)   �� 5       � ��$ 20��6*   �� 5       � ��$	 200��6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   $ 5��5   !   
�������$��1q�5   !   
�������._�5      �� $ PART_ContentHost��6+   |�.  $��Hidden=�5   !   $��Hidden=�5   !   5      	 5      P� 5       
 �@J�IsMouseOver . . �5!   "   �� $ border��6@    � ��
 ��  �6T   �� 5"   "    � ��
 �����6?   �� 5#   "    � ��$
 Bold"�6?   5$      P� 5%      
 �@J�	IsFocused . . �5&   "   ��  � ��
 ��  �6?   �� 5'   "   $ border��6@    � ��
 ��  �6T   5(      5*      5,      5-      �� 5.   
   " ��6   .�5/      ��  � ��$ 0,8,0,0q�6'   �� 50       � �� �#084C616+   �� 51       � ��$ SemiBold"�6+   52      55      .��58      � 
������� � ColumnDefinitions 5:   
   �� 5;      $
��0.9* �6   �� 5<      $��2* �6   .+�5@   
   �� $��0��6   $��0��6"   ��5A      �� 5B       �� ImageSource$C =/POS and Inventory Management System;component/Assets/bg1.jpg��6    j� Stretch$ UniformToFill=�6i   .+�5H      �� $��2q�6   
�������$��20q�6>   ��5I      �� 5J      $��	Underline{�6    ���#177E89$��
UltraLight"�6Q   $��Right=�6i   $��36(�6�   MANAGE BRAND6�   .��5M      �� -   5         ��Name$ Controls��5M      .+�5Q      ��  �� Orientation$ 
Horizontal=�6!   $��	20,10,0,0q�6:   .+�5R      �� -   5         ��Name$ labelSearchName��5R   $   $��Search Brand: ��6=   $��20(�6S   $��0,8,0,0q�6a   �� 5S      -   5         ��Name$ textBoxSearchName��5S   "   $��10,0,0,0q�6>   6P   5T      �� 5W      $ 
Horizontal=�6!   $��	20,45,0,0q�6:   .+�5X      �� -   5        $ labelBrandID��5X   $   $��
Brand ID: ��6:   $��20(�6L   �� 5Y      -   5        $ labelBrandIDModify��5Y   $   $��10,0,0,0q�6A   $��20(�6S   $��Center=�6a   $
��Left=�6|   5Z      �� 5]      $ 
Horizontal=�6!   $��	20,10,0,0q�6:   .+�5^      �� -   5        $ labelBrandName��5^   $   $��Brand Name: ��6<   $��20(�6P   �� 5_      -   5        $ textBoxBRandName��5_   "   $��16,0,0,0q�6=    �� TextWrapping$
 Wrap=�6O   $
��Left=�6c   $��Center=�6�    J� RenderTransformOrigin$ 0.608,0.445&�6�   5`      �� 5a      $ 
Horizontal=�6!   $��	20,10,0,0q�6:   .+�5b      �� -	   5        $ labelAddress��5b   $   $��Address ��6:   $��20(�6J   �� 5c      -
   5        $ textBoxAddress��5c   "   $��60,0,0,0q�6:   $
��Left=�6M   $��Center=�6o   5d      �� 5e      $ 
Horizontal=�6!   $��	20,10,0,0q�6:   .+�5f      �� -   5        $ labelContactNumber��5f   $   $��	Contact: ��6@   $��20(�6Q   �� 5g      -   5        $ textBoxContactNumber��5g   "   $��58,0,0,0q�6@   $
��Left=�6w   $��Center=�6�   5h      �� 5i      $ 
Horizontal=�6!   $��	20,10,0,0q�6:   .+�5j      �� -   5        $ 
labelEmail��5j   $   $��Email: ��68   $��20(�6G   �� 5k      -   5        $ textBoxEmail��5k   "   $��79,0,0,0q�68   $
��Left=�6K   $��Center=�6m   5l      �� 5n      -   5         ��Name$ buttonClear��5n      $��Right=�62   $��	0,20,30,0q�6O   $��Clear��6b   $��20(�6r   $��70��6�   $��40��6�   {�. 6�   5q      5s      �� 5v      $ 
Horizontal=�6   $��0,50,0,0q�62   .+�5w      �� -   5        $ buttonAddBrand��5w      $��20,0,0,0q�61   $	��Add��6C   $��20(�6Q   $	��120��6_   $��40��6k   6w   �� 5x      -   5        $ buttonUpdateBrand��5x      $��20,0,0,0q�64   $��Update��6F   $��20(�6W   $	��120��6e   $��40��6q   {�.  6�   �� 5y      -   5        $ buttonDeleteBrand��5y      $��20,0,0,0q�64   $��Delete��6F   $��20(�6W   $	��120��6e   $��40��6q   {�.  6�   5{      5      &   System.Windows.Controls.DataGrid  5�   
   -   5          Name$ dataGridBrand��5�      ��. $��Visible=�6P   $
��auto��6�   
������� � Cursor$ UpArrow��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      
IsReadOnly . $��2��6  $��428,0,-0.4,-0.2q�6!  5�      5�      