   M S B A M L   `   `   `  ���� L  HTextualRedundancy, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TextualRedundancy.ControlsTextualRedundancy.Controls  "    TextualRedundancy.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     =controls(clr-namespace:TextualRedundancy.Controls       � Title$!  Textual Redundancy Analyzer�� � 
ResizeMode$ CanResizeWithGrip=� � AllowsTransparency . $	��750��$	��800�� � WindowStyle$
 None=�$��0q����#333333$	��210��$��13(�$��96�� � 	Resources  �� MergedDictionaries �� Source   	imgGoFile  imgClose  imgNormalize  imgMinimize  imgUnpinAll  imgTile��  �� $V Ppack://application:,,,/TextualRedundancy;component/Styles/SolidColorBrushes.xaml?��� $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?�%:  &	        &	 R     &	 �     &	     &	 [    &	 �    ��LHpack://application:,,,/TextualRedundancy;component/Images/GoFile_30x.png����PLpack://application:,,,/TextualRedundancy;component/Images/close_inverted.png����TPpack://application:,,,/TextualRedundancy;component/Images/normalize_inverted.png����SOpack://application:,,,/TextualRedundancy;component/Images/minimize_inverted.png����LHpack://application:,,,/TextualRedundancy;component/Images/ImgPin_x24.png����KGpack://application:,,,/TextualRedundancy;component/Images/tiles_x32.png��.���   ApplicationBackground#��[  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��100* �.+�� -   ����  �� 
TargetType" �	 �� Triggers	 P� 
 P� Property
 �@J�IsMouseOver P� Value . . ���  �� Property �@�Cursor �� Value$
 Hand��.+��� ���#181818$��	0,0,0,0.5q�
�����F�._��  � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��100* �.+��� $��1��$ ��Textual Redundancy Checker��$��7,0,0,0q��� $��2��$��Right=� �� Orientation$ 
Horizontal=�.+��� -     WindowButton#��[ $��0q�.���� #��[ $
��None=�$��12��$��5��$��Bottom=�$��0,0,0,-8q��� -   #��[ $��0q�.���� #��[ $��12��$��12���� -     CloseWindowButton#��[ $��0q�.���� #��[ $��12��$��12��� $��1��.+��� ���#333333$��	0,0,0,0.5q�
�����F�._��  �� $
��Auto ��� $
��100* �.+��� -    ��Name$ 	btnGoFile��$��0q����#999999 J� Opacity$	 0.8Q� � ToolTip$ Select a file to analyze������ *CmdOpenFile+.���� #��[  ���� " ��	 P� 
 �@J�IsMouseOver . . ���  �@J�Opacity$	 0.2Q���  �@�Cursor$
 Hand���� $��1��$��CharacterEllipsis=�$��	16,0,16,0q�$��13(����� *CurrentFileName+ �� *CurrentFileName+� $��2��$	��488��.+��� $	��Top=�$��32�����#222222���#404040$��0,0,0,1q��� -    ��Name$ MainTabControl�����#CCCCCC.@��� -    ��Name$ TabItemStatistics��$��
Statistics��$��Center=�
 � Tag$ 0��.��2   ,TextualRedundancy.Controls.StatisticsControl  -     Name$ StatisticsControl���� -	   $ 
TabItemMap��$��Distribution��$��Center=�$ 1��.��4   .TextualRedundancy.Controls.DistributionControl  -
     Name$ DistrubutionControl���� -   $ TabItemTokenGrid��$��Tokens��$��Center=�$ 2��.��-   'TextualRedundancy.Controls.TokenControl  -     Name$ TokenControl���� $ 
Horizontal=�$	��Top=�$��Right=�.+��� -   $ 
Horizontal=�$+ %Dock all Flyouts to the main control.��.+��� -    ��Name$ 	tbDockAll��$��	dock all ��$��Center=�$��0,8,8,0q�$��13(�$��	Underline{�
�����F��� -   $ 
Horizontal=�$, &Undock all controls to become flyouts.��.+��� -   $ tbLayoutLink��$��apply layout ��$��Center=�$��0,8,8,0q�$��13(�$��	Underline{�
�����F����� " ��	 P� 
 �@J�IsMouseOver . . ���  �@�Cursor$
 Hand��