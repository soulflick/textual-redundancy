   M S B A M L   `   `   `  ����   TextualRedundancy-    'TextualRedundancy.Controls.TokenControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources   �� MergedDictionaries �� Source��  �� $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?��� $U Opack://application:,,,/TextualRedundancy;component/Styles/StylesRepository.xaml?��� $V Ppack://application:,,,/TextualRedundancy;component/Styles/SolidColorBrushes.xaml?�%    .���    ApplicationBackground#��[  .+��� -    ��Name$ GraphBorder�����#A0A0A0$��0q�$��8q� �� Padding$ 10q�._��� -   $ 
GridBorder�����#606060$
��0.45q�._�&   System.Windows.Controls.DataGrid  -     Name$ 	ValueGrid��$��0��   AutoGenerateColumns .   �� AlternationCount$ 2��   GridLinesVisibility$
 None=�	   CanUserAddRows	 .  
   CanUserDeleteRows
 . $��0q�  AlternateRowStyle   RowStyle# [ $��0q�#��[  $
��Auto�����#606060$
��0.65q�   HeadersVisibility$ Column=���. $
��Auto=�$
��Auto=�   ClipboardCopyMode$ IncludeHeader=����� *Tokens+ �� UpdateSourceTrigger$ PropertyChanged=�  *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%r   '        �� "   P�  �@ 
IsSelected . . ���  � �� �#555555��  � �� �#555555   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  -   ColumnToken��,  &System.Windows.Controls.DataGridColumn   SortMemberPath$ Token��   Header$ Token��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 100*    MinWidth$	 100Q�   ClipboardContentBinding �� *Token+   CellTemplate �� .R��� $��Center=����#EEEEEE$��5,0,6,0q����� *Token+ � ToolTip �� *Token+  -   ColumnLength��$ Length�� . $
 Auto $ Length�� �� *Length+ �� .R��� $��Right=�$��Center=�
�������$��	10,0,10,0q����� *Length+ �� *Length+  -   ColumnPosition��$ Position�� . $
 Auto $ Position�� �� *
Position+ �� .R��� $��Right=�$��Center=�
�������$��	10,0,10,0q����� *
Position+ �� *
Position+  -   ColumnImpact��$ Impact�� . $	 130 $ RelativeTokenLength�� �� *RelativeTokenLength+ �� .R��� $��Stretch=�$	��180�����#555555$��1q����#333333$��22��$��0,2,10,2q�._�� .+�� 
���/kU�$��20��$
��Left=����� *RelativeTokenLength+�� 
�������$
��Left=�$��Center=�$��2,0,0,0q�$��9(� J� Opacity$	 0.4Q����� *RelativeTokenLengthString+  -   ColumnDistribution��$ Distribution�� . $	 130 $ DistributionLength�� �� *DistributionLength+ �� .R��� $��Stretch=�$	��180�����#555555$��1q����#333333$��22��$��0,2,10,2q�._�� .+�� 
�����F�$��20��$
��Left=����� *DistributionLength+�� 
�������$��2,0,0,0q�$��Center=�$
��Left=�$��9(�$	 0.4Q����� *DistributionLengthString+  -	   ColumnCount��$ Occurrences�� . $
 Auto $ Amount�� �� *Amount+ �� .R��� $��Center=�$��Center=����#A0A7C0$��	10,0,10,0q����� *Amount+ �� *Amount+