   M S B A M L   `   `   `  ���� \  XDynamicDataDisplay, Version=0.3.16.726, Culture=neutral, PublicKeyToken=5b7d744a7263923fk:clr-namespace:Microsoft.Research.DynamicDataDisplay.Charts,Microsoft.Research.DynamicDataDisplay.Charts  ]3clr-namespace:Microsoft.Research.DynamicDataDisplay%Microsoft.Research.DynamicDataDisplay  H    BMicrosoft.Research.DynamicDataDisplay.Charts.Shapes.DraggablePoint   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Id3:clr-namespace:Microsoft.Research.DynamicDataDisplay.Charts     Fd3core3clr-namespace:Microsoft.Research.DynamicDataDisplay       � ToolTip  �� *
Position+ �� RelativeSource �� *Self+����  �� 
TargetTypeP   JMicrosoft.Research.DynamicDataDisplay.Charts.PositionalViewportUIContainer"   �� 	Resources  	  story �� TargetProperty W� From	 W� To g� Duration g� AutoReverse	 g� RepeatBehavior��%Z   &	        �� .��W� $ Opacity�$ 1X�$	 0.1X�$ 0:0:0.4D� . $	 Forever��.��� 
 �� Property
 � |� �� Value .  �� 
 �@J�Opacity$ 1Q��� 
 �@�Cursor$ 	ScrollAll���� 
 � ��$ Center=��� 
 � ��$ Center=� �� Triggers ]�  ]� 
Conditions ��  �� Property �@J�IsMouseOver �� Value . ��  �@J�IsMouseCaptured .   N� EnterActions ��  ��Name$ 
storyboard��#��[   N� ExitActions ��  �� BeginStoryboardName$ 
storyboard��.��� $��12��$��12��.+�A� $��3��$��3��
���   �A� $��12��$��12��
������ 
���   �