   M S B A M L   `   `   `  ���� L  HTextualRedundancy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TextualRedundancy.ControlsTextualRedundancy.Controls  0    *TextualRedundancy.Controls.ProgressControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:TextualRedundancy.Controls     $��0q�  � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � Topmost . $	��300��$	��600�� � 	Resources  �� MergedDictionaries �� Source   imgClose  imgMinimize  GraphicYellow  GraphicGray  GraphicGreen  GraphicBlue��  �� $K Epack://application:,,,/TextualRedundancy;component/Styles/Colors.xaml?��� $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?�%  &	        &	 M     &	 �     &	 �     &	 �     &	 �     ��GCpack://application:,,,/TextualRedundancy;component/Images/close.png����JFpack://application:,,,/TextualRedundancy;component/Images/minimize.png����#7F5500����#B0B0B0����#1D3F30����#215583��.���   ApplicationBackground#��[ .+��� ���#A0A0A0$
��0.65q�$��4q�._��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��100* ��� $
��Auto �.+��� -   ���#2A2A2A �� Padding$ 0q�._�� 	 � ColumnDefinitions	 �� $
��100* ��� $
��Auto �.+��� $��Progress Analysis��$��5q��� 
 �� Orientation$
 
Horizontal=�$��1��$��Right=�.+��� -     WindowButton#��[ $��0q����#999999$��24��$��24��.���� #��[ $
��None=�$��10��$��4��$��Bottom=�$��0,0,0,-4q��� -   #��[ $��0q����#A00303$��24��$��24��.���� #��[  $��10��$��10��� -    �Name$ TotalProgress��$��1��$��24��
��� � � J� Opacity$	 0.4Q� � Maximum �� *
FileSize+ �� UpdateSourceTrigger$ PropertyChanged=� � Value �� *NumberOfBytes+$ PropertyChanged=��� $��1��$��5,0,0,0q��� $�Total (���� ��� *TotalPercent+�� $	� %)���� $��2��$��5,0,0,0q��� $�Unique (���� ��� *PercentUnique+�� $	� %)��� -   $ UniqueProgress��$��2��$��24��$	 0.4Q�
������� �� *NumberOfTokens+$ PropertyChanged=� �� *NumberUnique+� -    �Name$ GridByteDistribution��$��3��	 �� -    ��Name$
 CDWS��$
��Auto ��� -   $ CDNEW��$
��Auto ��� -	   $ CDDUPL��$
��Auto ��� -
   $ CDREST��$
��100* �.+��� $��0��$��5,0,3,0q��� $�Whitespace (���� ��� *PercentWhitespace+$ PropertyChanged=��� $	� %)��� -   $ LengthWhiteSpace��$	 100Q�$��0��$	 100Q�#��[ $��24��$	 0.4Q��� $��1��$��5,0,3,0q��� $�New (���� ��� *
PercentNew+$ PropertyChanged=��� $	� %)��� -   $ LengthTokens��$	 100Q�$��1��$	 100Q�#��[ $��24��$	 0.4Q��� $��2��$��5,0,3,0q��� $�Duplicate (���� ��� *PercentDuplicate+$ PropertyChanged=��� $	� %)��� -   $ LengthDuplicates��$	 100Q�$��2��$	 100Q�#��[ $��24��$	 0.4Q��� -   $��5��$��Right=�$
��Stop��#��[ 
�������$	��120��$��0q����#202020�� $��4��
�������$��0,0.5,0,0.5q�$��0q�._�1   +TextualRedundancy.Controls.ActivationBitMap  -     Name$ ActivationMap��