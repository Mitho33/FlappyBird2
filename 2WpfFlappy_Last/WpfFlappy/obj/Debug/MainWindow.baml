   M S B A M L   `   `   `  ����D  @WpfFlappy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfFlappy	WpfFlappy  5   	       WpfFlappy.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfFlappy     5   	   -   5          � Title$  
MainWindow��5      $	��800��6!   $	��800��6.   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��20* �6   �� 5      $	��38* �6   �� 5      $	��35* �6   �� 5      $	��20* �6   �� 5      $
��130* �6   �� 5      $
��549* �6   .+�5   
   �� -   5         ��Name$ canvas1��5      $
��Left=�6"   $	��638��6=   $��	26,10,0,0q�6J   $	��Top=�6]   $	��514��6u   #��� ��6�   $��4��6�   $��2��6�   .+�5      �� -   5        $ groundCanvas��5      $	��105��6+   
 �� Top$	 533��68   $	��513��6I   ��5      �� 5       �� ImageSource$ 
ground.png��6!   5      �� 5      -   5         ��Name$ 
lblCounter��5       �� Left$	 576��6(   $ 22��6:   #��� ��6J   $��30��6�   $��68��6�   5      �� 5   
   -   5         ��Name$ CmbStart��5      $��Start��6#   $
��Left=�63   $��43��6N   $��	5,409,0,0q�6Z   $	��Top=�6m   $��92��6�   $��4��6�   $��1��6�   �� 5   
   -   5        $ CmbErstellen��5      $��	Erstellen��6'   $
��Left=�6;   $��40��6V   $��	5,344,0,0q�6b   $	��Top=�6u   $��92��6�   $��4��6�   $��1��6�   5      5      