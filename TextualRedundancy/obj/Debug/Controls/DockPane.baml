   M S B A M L   `   `   `  ����L  HTextualRedundancy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TextualRedundancy.ControlsTextualRedundancy.Controls  5   	   )    #TextualRedundancy.Controls.DockPane   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:TextualRedundancy.Controls     5   	     � 
ResizeMode$  CanResizeWithGrip=�5   	    � AllowsTransparency . ���#1E394F$
��0.55q�5	   	    � WindowStyle$
 None=�5   	    � Title$ DockPane��5   	   $	��450��6   $	��800��6'    � 	Resources 5       �� MergedDictionaries �� Source   imgClose�� 5   
    5      �� 5      $K Epack://application:,,,/TextualRedundancy;component/Styles/Styles.xaml?�6%   �� 5      $K Epack://application:,,,/TextualRedundancy;component/Styles/Colors.xaml?�6%   %e   &	        ��5      GCpack://application:,,,/TextualRedundancy;component/Images/close.png��6p   5      .��5      � -   5         �Name$ ContentGrid��5        ApplicationBackground#��[ 6     � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��100* �6   .+�5    
   � -   5        .+�5!      �� ���#181818$��	0,0,0,0.5q�6*   
�����F�._�5"      � 	 � ColumnDefinitions	 5#      �� 5$      $
��Auto �6+   �� 5%      $
��Auto �6+   �� 5&      $
��100* �6+   �� 5'      $
��Auto �6+   .+�5*      �� 
����İ�$��Right=�5+   A   $��4q�6]   $��Center=�6h   $��12��5,   %   $��12��60   
 J� Opacity$	
 0.7Q�6<   
������ 
������ ��5.   %   �� *CmdUndockPane+ �� RelativeSource ��  �� AncestorType" ���5/   %   �� .��51      �� -   5         
 imgPin#��[ 51       $��8��6A   $��8��6L   $��Center=�6V    � ToolTip$ Dock on main window��52      55      �� 58      -   5         ��Name$ Title��58       $��1��6/   $��7,0,0,0q�6?   �� 5:      -   5          WindowButton#��[ 5:   7   $��3��6]   $��0q�6m   ���#A00303$��24��6�   $��24��6�   $��Right=�6�   .��5;      �� #��[  6    $��10��6C   $��10��6N   5<      5=      5>      5?      �� 5A   
   -   5         ��Name$ MainTab��5A      $��1��6&    5B       �� 
TargetType �� Property �� Value �� 
TargetType��%�  '��       �� 5C      " ��6   .�5D      ��  � �� �#33333363   �� 5E       � ��
 �����63   �� 5F       � ��$ 6q�60   �� 5G       � ��$ 14(�61   �� 5H       � �� �#D0D0D064   �� 5I       � ��$ 1q�68   �� 5J       � ��$ 14(�61   �� 5K       � ��$ Bottom=�6:   �� 5L       � ��$ 0��6/   �� 5M       � �� 5N      �� 5O      " ��6.   5R      5T      5U      5V      5W      5X      5Y      