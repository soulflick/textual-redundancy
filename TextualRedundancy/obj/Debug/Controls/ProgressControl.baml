   M S B A M L   `   `   `  ����L  HTextualRedundancy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TextualRedundancy.ControlsTextualRedundancy.Controls  5      0    *TextualRedundancy.Controls.ProgressControl   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:TextualRedundancy.Controls     5      $��0q�5        � WindowStartupLocation$  CenterScreen=�5	       � 
ResizeMode$ NoResize=�5
       � WindowStyle$
 None=�5       � Topmost . $	��300��5      $	��600��6    � 	Resources 5       �� MergedDictionaries �� Source   imgClose  imgMinimize  GraphicYellow  GraphicGray  GraphicGreen  GraphicBlue�� 5   
    5      �� 5      $K Epack://application:,,,/TextualRedundancy;component/Styles/Colors.xaml?�6%   �� 5      $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?�6%   %q  &	        &	 [     &	 �     &	 �     &	 �     &	     ��5      GCpack://application:,,,/TextualRedundancy;component/Images/close.png��6p   ��5      JFpack://application:,,,/TextualRedundancy;component/Images/minimize.png��6v   ��5      #7F5500��6=   ��5      #B0B0B0��6;   ��5      #1D3F30��6<   ��5      #215583��6;   5      .��5       �   ApplicationBackground#��[ 6   .+�5!   
   �� ���#A0A0A0$
��0.65q�6'   $��4q�6>   ._�5"      �  � RowDefinitions 5#      �� 5$      $
��Auto �6$   �� 5%      $
��Auto �6$   �� 5&      $
��Auto �6$   �� 5'      $
��Auto �6$   �� 5(      $
��100* �6$   �� 5)      $
��Auto �6$   .+�5,      �� -   5        ���#2A2A2A �� Padding$ 0q�5,   .   ._�5-      � 	 � ColumnDefinitions	 5.      �� 5/      $
��100* �6/   �� 50      $
��Auto �6/   .+�52      �� $��Progress Analysis��6$   $��5q�6=   �� 53      
 �� Orientation$
 
Horizontal=�6%   $��1��6>   $��Right=�6O   .+�54      �� -   5          WindowButton#��[ 54   <   $��0q�6b   ���#999999$��24��6�   $��24��6�   .��55   "   �� #��[ 6(   $
��None=�6N   $��10��6]   $��4��6h   $��Bottom=�6s   $��0,0,0,-4q�6�   56      �� 57      -   5        #��[ 57   ?   $��0q�6e   ���#A00303$��24��6�   $��24��6�   .��58   "   �� #��[  6(   $��10��6K   $��10��6V   59      5:      5;      5<      � 5>      -   5         �Name$ TotalProgress��5>      $��1��6w   $��24��6�   
��� � � J� Opacity$	 0.4Q�6�    � Maximum 65   �� *
FileSize+ �� UpdateSourceTrigger$ PropertyChanged=� � Value 6�   �� *NumberOfBytes+$ PropertyChanged=�6�   �� 5?      $��1��6   $��5,0,0,0q�6)   �� 6;   $�Total (��6?   �� 6P   �6T   �� *TotalPercent+�� 6t   $	� %)��6x   6�   �� 5A      $��2��6   $��5,0,0,0q�6)   �� 6;   $�Unique (��6?   �� 6Q   �6U   �� *PercentUnique+�� 6v   $	� %)��6z   6�   � 5B      -   5        $ UniqueProgress��5B      $��2��6~   $��24��6�   $	 0.4Q�6�   
������� 66   �� *NumberOfTokens+$ PropertyChanged=� 6�   �� *NumberUnique+6�   � 5C      -   5         �Name$ GridByteDistribution��5C   $   $��3��6   	 5D      �� 5E      -   5         ��Name$
 CDWS��5E   8   $
��Auto �6+   68   �� 5F      -   5        $ CDNEW��5F   8   $
��Auto �6+   68   �� 5G      -	   5        $ CDDUPL��5G   8   $
��Auto �6+   68   �� 5H      -
   5        $ CDREST��5H   8   $
��100* �6+   68   .+�5K      �� $��0��6    $��5,0,3,0q�60   �� 6B   $�Whitespace (��6F   �� 6\   �6`   �� *PercentWhitespace+$ PropertyChanged=��� 6�   $	� %)��6�   6�   � 5L      -   5        $ LengthWhiteSpace��5L   "   $	 100Q�6<   $��0��6J   $	 100Q�6Z   #��[ 6f   $��24��6�   $	 0.4Q�6�   �� 5M      $��1��6    $��5,0,3,0q�60   �� 6B   $�New (��6F   �� 6U   �6Y   �� *
PercentNew+$ PropertyChanged=��� 6�   $	� %)��6�   6�   � 5N      -   5        $ LengthTokens��5N   "   $	 100Q�68   $��1��6F   $	 100Q�6V   #��[ 6b   $��24��6�   $	 0.4Q�6�   �� 5O      $��2��6    $��5,0,3,0q�60   �� 6B   $�Duplicate (��6F   �� 6[   �6_   �� *PercentDuplicate+$ PropertyChanged=��� 6�   $	� %)��6�   6�   � 5P      -   5        $ LengthDuplicates��5P   "   $	 100Q�6<   $��2��6J   $	 100Q�6Z   #��[ 6f   $��24��6�   $	 0.4Q�6�   5R      �� 5T      -   5        $��5��5T      $��Right=�6&   $
��Stop��6B   #��[ 6Q   
�������$	��120��6�   $��0q�5U      ���#20202069   �� 5W      $��4��6   
�������$��0,0.5,0,0.5q�69   $��0q�6W   ._�5X      1   +TextualRedundancy.Controls.ActivationBitMap  -   5          Name$ ActivationMap��5X   -   5Y      5Z      5[      5\      5]      