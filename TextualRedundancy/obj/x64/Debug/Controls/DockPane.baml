   M S B A M L   `   `   `  ����L  HTextualRedundancy, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TextualRedundancy.ControlsTextualRedundancy.Controls  5   	   )    #TextualRedundancy.Controls.DockPane   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:TextualRedundancy.Controls     5   	     � 
ResizeMode$  CanResizeWithGrip=�5   	    � AllowsTransparency . ���#666666$	��0.4q�5	   	    � WindowStyle$
 None=�5   	   ���#303030 � Title$ DockPane��5   	   $	��450��6   $	��800��6'    � 	Resources 5       �� MergedDictionaries �� Source   imgClose�� 5   
    5      �� 5      $V Ppack://application:,,,/TextualRedundancy;component/Styles/SolidColorBrushes.xaml?�6%   �� 5      $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?�6%   %n   &	        ��5      PLpack://application:,,,/TextualRedundancy;component/Images/close_inverted.png��6y   5      .��5      � -   5         �Name$ ContentGrid��5        ApplicationBackground#��[ 6    $��4q�6T    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��100* �6   .+�5!   
   � -   5        ��5"      �� 5#      	 �� 
TargetType"	 �6   
 �� Triggers
 5$      P� 5%       P� Property �@J�IsMouseOver P� Value . . �5&      ��  �� Property �@�Cursor �� Value$
 Hand��67   5'      5)      .+�5+      �� ���#303030$��	0,0,0,0.5q�6*   ���#666666._�5,      �  � ColumnDefinitions 5-      �� 5.      $
��Auto �6+   �� 5/      $
��Auto �6+   �� 50      $
��100* �6+   �� 51      $
��Auto �6+   .+�54      ��   WindowButton#��[ 6   
����İ�$��Right=�55   A   $��4q�6]   $��Center=�6h   $��12��56   %   $��12��60    J� Opacity$	 0.7Q�6<   
������ 
������ ��58   %   �� *CmdUndockPane+ �� RelativeSource ��  �� AncestorType" ���59   %   �� .��5;      �� -   5         
 imgPin#��[ 5;       $��8��6A   $��8��6L   $��Center=�6V    � ToolTip$ Dock on main window��6�   ��5<      �� 5=   "   "	 ��6(   .�5>   &   ��  �@J�Opacity$	 0.7Q�6@   
 5?   &   P� 5@   *    �@J�IsMouseOver . . �5A   .   ��  �@J�Opacity$ 1Q�6H   �� 5B   .    �@�Cursor$
 Hand��6G   5C   +   5E   #   5G      5J      �� 5M      -   5         ��Name$ Title��5M       $��1��6/   $��7,0,0,0q�6?   $��14(�6P   �� 5O      -   5        $��3��5O   7   $��0q�6G   
������ 
������ $��16��5Q      $��16��6(   $��Right=�64   $��Center=�5R        CloseWindowButton#��[ 5S      $��0,-2,0,0q�5T      .��5V      �� #��[  6    $��10��6C   $��10��6N   5W      5X      5Y      5Z      �� 5\   
   -   5         ��Name$ MainTab��5\      $��1��6&    5]       �� 
TargetType��%�  '��       �� 5^      "	 ��6   .�5_      ��  � �� �#33333363   �� 5`       � ��
 �����63   �� 5a       � ��$ 6q�60   �� 5b       � ��$ 14(�61   �� 5c       � �� �#D0D0D064   �� 5d       � ��$ 1q�68   �� 5e       � ��$ 14(�61   �� 5f       � ��$ Bottom=�6:   �� 5g       � ��$ 0��6/   �� 5h       � �� 5i      �� 5j      " ��6.   5m      5o      5p      5q      5r      5s      5t      