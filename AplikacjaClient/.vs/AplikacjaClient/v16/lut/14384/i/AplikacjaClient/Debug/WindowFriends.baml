   M S B A M L   `   `   `  ����J  FAplikacjaClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AplikacjaClientAplikacjaClient  5   	   #    AplikacjaClient.WindowFriends   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:AplikacjaClient     5   	   -   5          � Title$  WindowFriends��5   	   $	��550��6   $	��350��6,    � WindowStyle$
 None=�68    � 
ResizeMode$ NoResize=�6h   .��5	      �    
stylPaneli#��[  6   .+�5   
   � $��	0,0,0,518q�6   $��25��6#     stylPanelijednokolorowy#��[ 6/   .+�5      �� $��	0,0,325,0q�6   $��logo.png��6'   �� 5      -   5        $��	325,0,0,0q�5       J� RenderTransformOrigin$ -0.093,0.533&�6j    J� Opacity$	 0.6Q�6�   ��6=   Z� ��6S   Z� ��5      �� 5       �� ImageSource$ 	close.png��6!   5      5      � 5   
   $��
0,35,0,475q�6   #��[ 6#    � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $��40 �6#   60   �� 5      $��40 �6#   60   .+�5       �� -   5        $��1��5       $��5,5,5,5q�6%   
�������.��5!      �� $��	loupe.png��6   6.   5#      �� 5$      -   5        $��2��5$      $��5,5,5,5q�6%   
�������.��5%      �� $��add-user.png��6   61   5'      �� 5(      -   5         ��Name$ filtrowanieFriends��5(      $��0��62   $��10,5,5,5q�6B   $
��Left=�6T   $��Center=�6v   
�������6�   5)      � 5*   
   $��
0,101,0,20q�6   ���	#FF787777.+�5+      �� $
��Auto=�6   $
��Auto=�6@   .��5,      &   System.Windows.Controls.DataGrid  -   5          Name$ gridFriends��5,      	   AutoGenerateColumns	 .  
   
IsReadOnly
 .    GridLinesVisibility$
 None=�6_   
������� �� AlternationCount$ 0��6�      RowBackground
 �����   Columns 5-      4  .System.Windows.Controls.DataGridTemplateColumn  5.         CellTemplate 5/      �� 50   "   .R�51   &   � $��40��6+   $	��330��67    52   *   �� 53   .   $��40 �6?   6L   �� 54   .   $��* �6?   6K   �� 55   .   $��40 �6?   6L   .+�59   *   �� $��0��60   $��student.png��6@   6W   �� 5;   *   $��1��64   $��Center=�6Z   $��18(�6u     stylText#��[ 6�   ���	#FF402F2F��6D   �� *Nick+6�   �� 5<   *    ��Name$ usuwanieZnajomego��61   -   5        $��3��5<   L   $��5,5,5,5q�6s   
���������6]   Z� .��5=   .   �� $��man.png��64   5?   /   5B   +   5C   '   5D   #   5F      5H      5J      5K      �� 5L   
   -   5         ��Name$ 	dodajznaj��5L      $��37,114,37,274q�6)   #��[  6@   $y�	Collapsed=�6d   .+�5M      � $��16��6   #��[ 6   .+�5N      �� $��	0,0,260,0q�6   $��student.png��6+   6B   �� 5O      $��
21,0,148,0q�6   #��[ 61   
Add user6_   �� 5P      -	   5        $��	260,0,0,0q�5P      ��5Q      �� 5R      $ 	close.png��6%   5T      5U      �� 5V      $��0,10,0,0q�6   $��20(�6*   #��[ 68   Enter user name6k   �� 5W      -
   5        $ wpisywanianowegoZnaj��5W      $��	10,5,10,0q�64   $��30��6H   $��Center=�6T   $��16(�6v   6�   �� 5X      -   5         ��Name$ bladznajomego��5X      ���	#FFAA2424$y�	Collapsed=�6G   Incorrect data6n   �� 5Y      -   5        $��80,10q�5Y      $��30��6$     buttony#��[ 6G   $
��Auto��6h   .��6v   Add6{   5[      5^      5_      