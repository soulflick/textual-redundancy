   M S B A M L   `   `   `  ����L  HTextualRedundancy, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TextualRedundancy.ControlsTextualRedundancy.Controls  5   	   "    TextualRedundancy.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =controls(clr-namespace:TextualRedundancy.Controls     5   	     � Title$!  Textual Redundancy Analyzer��5   	    � 
ResizeMode$ CanResizeWithGrip=�5	   	    � AllowsTransparency . $	��750��5   	   $	��800��5   	    � WindowStyle$
 None=�5   	   $��0q�5   	   ���#333333$	��210��5   	   $��13(�5   	   $��96��5   	    � 	Resources 5       �� MergedDictionaries �� Source   	imgGoFile  imgClose  imgNormalize  imgMinimize  imgUnpinAll  imgTile�� 5   
    5      �� 5      $V Ppack://application:,,,/TextualRedundancy;component/Styles/SolidColorBrushes.xaml?�6%   �� 5      $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?�6%   %�  &	        &	 `     &	 �     &	 ,    &	 �    &	 �    ��5      LHpack://application:,,,/TextualRedundancy;component/Images/GoFile_30x.png��6v   ��5      PLpack://application:,,,/TextualRedundancy;component/Images/close_inverted.png��6y   ��5      TPpack://application:,,,/TextualRedundancy;component/Images/normalize_inverted.png��6�   ��5       SOpack://application:,,,/TextualRedundancy;component/Images/minimize_inverted.png��6   ��5!      LHpack://application:,,,/TextualRedundancy;component/Images/ImgPin_x24.png��6x   ��5"      KGpack://application:,,,/TextualRedundancy;component/Images/tiles_x32.png��6s   5$      .��5&      �   ApplicationBackground#��[ 6    � RowDefinitions 5'   
   �� 5(      $
��Auto �6   �� 5)      $
��Auto �6   �� 5*      $
��100* �6   .+�5/   
   � -   5        ��50      �� 51       �� 
TargetType" �6   	 �� Triggers	 52      P� 53      
 P� Property
 �@J�IsMouseOver P� Value . . �54      ��  �� Property �@�Cursor �� Value$
 Hand��67   55      57      .+�59      �� ���#181818$��	0,0,0,0.5q�6*   
�����F�._�5:      �  � ColumnDefinitions 5;      �� 5<      $
��Auto �6+   �� 5=      $
��Auto �6+   �� 5>      $
��100* �6+   .+�5C      �� $��1��6    $ ��Textual Redundancy Checker��60   $��7,0,0,0q�6R   �� 5E      $��2��6!   $��Right=�61    �� Orientation$ 
Horizontal=�6M   .+�5G      �� -   5          WindowButton#��[ 5G   8   $��0q�6^   .��5H      �� #��[ 6$   $
��None=�6J   $��12��6Y   $��5��6d   $��Bottom=�6o   $��0,0,0,-8q�6�   5I      �� 5K      -   5        #��[ 5K   9   $��0q�6_   .��5M      �� #��[ 6$   $��12��6K   $��12��6V   5N      �� 5P      -   5          CloseWindowButton#��[ 5P   4   $��0q�6_   .��5R      �� #��[ 6$   $��12��6G   $��12��6R   5S      5T      5V      5W      5X      � 5Z   
   $��1��6   .+�5[      �� ���#333333$��	0,0,0,0.5q�6*   
�����F�._�5]      �  5^      �� 5_      $
��Auto �6+   �� 5`      $
��100* �6+   .+�5c      �� -   5         ��Name$ 	btnGoFile��5c      $��0q�6P   ���#999999 J� Opacity$	 0.8Q�6y    � ToolTip$ Select a file to analyze��5d      ��5c   0   �� *CmdOpenFile+.��5e      �� #��[  6    ��5g      �� 5h      " ��6$   	 5i   "   P� 5j   &   
 �@J�IsMouseOver . . �5k   *   ��  �@J�Opacity$	 0.2Q�6D   �� 5l   *    �@�Cursor$
 Hand��6C   5m   '   5o      5q      �� 5s      $��1��6A   $��CharacterEllipsis=�6Q   $��	16,0,16,0q�6r   $��13(�6�   ��6    �� *CurrentFileName+ 6�   �� *CurrentFileName+5t      5u      5v      � 5x   
   $��2��6   $	��488��6   .+�5z      �� $	��Top=�6   $��32��6-   ���#222222���#404040$��0,0,0,1q�6d   �� 5{      -   5         ��Name$ MainTabControl��5{      ���#CCCCCC.@�5|      �� -   5         ��Name$ TabItemStatistics��5|      $��
Statistics��65   $��Center=�6I   
 � Tag$ 0��6d   .��5}      2   ,TextualRedundancy.Controls.StatisticsControl  -   5          Name$ StatisticsControl��5}   1   5~      �� 5      -	   5        $ 
TabItemMap��5      $��Distribution��6.   $��Center=�6D   $ 1��6_   .��5�      4   .TextualRedundancy.Controls.DistributionControl  -
   5          Name$ DistrubutionControl��5�   3   5�      �� 5�      -   5        $ TabItemTokenGrid��5�      $��Tokens��64   $��Center=�6D   $ 2��6_   .��5�      -   'TextualRedundancy.Controls.TokenControl  -   5          Name$ TokenControl��5�   ,   5�      5�      �� 5�      $ 
Horizontal=�6   $	��Top=�62   $��Right=�6J   .+�5�      �� -   5        $ 
Horizontal=�5�      $+ %Dock all Flyouts to the main control.��6T   .+�5�      �� -   5         ��Name$ 	tbDockAll��5�       $��	dock all ��63   $��Center=�6D   $��0,8,8,0q�6_   $��13(�6p   $��	Underline{�6~   
�����F�6�   5�      �� 5�      -   5        $ 
Horizontal=�5�      $, &Undock all controls to become flyouts.��6X   .+�5�      �� -   5        $ tbLayoutLink��5�       $��apply layout ��66   $��Center=�6K   $��0,8,8,0q�6f   $��13(�6w   $��	Underline{�6�   
�����F�6�   5�      ��5�      �� 5�      " ��6   	 5�      P� 5�      
 �@J�IsMouseOver . . �5�   "   ��  �@�Cursor$
 Hand��6;   5�      5�      5�      5�      5�      5�      