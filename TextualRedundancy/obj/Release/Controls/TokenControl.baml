   M S B A M L   `   `   `  ���� L  HTextualRedundancy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TextualRedundancy.ControlsTextualRedundancy.Controls  -    'TextualRedundancy.Controls.TokenControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:TextualRedundancy.Controls       � 	Resources   �� MergedDictionaries �� Source��  �� $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?��� $K Epack://application:,,,/TextualRedundancy;component/Styles/Colors.xaml?�%    .���    ApplicationBackground#��[  .+��� -    ��Name$ GraphBorder�����#A0A0A0$��0q�$��8q� �� Padding$ 10q�._��� -   $ 
GridBorder�����#606060$
��0.45q�._�&   System.Windows.Controls.DataGrid  -     Name$ 	ValueGrid��$��0��   AutoGenerateColumns .   �� AlternationCount$ 2��   GridLinesVisibility$
 None=�	   CanUserAddRows	 .  
   CanUserDeleteRows
 .  $��0q�  AlternateRowStyle   RowStyle# [ $��0q�#��[  ���#606060$
��0.65q�   HeadersVisibility$ Column=����� *Tokens+ �� UpdateSourceTrigger$ PropertyChanged=�  *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� "   P�  �@ 
IsSelected . . ���  � �� �#555555��  � ��$ 0q���  � ��
 �����   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   ColumnToken��,  &System.Windows.Controls.DataGridColumn   Header$ Token��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 100*   GridCell   	CellStyle# [ 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Token+4  .System.Windows.Controls.DataGridTemplateColumn  -   ColumnLength��$ Length�� . $
 Auto    SortMemberPath$ Length��   CellTemplate �� .R��� $��Right=�$��Center=�
�������$��	10,0,10,0q����� *Length+  -   ColumnPosition��$ Position�� . $
 Auto $ Position�� �� .R��� $��Right=�$��Center=�
�������$��	10,0,10,0q����� *
Position+  -   ColumnImpact��$ Impact�� . $	 130 $ RelativeTokenLength�� �� .R��� $��Stretch=�$	��180�����#555555$��1q����#333333$��22��$��0,2,10,2q�._�� 
���/kU�$��20��$
��Left=����� *RelativeTokenLength+  -   ColumnDistribution��$ Distribution�� . $	 130 $ DistributionLength�� �� .R��� $��Stretch=�$	��180�����#555555$��1q����#333333$��22��$��0,2,10,2q�._�� 
�����F�$��20��$
��Left=����� *DistributionLength+  -	   ColumnCount��$ Occurrences�� . $
 Auto $ Amount�� �� .R��� $��Right=�$��Center=����#A0A7C0$��	10,0,10,0q����� *Amount+