   M S B A M L   `   `   `  ����  TextualRedundancy-    'TextualRedundancy.Controls.TokenControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?�6%   �� 5      $U Opack://application:,,,/TextualRedundancy;component/Styles/StylesRepository.xaml?�6%   �� 5      $V Ppack://application:,,,/TextualRedundancy;component/Styles/SolidColorBrushes.xaml?�6%   %    5      .��5      �    ApplicationBackground#��[  6   .+�5   
   �� -   5         ��Name$ GraphBorder��5      ���#A0A0A0$��0q�6<   $��8q�6P    �� Padding$ 10q�6[   ._�5      �� -   5        $ 
GridBorder��5      ���#606060$
��0.45q�6?   ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	ValueGrid��5      $��0��6r      AutoGenerateColumns .   �� AlternationCount$ 2��5         GridLinesVisibility$
 None=�5      	   CanUserAddRows	 .  
   CanUserDeleteRows
 . $��0q�5        AlternateRowStyle   RowStyle# [ 5      $��0q�5      #��[  5       $
��Auto��5!      ���#606060$
��0.65q�5"   )      HeadersVisibility$ Column=�5#      ��. $
��Auto=�5%      $
��Auto=�5&         ClipboardCopyMode$ IncludeHeader=�5'      ��5   .   �� *Tokens+ �� UpdateSourceTrigger$ PropertyChanged=�  5,      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 5-      "  6     5.      P� 5/   "    �@ 
IsSelected . . �50   &   ��  � �� �#5555556C   �� 51   &    � �� �#5555556D   52   #   54      55         Columns 57      4  .System.Windows.Controls.DataGridTemplateColumn  58      -   5        ColumnToken��,  &System.Windows.Controls.DataGridColumn   SortMemberPath$ Token��58   F      Header$ Token��6]      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 100* 6~      MinWidth$	 100Q�6�      ClipboardContentBinding 6�   �� *Token+   CellTemplate 59      �� 5:   "   .R�5;   &   �� $��Center=�6a   ���#EEEEEE$��5,0,6,0q�6�   ��60   �� *Token+ � ToolTip 6G   �� *Token+6�   5<   #   5>        5?      -   5        ColumnLength��$ Length��5?   G    . $
 Auto 6i   $ Length��6v    6�   �� *Length+ 5@      �� 5A   "   .R�5B   &   �� $��Right=�6c   $��Center=�6   
�������$��	10,0,10,0q�6�   ��60   �� *Length+ 6H   �� *Length+6�   5C   #   5E        5F      -   5        ColumnPosition��$ Position��5F   I    . $
 Auto 6m   $ Position��6z    6�   �� *
Position+ 5G      �� 5H   "   .R�5I   &   �� $��Right=�6g   $��Center=�6�   
�������$��	10,0,10,0q�6�   ��60   �� *
Position+ 6J   �� *
Position+6�   5J   #   5L        5M      -   5        ColumnImpact��$ Impact��5M   G    . $	 130 6i   $ RelativeTokenLength��6u    6�   �� *RelativeTokenLength+ 5N      �� 5O   "   .R�5P   &   �� $��Stretch=�6-   $	��180��6K   ���#555555$��1q�6m   ���#333333$��22��6�   $��0,2,10,2q�6�   ._�5Q   *   � .+�5R   .   � 
���/kU�$��20��6O   $
��Left=�6�   ��6[   �� *RelativeTokenLength+6�   �� 5S   .   
�������$
��Left=�6{   $��Center=�6�   $��2,0,0,0q�6�   $��9(�6�    J� Opacity$	 0.4Q�6�   ��68   �� *RelativeTokenLengthString+6�   5T   +   5U   '   5V   #   5X        5Y      -   5        ColumnDistribution��$ Distribution��5Y   M    . $	 130 6u   $ DistributionLength��6�    6�   �� *DistributionLength+ 5Z      �� 5[   "   .R�5\   &   �� $��Stretch=�6-   $	��180��6K   ���#555555$��1q�6m   ���#333333$��22��6�   $��0,2,10,2q�6�   ._�5]   *   � .+�5^   .   � 
�����F�$��20��6J   $
��Left=�6{   ��6V   �� *DistributionLength+6{   �� 5_   .   
�������$��2,0,0,0q�6z   $��Center=�6�   $
��Left=�6�   $��9(�6�   $	 0.4Q�6�   ��68   �� *DistributionLengthString+6�   5`   +   5a   '   5b   #   5d        5e      -	   5        ColumnCount��$ Occurrences��5e   F    . $
 Auto 6m   $ Amount��6z    6�   �� *Amount+ 5f      �� 5g   "   .R�5h   &   �� $��Center=�6c   $��Center=�6�   ���#A0A7C0$��	10,0,10,0q�6�   ��60   �� *Amount+ 6H   �� *Amount+6�   5i   #   5k      5n      5o      5p      5q      5r      