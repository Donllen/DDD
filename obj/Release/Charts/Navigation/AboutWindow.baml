   M S B A M L   `   `   `  ���� \  XDynamicDataDisplay, Version=0.3.16.726, Culture=neutral, PublicKeyToken=5b7d744a7263923f]3clr-namespace:Microsoft.Research.DynamicDataDisplay%Microsoft.Research.DynamicDataDisplay  Dclr-namespace:Microsoft.Research.DynamicDataDisplay.MarkupExtensions6Microsoft.Research.DynamicDataDisplay.MarkupExtensions  I   CMicrosoft.Research.DynamicDataDisplay.Charts.Navigation.AboutWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Al3clr-namespace:Microsoft.Research.DynamicDataDisplay     RpDclr-namespace:Microsoft.Research.DynamicDataDisplay.MarkupExtensions     -   $	��400��  � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterOwner=� � ShowInTaskbar .  8   2Microsoft.Research.DynamicDataDisplay.D3IconHelper   DynamicDataDisplayIcon � Icon# Z  � SizeToContent$ Height=� � Title N   HMicrosoft.Research.DynamicDataDisplay.MarkupExtensions.ResourceExtension  *
AboutTitle+.��� .+�,� " ,� VerticalScrollBarVisibility$ Disabled=�.��/�  /� FontSize$ 14(�	 � 	Resources	 
 �� 
TargetType   nav �� Property �� Value  btn  
commandBtn��%L  &	        '�� +     &	 d     &	 �     �� "
 ��.���  � �� �	#FF00A010�� "
 ��.���  �@��BaselineAlignment$ Center=��� "
 ��.���  � ��$ 0,1,0,1q���  � ��$ 14(���  � ��$ Lucida Console)��� "
 ��.���  � ��$ 0,1,0,1q���  � ��$ 14(���  � ��$ Lucida Console)�.T�J� .*�.*��� -   ���	#FF0A00A0$��16(�$-��'http://dynamicdatadisplay.codeplex.com/?� � ToolTip   *AboutSiteUrl+.�Dynamic Data Display �� -    �Name$ r1���  *	About_1+ �� .F��� $��Shift��#���   �� -   $ r2���  *	About_2+ �� .F��� $
��Ctrl��#���   �� -   $ r3���  *	About_3+�� �� .�.��� -   $ r4��#���   �  *	About_4+ , �� -   $ r6���  *	About_6+ �� .F��� #���  $��+��9   3Microsoft.Research.DynamicDataDisplay.ChartCommands   ZoomIn#��Z ����  �� -   $ r5���  *	About_5+ �� .F��� #���  $��-��   ZoomOut#��Z ����  �� -	   $ r7���  *	About_7+�� �� -
   $ r8��#���   �  *	About_8+ �� -   $ r9���  *	About_2+ �� .F��  � ColumnDefinitions �� $��* ��� $��* ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� $��1��$��0��#���  $��16(�$	��↑��$��2q�   ScrollUp#��Z ���� �� $��0��$��1��#���  $��16(�$	��←��$��2q�   
ScrollLeft#��Z ���� �� $��1��$��1��#���  $��16(�$	��↓��$��2q�   
ScrollDown#��Z ���� �� $��2��$��1��#���  $��16(�$	��→��$��2q�   ScrollRight#��Z ����  �� -   $	 r10���  *	About_9+�� �� .F��� #���  $
��Ctrl�� �� .�+ �� -   $	 r11��#���   �  *
About_10+ �� -   $	 r14���  *
About_12+�� �� .F��� #���  $��Shift�� �� .�+ �� -   $	 r12��#���   �  *
About_10+ �� -   $	 r13���  *
About_11+�� �� .F��� #���  $
��Home��   	FitToView#��Z ����  �� -   $	 r15���  *
About_13+�� �� .F��� #���  $	��F11��   CopyScreenshot#��Z ����  �� -   $	 r16���  *
About_15+�� �� .F��� #���  $
��Ctrl��   SaveScreenshot#��Z ����  �� .�+ �� .F��� #���  $��S��#��Z ����  �� -   $	 r17���  *
About_15+J�  �� TextAlignment$ Center=�.*�.*��� -   ���	#FF0A00A0$,��&http://dynamicdatadisplay.codeplex.com?�   *AboutSireUrl+.�.��� ��  *AboutSiteUrl+