   M S B A M L   `   `   `  ����^  ZPOS and Inventory Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:POS_and_Inventory_Management_System#POS_and_Inventory_Management_System  5   	   2    ,POS_and_Inventory_Management_System.MainPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:POS_and_Inventory_Management_System     5   	     � Title$  	Dashboard��5   	   $	��650��6   $
��1400��6(    � 
ResizeMode$ NoResize=�65    � WindowStyle$
 None=�6K    � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers	 P� Property
 P� Value��%v  '��       �� 5   
   " ��6   .�5      ��  � �� �#FFC8576+   �� 5       � ��$ 0q�60   �� 5       � ��
 ���� 6+   �� 5       � ��$
 Thin"�6+   �� 5       � ��$ 20(�6)   �� 5       � ��$ 15,0,0,0q�6'   �� 5       � ��$
 Left=�64   �� 5       � �� 5      �� 5      " ��6"   .R�5      �� #��z��6   ._�5      �� $��Center=�6+   $��Center=�6H   5      5      5       5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  � ��
 �����63   �� 5       � ��$ 	UltraBold"�63   5       5#      5$      .��5&      �  � ColumnDefinitions 5'   
   �� 5(      $��1* �6   �� 5)      $��2* �6   .+�5,   
   �� ���#db3a34.+�5-      � $	��800��6    � RowDefinitions 5.      �� 5/      $��1.25* �6$   �� 50      $
��1.8* �6$   �� 51      $��* �6$   .+�54      �� $��0��6   $��0��6*   .+�55      �� -   5         ��Name$ 	userImage��55      $��0,20,0,0q�6/   $��Center=�6A   $	��130��6^   $	��130��6j   $��0��6w   $��0��6�   $��Assets/noImage.png��6�   6�   �� 56      -   5         ��Name$ usernameDisplay��56   5   $��Username��6N   $��23(�6a   $��Center=�6o   $��
UltraLight"�6�   $��142,0q�6�   
�������6�   �� 57      -   5        $ roleDisplay��57      $��SemiBold"�61   $��Administrator��6G   $��20(�6_   $��Center=�6m   
�������6�   59      �� 5;      $��1��6   $��0��6*   $
��Left=�6:   .+�5>      �� -   5         ��Name$ stackPanelBrand��5>   !    �� Orientation$ 
Horizontal=�6:   $��	20,15,0,0q�6T   .+�5?      �� $��Assets/supplierIcon.PNG��6    $��30��6A   $��30��6L   �� 5@      -   5         ��Name$ manageBrandButton��5@   !   $��Manage Brand��6=   5A      5B      �� 5D      -   5        $ stackPanelCategory��5D   !   $ 
Horizontal=�6=   $��	20,15,0,0q�6W   .+�5E      �� $��Assets/categoryIcon.PNG��6    $��30��6A   $��30��6L   �� 5F      -   5        $ manageCategory��5F   !   $��Manage Category��6;   5G      5H      �� 5J      -   5        $ stackPanelProduct��5J   !   $ 
Horizontal=�6<   $��	20,15,0,0q�6V   .+�5K      �� $��Assets/productIcon.PNG��6    $��30��6@   $��30��6K   �� 5L      -	   5        $ manageProduct��5L   !   $��Manage Product��69   5M      5N      �� 5Q      -
   5        $ stackPanelStock��5Q   !   $ 
Horizontal=�6:   $��	20,15,0,0q�6T   .+�5R      �� $��Assets/stockIcon.PNG��6    $��30��6>   $��30��6I   �� 5S      -   5        $ stockInButton��5S   !   $��Stock In��6:   5T      5U      �� 5Y      -   5        $ stackPanelPOS��5Y   !   $ 
Horizontal=�68   $��	20,15,0,0q�6Q   .+�5Z      �� $��Assets/posIcon.PNG��6    $��30��6<   $��30��6G   �� 5[      -   5        $��Point Of Sale��5[   9   5\      5]      �� 5e      -   5        $ stackPanelUser��5e   !   $ 
Horizontal=�69   $��	20,15,0,0q�6S   .+�5f      �� $��Assets/userIcon.PNG��6    $��30��6=   $��30��6H   �� 5g      -   5        $ manageUserButton��5g   !   $��User Settings��6=   5h      5i      5n      �� 5p      $��2��6   $ 
Horizontal=�6*   $	��Top=�6D   $��20,0,0,0q�6\   .+�5q      �� $��Assets/logouticon.PNG��6   $��30��6;   $��30��6F   �� 5r      -   5        $ logOut��5r      $��Logout��6-   
�������5s      5t      5w      5}      �� 5   
   -   5        $ displayPanel��5      $��0��6+   $��2��68   ��5�      �� 5�       �� ImageSource$ Assets/asia.jpg��6   5�      5�      5�      