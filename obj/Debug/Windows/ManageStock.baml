   M S B A M L   `   `   `  ����^  ZPOS and Inventory Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:POS_and_Inventory_Management_System.Windows+POS_and_Inventory_Management_System.Windows  5   	   =    7POS_and_Inventory_Management_System.Windows.ManageStock   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Klocal9clr-namespace:POS_and_Inventory_Management_System.Windows     5   	   -   5          � Title$  ManageStock��5   	   $	��700��6   $
��1000��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      �� $
��auto��6    �� Orientation$ 
Horizontal=�6'   ��5      �� 5       �� ImageSource$D >/POS and Inventory Management System;component/Assets/asia.jpg��6!    j� Stretch$ UniformToFill=�6n   .+�5      �� $ 
Horizontal=�6   .+�5      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5      �� $ Vertical=�6%   $
��AUTO��6<   $��	90,10,0,0q�6I   .+�5      �� $ 
Horizontal=�6)   .+�5   "   �� $ Vertical=�6-   $��0,0,0,0q�6D   .+�5   &   �� $��Reference Code: ��60   �� 5    &   -   5         ��Name$ textBoxRefCode��5    .   $	��150��6F   5!   #   �� 5#   "   $ Vertical=�6-   $��20,0,0,0q�6D   .+�5$   &   �� $��Stock In by: ��60   �� 5%   &   -   5        $ textBoxStockInBy��5%   .   $	��130��6H   5&   #   5+      �� 5-      $ 
Horizontal=�6)   .+�51   "   �� $ Vertical=�6-   .+�52   &   �� $��Date Issued: ��60   (  "System.Windows.Controls.DatePicker  53   &   -   5        $��datePickerDateIssued��53   1   $	��150��6M   $
��Left=�6Y   54   #   �� 58   "   $ Vertical=�6-   $��20,0,0,0q�6D   .+�59   &   �� $ ��Quantity of items to add: ��60   �� 5:   &   -   5        $ 
textBoxQty��5:   .   $��75��6f   $
��Left=�6q   6�   5;   #   5?      5C      5G      �� 5O      $ Vertical=�6!   $��300,10,20,20q�68   .+�5P      �� .+�5Q      �� $ ��Search Product via PCode: ��6(   �� 5R      -   5        $ textBoxSearchPCode��5R   &   $	��150��6o   $
��Left=�6{   6�   5T      �� 5V      .+�5W      �� $��Search Product via Desc: ��6(   �� 5X      -   5        $ textBoxSearchPName��5X   &   $	��150��6o   $
��Left=�6{   6�   5Y      5]      �� 5_      5a      5c      �� 5f      $��2q�6   
�������$��10q�6>   $	��200��6J   ��5g      �� 5h      $��Products��6    $��20(�60   .��5j      �� .+�5k      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridProduct��5k   �   ��. $��Visible=�6E      AutoGenerateColumns .    
IsReadOnly . $	��170��6�   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 6�   5m      5n      5p      5t      �� 5v   
   $��1��6   .+�5x      �� 
�������$��2q�6*   $��10q�6>   ��5y      �� 5z      $��Products��6    $��20(�60   .��5|        -	   5        $ dataGridTemporaryProduct��5|   s   ��. $��Visible=�6@   $	��250��6�   $	 * 6�    .  .  
   Columns
 5}      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Reference Code��6-      Width$	 100 6E      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6c   �� *
TRefCode+  5�      $ Date Issued��6-    . $	 100 6U    6a   �� *TDate+  5�      $ Product Desc��6-    .  6V   �� *TPDesc+  5�      $ Price��6-   $ 50 6<    .  6Z   �� *TPrice+  5�      $	 Qty��6-   $ 50 6:    .  6X   �� *TQty+5�      5�      �� 5�      $ 
Horizontal=�6   $��Right=�62   $��0q�6N   $
��AUTO��6Y   $
��AUTO��6g   .+�5�      �� -
   5         ��Name$ buttonConfirm��5�      $��Confirm Stocks��61   $��00,5,0,0q�6f   $	��100��6x   $��20��6�   �� 5�      -   5        $ buttonClear��5�      $��Clear Fields��6.   $��10,5,0,0q�6_   $��20��6q   �� 5�      -   5        $ buttonRemove��5�      $��Remove temporary stocks��6/   $��10,5,0,0q�6l   $��20��6~   $
��AUTO��6�   5�      5�      5�      5�      