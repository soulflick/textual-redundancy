   M S B A M L   `   `   `  ���� L  HTextualRedundancy, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TextualRedundancy.ControlsTextualRedundancy.Controls  )    #TextualRedundancy.Controls.DockPane   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:TextualRedundancy.Controls       � 
ResizeMode$  CanResizeWithGrip=� � AllowsTransparency . ���#666666$	��0.4q� � WindowStyle$
 None=����#303030 � Title$ DockPane��$	��450��$	��800�� � 	Resources  �� MergedDictionaries �� Source   imgClose��  �� $V Ppack://application:,,,/TextualRedundancy;component/Styles/SolidColorBrushes.xaml?��� $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?�%`   &	        ��PLpack://application:,,,/TextualRedundancy;component/Images/close_inverted.png��.��� -    �Name$ ContentGrid��  ApplicationBackground#��[ $��4q� � RowDefinitions �� $
��Auto ��� $
��100* �.+�� -   ���� 	 �� 
TargetType"	 �
 �� Triggers
 P�  P� Property �@J�IsMouseOver P� Value . . ���  �� Property �@�Cursor �� Value$
 Hand��.+��� ���#303030$��	0,0,0,0.5q����#666666._��  � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��100* ��� $
��Auto �.+���   WindowButton#��[ 
����İ�$��Right=�$��4q�$��Center=�$��12��$��12�� J� Opacity$	 0.7Q�
������ 
������ ���� *CmdUndockPane+ �� RelativeSource ��  �� AncestorType" ����� .���� -    
 imgPin#��[ $��8��$��8��$��Center=� � ToolTip$ Dock on main window������ "	 ��.���  �@J�Opacity$	 0.7Q�
 P�  �@J�IsMouseOver . . ���  �@J�Opacity$ 1Q���  �@�Cursor$
 Hand���� -    ��Name$ Title��$��1��$��7,0,0,0q�$��14(��� -   $��3��$��0q�
������ 
������ $��16��$��16��$��Right=�$��Center=�  CloseWindowButton#��[ $��0,-2,0,0q�.���� #��[  $��10��$��10���� -    ��Name$ MainTab��$��1��  �� 
TargetType��%  '��       �� "	 ��.���  � �� �#333333��  � ��
 �������  � ��$ 6q���  � ��$ 14(���  � �� �#D0D0D0��  � ��$ 1q���  � ��$ 14(���  � ��$ Bottom=���  � ��$ 0����  � �� �� " ��