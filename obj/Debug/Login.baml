   M S B A M L   `   `   `  ����^  ZPOS and Inventory Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:POS_and_Inventory_Management_System#POS_and_Inventory_Management_System  5   	   /    )POS_and_Inventory_Management_System.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:POS_and_Inventory_Management_System     5   	   LmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     5   	   -   5          � Title$  Login��5	   	   $	��475��6   $	��800��6$    � AllowsTransparency .  � WindowStyle$
 None=�6J    � 
ResizeMode$ NoResize=�6]   
�������.��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��2* �6    �� 5      $��2* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��30q�6,   $��Center=�68   $��Center=�6U   .+�5      �� $��10,0,0,0q�6   $��POStock��6&   $��30(�68   $��DemiBold"�6F   $��Center=�6\   �� 5      $��0,0,0,30q�6   $��Login��6&   $��20(�66   $��Light"�6D   $��Center=�6W   �� 5      .+�5      �� -   5         ��Name$ userNameTextBox��5      $��	Helvetica)�63   $��Light"�5      $��Username��5      $��20(�5      $��Center=�5      
�������
������ $��0q�5"      $	��200��5#      $��Center=�5$       J� Opacity$	 0.5Q�5%      $��25��5'      6"   �� 5(      $	��200��6   $��0,0,0,20q�6%   $��2��5)      
�������$	 0.5Q�5+      5-      �� 5.      .+�5/      G� -   5         G�Name$ passTextBox��5/      $��0,20,0,0q�63   $��	Helvetica)�6E   $��Light"�50      	 G� Password$	 Password��51      $��20(�52      $��Center=�53      
�������
������ $��0q�56      $	��200��57      $��Center=�58      $	 0.5Q�59      $��25��5:      6"   �� 5;      $	��200��6   $��2��5<      
�������$	 0.5Q�5>      5A      �� 5B      $��0,20,0,0q�6   .+�5C      �� -   5        
 ��Name$
 loginButton��5C   *   {�. $	��150��6?   ���	#FFECECEC$��Login��6|   5E      5K      �� 5N   
    �� CornerRadius$ 0��6   $��1��6"   ._�5P      �� -   5        $	��Top=�5P      $��Right=�6.   $��5q�6]   $��40��6h   $��	UltraBold"�6s   $��30��6�   $��20(�6�   $��X��6�   ��5S      �� 5T      .��5U      �  � Color$ 	#80F71301��6#    � Offset$
 0.01Q�65   � 5V      $ 	#FFF10101��6#   $ 1Q�65   5W      5Z      5b      5d      