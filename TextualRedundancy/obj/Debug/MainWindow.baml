   M S B A M L   `   `   `  ����L  HTextualRedundancy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TextualRedundancy.ControlsTextualRedundancy.Controls  5   	   "    TextualRedundancy.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =controls(clr-namespace:TextualRedundancy.Controls     5   	   -   5          � Title$!  Textual Redundancy Analyzer��5   	    � 
ResizeMode$ CanResizeWithGrip=�5	   	    � AllowsTransparency . $	��750��5   	   $	��800��5   	    � WindowStyle$
 None=�5   	   $��0q�5   	   ���#333333$	��200��5   	   $��90��5   	    � 	Resources 5       �� MergedDictionaries �� Source   	imgGoFile  imgClose  imgNormalize  imgMinimize  imgUnpinAll  imgTile�� 5   
    5      �� 5      $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?�6%   �� 5      $K Epack://application:,,,/TextualRedundancy;component/Styles/Colors.xaml?�6%   %s  &	        &	 `     &	 �     &	     &	 x    &	 �    ��5      LHpack://application:,,,/TextualRedundancy;component/Images/GoFile_30x.png��6v   ��5      GCpack://application:,,,/TextualRedundancy;component/Images/close.png��6p   ��5      KGpack://application:,,,/TextualRedundancy;component/Images/normalize.png��6x   ��5      JFpack://application:,,,/TextualRedundancy;component/Images/minimize.png��6v   ��5      LHpack://application:,,,/TextualRedundancy;component/Images/ImgPin_x24.png��6x   ��5      KGpack://application:,,,/TextualRedundancy;component/Images/tiles_x32.png��6s   5!      .��5#      �   ApplicationBackground#��[ 6    � RowDefinitions 5$   
   �� 5%      $
��Auto �6   �� 5&      $
��Auto �6   �� 5'      $
��100* �6   .+�5,   
   � -   5        .+�5-      �� ���#181818$��	0,0,0,0.5q�6*   
�����F�._�5.      �  � ColumnDefinitions 5/      �� 50      $
��Auto �6+   �� 51      $
��Auto �6+   �� 52      $
��100* �6+   .+�57      �� $��1��6    $ ��Textual Redundancy Checker��60   $��7,0,0,0q�6R   �� 59      $��2��6!   $��Right=�61   	 �� Orientation$	 
Horizontal=�6M   .+�5;      �� -   5          WindowButton#��[ 5;   8   $��0q�6^   ���#999999.��5<      �� #��[ 6$   $
��None=�6J   $��12��6Y   $��5��6d   $��Bottom=�6o   $��0,0,0,-8q�6�   5=      �� 5?      -   5        #��[ 5?   9   $��0q�6_   ���#999999.��5@      �� #��[ 6$   $��12��6K   $��12��6V   5A      �� 5C      -   5        #��[ 5C   4   $��0q�6Z   ���#A00303.��5D      �� #��[ 6$   $��12��6G   $��12��6R   5E      5F      5H      5I      5J      � 5L   
   $��1��6   .+�5M      �� ���#333333$��	0,0,0,0.5q�6*   
�����F�._�5O      �  5P      �� 5Q      $
��Auto �6+   �� 5R      $
��100* �6+   .+�5U      �� -   5        
 ��Name$
 	btnGoFile��5U      $��0q�6P   ���#999999 J� Opacity$	 0.8Q�6y   ��60   �� *CmdOpenFile+.��5V      �� #��[  6    ��5X      �� 5Y       �� 
TargetType" ��6$    �� Triggers 5Z   "   P� 5[   &    P� Property �@J�IsMouseOver P� Value . . �5\   *   ��  �� Property �@J�Opacity �� Value$	 0.2Q�6D   �� 5]   *    �@�Cursor$
 Hand��6C   5^   '   5`      5b      �� 5d      $��1��6A   $��CharacterEllipsis=�6Q   $��	16,0,16,0q�6r   ��6    �� *CurrentFileName+6r   5e      5f      5g      � 5i   
   $��2��6   .+�5j      �� $	��Top=�6   $��32��6-   ���#222222���#404040$��0,0,0,1q�6d   �� 5k      -   5         ��Name$ MainTabControl��5k      ���#CCCCCC.@�5l      �� -   5         ��Name$ TabItemStatistics��5l      $��
Statistics��65   $��Center=�6I   
 � Tag$ 0��6d   .��5m      2   ,TextualRedundancy.Controls.StatisticsControl  -	   5          Name$ StatisticsControl��5m   1   5n      �� 5o      -
   5        $ 
TabItemMap��5o      $��Distribution��6.   $��Center=�6D   $ 1��6_   .��5p      4   .TextualRedundancy.Controls.DistributionControl  -   5          Name$ DistrubutionControl��5p   3   5q      �� 5r      -   5        $ TabItemTokenGrid��5r      $��Tokens��64   $��Center=�6D   $ 2��6_   .��5s      -   'TextualRedundancy.Controls.TokenControl  -   5          Name$ TokenControl��5s   ,   5t      5u      �� 5w      -   5        $	 
Horizontal=�5w      $	��Top=�62   $��Right=�6J   .+�5y      �� -   5         ��Name$ tbLayoutLink��5y      $��apply layout ��62   $��Center=�6G   $��0,8,8,0q�6b   �� 5z      #��[ 6   $��14��6:   $��14��6F    � ToolTip$# Activate floating auto-layout��5{      $��0,8,16,0q�6D   $��Right=�6V   ��5}      �� 5~      " ��6    5      P� 5�       �@J�IsMouseOver . . �5�   "   ��  �@�Cursor$
 Hand��6;   5�      5�      5�      5�      5�      5�      