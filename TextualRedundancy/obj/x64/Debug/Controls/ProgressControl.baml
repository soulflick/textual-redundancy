   M S B A M L   `   `   `  ����L  HTextualRedundancy, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TextualRedundancy.ControlsTextualRedundancy.Controls  5      0    *TextualRedundancy.Controls.ProgressControl   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:TextualRedundancy.Controls     5      $��0q�5        � WindowStartupLocation$  CenterScreen=�5	       � 
ResizeMode$ NoResize=�5
       � WindowStyle$
 None=�5       � Topmost . $	��300��5      $	��600��6    � 	Resources 5       �� MergedDictionaries �� Source   imgClose  imgMinimize  GraphicYellow  GraphicGray  GraphicGreen  GraphicBlue�� 5   
    5      �� 5      $V Ppack://application:,,,/TextualRedundancy;component/Styles/SolidColorBrushes.xaml?�6%   �� 5      $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?�6%   %�  &	        &	 d     &	 �     &	 �     &	 	    &	 (    ��5      PLpack://application:,,,/TextualRedundancy;component/Images/close_inverted.png��6y   ��5      SOpack://application:,,,/TextualRedundancy;component/Images/minimize_inverted.png��6   ��5      #7F5500��6=   ��5      #B0B0B0��6;   ��5      #1D3F30��6<   ��5      #215583��6;   5      .��5       �   ApplicationBackground#��[ 6   .+�5!   
   �� ���#A0A0A0$
��0.65q�6'   $��4q�6>   ._�5"      �  � RowDefinitions 5#      �� 5$      $
��Auto �6$   �� 5%      $
��Auto �6$   �� 5&      $
��Auto �6$   �� 5'      $
��Auto �6$   �� 5(      $
��100* �6$   �� 5)      $
��Auto �6$   .+�5,      �� -   5        ���#2A2A2A �� Padding$ 0q�5,   .   ��5-      �� 5.      	 �� 
TargetType"	 ��6    
 �� Triggers
 5/      P� 50   "    P� Property �@J�IsMouseOver P� Value . . �51   &   ��  �� Property �@�Cursor �� Value$
 Hand��6?   52   #   54      ._�56      �  � ColumnDefinitions 57      �� 58      $
��100* �6/   �� 59      $
��Auto �6/   .+�5;      �� $��Progress Analysis��6$   $��5q�6=   �� 5<       �� Orientation$ 
Horizontal=�6%   $��1��6>   $��Right=�6O   .+�5=      �� -   5          WindowButton#��[ 5=   <   $��0q�6b   $��16��6v   $��16��6�   $��2,-2,2,0q�5>   %   .��5?   "   �� #��[ 6(   $
��None=�6N   $��10��6]   $��4��6h   $��Bottom=�6s   $��0,0,0,-4q�6�   5@      �� 5A      -   5          CloseWindowButton#��[ 5A   ?   $��0q�5B   %   $��16��69   $��16��6D   $��2,-2,2,0q�5C   %   .��5D   "   �� #��[  6(   $��10��6K   $��10��6V   5E      5F      5G      5H      � 5J      -   5         �Name$ TotalProgress��5J      $��1��6w   $��24��6�   
��� � � J� Opacity$	 0.4Q�6�    � Maximum 65   �� *
FileSize+ �� UpdateSourceTrigger$ PropertyChanged=� � Value 6�   �� *NumberOfBytes+$ PropertyChanged=�6�   �� 5K      $��1��6   $��5,0,0,0q�6)   �� 6;   $�Total (��6?   �� 6P   �6T   �� *TotalPercent+�� 6t   $	� %)��6x   6�   �� 5M      $��2��6   $��5,0,0,0q�6)   �� 6;   $�Unique (��6?   �� 6Q   �6U   �� *PercentUnique+�� 6v   $	� %)��6z   6�   � 5N      -   5        $ UniqueProgress��5N       � ToolTip$ Unique Tokens (Amount)��6~   $��2��6�   $��24��6�   $	 0.4Q�6�   
������� 66   �� *NumberOfTokens+$ PropertyChanged=� 6�   �� *NumberUnique+6�   � 5O      -   5         �Name$ GridByteDistribution��5O   $   $��3��6    5P      �� 5Q      -   5         ��Name$
 CDWS��5Q   8   $
��Auto �6+   68   �� 5R      -   5        $ CDNEW��5R   8   $
��Auto �6+   68   �� 5S      -	   5        $ CDDUPL��5S   8   $
��Auto �6+   68   �� 5T      -
   5        $ CDREST��5T   8   $
��100* �6+   68   .+�5W      �� $��0��6    $��5,0,3,0q�60   �� 6B   $�(��6F   �� 6Q   �6U   �� *PercentWhitespace+$ PropertyChanged=��� 6�   $� %) Whitespace��6�   6�   � 5X      -   5        $ LengthWhiteSpace��5X   "   $	 100Q�6<   $��0��6J   $	 100Q�6Z   $! Length of Whitespace Tokens��6f   #��[ 6�   $��24��6�   $	 0.4Q�6�   �� 5Y      $��1��6    $��5,0,3,0q�60   �� 6B   $�(��6F   �� 6Q   �6U   �� *
PercentNew+$ PropertyChanged=��� 6�   $� %) New��6�   6�   � 5Z      -   5        $ LengthTokens��5Z   "   $	 100Q�68   $��1��6F   $	 100Q�6V   $ Length of Unique Tokens��6b   #��[ 6�   $��24��6�   $	 0.4Q�6�   �� 5[      $��2��6    $��5,0,3,0q�60   �� 6B   $�(��6F   �� 6Q   �6U   �� *PercentDuplicate+$ PropertyChanged=��� 6�   $� %) Duplicate��6�   6�   � 5\      -   5        $ LengthDuplicates��5\   "   $	 100Q�6<   $��2��6J   $	 100Q�6Z   $  Length of Redundant Tokens��6f   #��[ 6�   $��24��6�   $	 0.4Q�6�   5^      �� 5`      -   5        $��5��5`      $��Right=�6&   $
��Stop��6B   #��[ 6Q   
�������$	��120��6�   $��0q�5a      ���#20202069   �� 5c      $��4��6   
�������$��0,0.5,0,0.5q�69   $��0q�6W   ._�5d      1   +TextualRedundancy.Controls.ActivationBitMap  -   5          Name$ ActivationMap��5d   -   5e      5f      5g      5h      5i      