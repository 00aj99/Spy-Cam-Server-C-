   M S B A M L   `   `   `  ����?  ;bdnf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SpycamandmicSpycamandmic  5   	       Spycamandmic.MainWindow   5   	   U QMaterialDesignThemes.Wpf, Version=3.1.0.981, Culture=neutral, PublicKeyToken=null:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <mdix1http://materialdesigninxaml.net/winfx/xaml/themes  5      &localclr-namespace:Spycamandmic  5   	     � Title$  
MainWindow��5
   	   $��354.255��6   $��594.149��6-    � 
ResizeMode$ 	CanResize=�6=   .��5      � -   5        $��Gr��5      ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF0C2655��6    � Offset$ 0Q�61   � 5      $ 	#FF464BAC��6   $ 1Q�61   5      .+�5   
   '  !MaterialDesignThemes.Wpf.PopupBox  -   5          Name$ PopupBox��5         	StaysOpen . $��Center=�5   )   $��Center=�6F      PlacementMode$ BottomAndAlignCentres=�6a   $��
10,8,10,13q�5   *   $	��566��6>   $	��302��6J   	 J� RenderTransformOrigin$	 
0.513,0.62&�6W   $�� ��6z   $��2��6�   $y�Hidden=�6�   
   ToggleContent
 5      �� 5         PrimaryHueMidBrush#���   6      PrimaryHueMidForegroundBrush#���  5       �� Padding$ 8q�5      $	��222��6%   $��58��61   $��Center=�6=   $��Center=�6Z   ._�5      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��
73,16,65,2q�6W   $��Center=�6k   $��24��6�   $��68��6�   .+�5      �� $��Connect��6$   '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$ ChevronDown=�6(   $��5,0,0,0q�6;   5      5         PopupContent. 5"      �  � 	Resources 5#       �� 
TargetType �� BasedOn �� Property �� Value��%]   '��       7���� 5$      " ��6   8   .�5%      ��  � ��$
 10,3q�63   5&      5'       � ColumnDefinitions 5(      �� 5)      �� 5*       � RowDefinitions 5-      �� 5.      $
��Auto �6$   �� 5/      $
��Auto �6$   �� 50      $
��Auto �6$   .+�54      �� $��0��6   .��6&   $"Insert Your Ip Address to continue6J   �� 55      -   5        $��output��55      $��300px��6(   $��1��66   6F   �� 57      -   5        $
��Done��57      $��0��6(   $��2��68   $��2��6E   $��Center=�6Y     MaterialDesignFlatButton#��[ 58      6K   5:      5;      '  !MaterialDesignThemes.Wpf.Snackbar  5=   
   -   5          Name$ WelcomeMessageSnackbar��5=   O   $��Bottom=�6   $��Stretch=�61    5>      .  (MaterialDesignThemes.Wpf.SnackbarMessage �� 
TargetType �� ContentStringFormat �� ContentStringFormat ��Name��%`  '        7 �� 5?      "  6   8   .�5@      ��  � �� 5A      �� 5B      "  6.   .R�5C   "   � .+�5D   &   �� #��z��67   #��z��5E   +   # z 5F   +   #��z��5G   +   $��Center=�5H   +   $��36��5I   +   5J   '   �� 5L   &   $ PART_ActionButton��6-   $y�	Collapsed=�5M   -   5N   #   5O      5Q      5R      5S      5T      �� 5U   
   -   5        $	��mic��5U      
 � Tag$ 0��6   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 90��6$   $��66��6F   $��	0,0,10,13q�6R   $��Right=�6e   $��68��6�   $��Bottom=�6�   $y�Hidden=�6�   .��5V        -   5        $
��mice��5V      $ Record=�6&   $��37��64   $��33��6@    � LayoutTransform 5W      �� 5X       �� Angle$ 0Q�6&   5Z      5[      �� 5\   
   -   5        $	��clo��5\      $ 0��6   $ 90��6$   $��66��6F   $��	0,16,13,0q�6R   $��Right=�6e   $��68��6�   $	��Top=�6�   $y�Visible=�6�   ���	#FFDA1010.��5]        -	   5        $��s��5]      $ Shutdown=�6#   $��37��63   $��33��6?    5^      �� 5_      $ 0Q�6&   5a      5b      �� 5c   
   -
   5        $	��cam��5c      $ 0��6   $ 90��6$   $��66��6H   $��	10,0,0,13q�6T   ���	#FF3A6DB7$
��Left=�6~   $��68��6�   $��Bottom=�6�   $y�Hidden=�6�   .��5d        -   5        $	��cme��5d      $ 
CameraIris=�6'   $��37��69   $��33��6E    5e      �� 5f      $ 0Q�6&   5h      5i      �� 5j   
   -   5        $��Flash��5j      $	 off��6   $ 90��6)   $��64��6M   $��	10,0,0,84q�6Y   ���	#FFB76D3A$��Bottom=�6�   $
��Left=�6�   $��68��6�   $y�Hidden=�6�   .��5k        -   5        $��Flashm��5k   )   $ Flash=�6   $��37��67   $��33��6C    5l      �� 5m      $ 0Q�6&   5o      5p      �� 5q   
   -   5        $	��bze��5q      ���	#FF464BAC$��1q�64   $��Right=�6H   $��31��6d   $��	0,0,13,84q�6p   $��Bottom=�6�   $	��165��6�   ���	#FF673AB7 �� CornerRadius$ 16��6�   4  .System.Windows.Automation.AutomationProperties    AcceleratorKey$  z��6�   $y�Hidden=�6�   ._�5r      �� -   5        ! ��Name$! label��5r      $!��!Beta Version (only on PCM)��6#   ���	#DDFFFFFF$��6,2,6,5q�6`   5s      5t      5w      