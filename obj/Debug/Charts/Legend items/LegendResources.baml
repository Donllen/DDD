   M S B A M L   `   `   `  ����\  XDynamicDataDisplay, Version=0.3.16.726, Culture=neutral, PublicKeyToken=5b7d744a7263923fk:clr-namespace:Microsoft.Research.DynamicDataDisplay.Charts,Microsoft.Research.DynamicDataDisplay.Charts  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<    6Microsoft.Research.DynamicDataDisplay.Charts.NewLegend  �� 
TargetType �� BasedOn �� Property �� Value �� 
TargetType �� RadiusX �� RadiusYV  PMicrosoft.Research.DynamicDataDisplay.Charts.LegendTopButtonToIsEnabledConverter   legendTopButtonConverterW  QMicrosoft.Research.DynamicDataDisplay.Charts.LegendBottomButtonIsEnabledConverter  legendBottomButtonConverter  NoScrollLegendStyle � RowDefinitions �� LineUpCommand	 �� ElementName
 �� 	Converter �� LineDownCommand `� 	Converter �� Path@   :Microsoft.Research.DynamicDataDisplay.Charts.NewLegendItem �� Orientation � ToolTip    VisualContent�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      Dlocal:clr-namespace:Microsoft.Research.DynamicDataDisplay.Charts  5      %�  '         7��&	  U    &	 h    &	 {    7  7   7  '  �    �� 5      "    6	   8   .�5
      ��  � ��$ 10,10,10,10q�6   �� 5       � ��$
 Left=�6*   �� 5       � ��$	 Top=�6(   �� 5       �@K�ZIndex$ 10��6#   �� 5       � ��
 �����6!   �� 5       � ��
 �����6"   �� 5+       � �� 5,      �� 5-      "   6   .R�5.      � .+�5/      �� $��backRect��6   #��z��6"   #��z��6F   $ 10��50      $ 10��51      $��1��52      �� 53      ��. $
��Auto=�6-   $��Disabled=�6P   $��5q�54      .��55   	   �� 56   	   57      58      5:      5;        5=      6-     5>      6.   �� 5A      "    6	   8   .�5B      ��  � �� 5C      �� 5D      "   6   .R�5E      � .+�5F      �� $��backRect��6   #��z��6"   #��z��6F   $ 10��5G      $ 10��5H      $��1��5I      � 5J       5K   	   �� 5L   
   $
��Auto �6   �� 5M   
   $��* �6   �� 5N   
   $
��Auto �6   .+�5Q   	   �� $��^��6   $��0��6"   #��Z 6/   $��18��5R      $��Center=�6   $��0q�6;   ��5Q   \   �� $	 scroll��{�5S      �� *VerticalOffset+$	 scroll��8
  �� 5U   	   $��scroll��6   $��1��6%   ��. $��Hidden=�5V   %   $��Disabled=�6J   $��5q�5W      .��5X   
   �� 5Y   
   �� 5Z   	   $��v��6   $��2��6"   #��Z 6/   $��18��5[      $��Center=�6   $��0q�6;   ��5Z   ^   �� $	 scroll��{�5\   
   `� 5]      8  .1�5^      �� $ ExtentHeight�6   $	 scroll��6(   �� 5_      $ ViewportHeight�6   $	 scroll��6*   �� 5`      $ VerticalOffset�6   $	 scroll��6*   5a      5c   
   5d   	   5e      5f      5h      5i      �� 5l      "   6	   .�5m      ��  � �� 5n      �� 5o      "  6   .R�5p      �� $ 
Horizontal=�6    5q      �� 5r   	   $+ %(local:NewLegend.DetailedDescription)�6   .+�5u      �� #��z 6   $��2q�6Q   $��Center=�6\   �� 5v      $��2q�6   $��Center=�6"   ��5w   	   �� 5x   
   $# (local:NewLegend.Description)�6   5z   	   5{      5|      5~      5      5�      