   M S B A M L   `   `   `  ����  DressUp_1._1    DressUp_1._1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   W SHelixToolkit.Wpf, Version=2.6.1.0, Culture=neutral, PublicKeyToken=52aa3500039caf0d$hhttp://helix-toolkit.org/wpf  5   	   -   5          � Title$  DressUp��5   	   $
��1080��6   $
��1920��6'   .��5      � .+�5	   
   �� -   5        $��camera��5	      �� 5
   
   -   5        $��canvas��5
      � 5   
      GridButtonsStyle#��[  6   .+�5      ��   StackPanelButtonsStyle#��[ 6   .+�5      �� -   5        $��Color��5        ButtonStyle#��[ 6)   6N   �� 5      -   5        $��Depth��5      #��[ 6)   6N   �� 5      -   5        $��Infrared��5      #��[ 6,   6Q   �� 5      -   5        $
��Body��5      #��[ 6(   6M   �� 5      -   5        $��
Collection��5      #��[ 6.   6S   �� 5      -	   5         ��Name$ dressbtn��5      $��Dress��6+   $��97��6;   $��28��6_   
����������	#FF6B3F3F$y�Hidden=�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5      �  � Color$ Black��6+    � Offset$ 0Q�69   � 5      $ 	#FFEBFF53��6+   $ 1Q�6=   5      5      5      5      �� 5   
   -
   5         ��Name$ shirt��5      $
��Left=�6$   $	��566��6?   $��	51,50,0,0q�6L   $	��Top=�6_   $	��536��6w   ��5       �� 5!      5#      � 5$   
   $��0q�6   .+�5%      &   HelixToolkit.Wpf.HelixViewport3D  -   5          Name$ 	helixPort��5%   8   $��10,10,9.6,66.4q�6       Children. 5&      $  HelixToolkit.Wpf.DefaultLights    HelixToolkit.Wpf.Teapot  5'      -   5        tea��$  HelixToolkit.Wpf.MeshElement3D	   Visible	 .  5'   (   5(      � 5*      -   5        
 �Name$
 CollectionShirts��5*      $
��Left=�6-   $	��174��6H   $��	0,570,0,0q�6U   $	��Top=�6h   $
��1904��6�   $y�Hidden=�6�   ��5+      �� 5,      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5-      � $ White��6'   $ 0Q�65   � 5.      $ 	#99001FFF��6'   $ 1Q�69   5/      .+�52      �� #��[ 6    �� Orientation$ 
Horizontal=�6M   $��Center=�6f   .+�53      �� -   5        $ shirt1��53      $�� ��6-   $
��Left=�68   $��0,0,20,0q�6S   $	��Top=�6e   $	��100��6}   $	��170��6�   6�   �� 54      -   5        $ shirt2��54      $
��Left=�6.   $��0,0,20,0q�6I   $	��Top=�6[   $	��100��6s   $	��170��6   6�   �� 55      -   5        $ shirt3��55      $
��Left=�6-   $��0,0,20,0q�6H   $	��Top=�6Z   $	��100��6r   $	��170��6~   6�   �� 56      -   5        $ shirt4��56      $
��Left=�6.   $��0,0,20,0q�6I   $	��Top=�6[   $	��100��6s   $	��170��6   6�   �� 57      -   5        $ right��57      $
��Left=�6.   $��0,0,0,0q�6I   $	��Top=�6Z   $	��100��6r   $	��170��6~   ��58      �� 59      -   5        	arrow��59   )   5;      5<      5>      5@      5A      5B      