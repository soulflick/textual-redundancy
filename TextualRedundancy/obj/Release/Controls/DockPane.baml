   M S B A M L   `   `   `  ���� L  HTextualRedundancy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TextualRedundancy.ControlsTextualRedundancy.Controls  )    #TextualRedundancy.Controls.DockPane   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:TextualRedundancy.Controls       � 
ResizeMode$  CanResizeWithGrip=� � AllowsTransparency . ���#1E394F$
��0.55q� � WindowStyle$
 None=� � Title$ DockPane��$	��450��$	��800�� � 	Resources  �� MergedDictionaries �� Source   imgClose��  �� $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?��� $K Epack://application:,,,/TextualRedundancy;component/Styles/Colors.xaml?�%W   &	        ��GCpack://application:,,,/TextualRedundancy;component/Images/close.png��.��� -    �Name$ ContentGrid��  ApplicationBackground#��[  � RowDefinitions �� $
��Auto ��� $
��100* �.+�� -   .+��� ���#181818$��	0,0,0,0.5q�
�����F�._�� 	 � ColumnDefinitions	 �� $
��Auto ��� $
��Auto ��� $
��100* ��� $
��Auto �.+��� 
����İ�$��Right=�$��4q�$��Center=�$��12��$��12��
 J� Opacity$	
 0.7Q�
������ 
������ ���� *CmdUndockPane+ �� RelativeSource ��  �� AncestorType" ����� .���� -    
 imgPin#��[ $��8��$��8��$��Center=� � ToolTip$ Dock on main window���� -    ��Name$ Title��$��1��$��7,0,0,0q��� -     WindowButton#��[ $��3��$��0q����#A00303$��24��$��24��$��Right=�.���� #��[  $��10��$��10���� -    ��Name$ MainTab��$��1��  �� 
TargetType �� Property �� Value �� 
TargetType��%  '��       �� " ��.���  � �� �#333333��  � ��
 �������  � ��$ 6q���  � ��$ 14(���  � �� �#D0D0D0��  � ��$ 1q���  � ��$ 14(���  � ��$ Bottom=���  � ��$ 0����  � �� �� " ��