   M S B A M L   `   `   `  ����G  CFinalProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FinalProject.PropertiesFinalProject.Properties  5   	   +clr-namespace:FinalProjectFinalProject  5   	       FinalProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @Custom-http://schemas.microsoft.com/wpf/2008/toolkit     5   	   <
Properties%clr-namespace:FinalProject.Properties     5   	   ,localclr-namespace:FinalProject     5   	     � Title$  
MainWindow��5   	   $	��462��6   $
��1177��6)    � DataContext 5	      #  FinalProject.SortingViewModel  5
   
   .��5      � ���	#FF7C7C7C.+�5   
   �� -   5         ��Name$ canvas��5      $
��Left=�6'   $	��411��6B   $��
159,10,0,0q�6O   $	��Top=�6c   $
��1000��6{   
���   ���6�   �� *Lines+��5      �� 5      .R�5      �� 5      ��5      �� 5      .R�5      �� 	 �� X1 5      �� *From.X+	 �� Y1 5      �� *From.Y+	 �� X2 5      �� *To.X+	 �� Y2 5      �� *To.Y+��5      �� *Stroke+��5      �� *StrokeThickness+5      5      �� 5    
   -   5         ��Name$ btnSort��5       $
��Sort��6"   $
��Left=�61   $��
10,401,0,0q�6L   $	��Top=�6`   $��75��6x   ��6�   �� *SortCommand+ �� Mode$ OneWay=��� 5!   
   -   5        	 ��Name$	 boxAlgorithm��5!      $
��Left=�6)   $��	10,36,0,0q�6D   $	��Top=�6W   $	��120��6o   
 �� SelectedIndex$
 0��6{    �� DisplayMemberPath$ DisplayMember��6�   ��6�   �� *
Algorithms+ �� SelectedValue 6�   �� *SelectedAlgorithm+6�   �� 5"   
   -   5         ��Name$ lblAlgorithm��5"      $��	Algorithm��6&   $
��Left=�6:   $��	10,10,0,0q�6U   $	��Top=�6h   �� 5#   
   -   5        $	 boxElements��5#      $
��Left=�6(   $��	10,84,0,0q�6C   $	��Top=�6V   $	��120��6n   $
 1��6�   ��6z   �� *ElementCounts+ 6�   �� *NumElements+�� 5$   
   -   5        $ btnReset��5$      $��Reset��6#   $
��Left=�63   $��
10,376,0,0q�6N   $	��Top=�6b   $��75��6z   ��6�   �� *ResetCommand+$ OneWay=��� 5%   
   -   5        $ lblElements��5%      $��Elements��6%   $
��Left=�68   $��	10,58,0,0q�6S   $	��Top=�6f   �� 5&   
   -   5        $ lblSwaps��5&      $
��Left=�6<   $��
159,10,0,0q�6W   $	��Top=�6k   ���	#00000000
���������6"   �� *Swaps+6�   �� 5'   
   -	   5        $ lblBigO��5'      $��Information:��6!   $
��Left=�68   $��	0,111,0,0q�6S   $	��Top=�6f   �� 5(   
   -
   5        $ lblAvg��5(      $
��Left=�69   $��	0,127,0,0q�6T   $	��Top=�6g   $	��144��6   ��6    �� *BigO+6   �� 5)   
   -   5         ��Name$ lblDesc��5)      $
��Left=�6%   $��
10,153,0,0q�6@   $
��Wrap=�6T   $	��Top=�6h   $	��218��6�   $	��144��6�   ��6�   �� *Description+�� 5*   
   -   5        $ lblSelected��5*      $
��Left=�6B   $��
159,22,0,0q�6]   $	��Top=�6q   ���	#00000000
���������6%   �� *
Selected+6�   �� 5+   
   -   5        $ lblCompared��5+      $
��Left=�6B   $��
159,34,0,0q�6]   $	��Top=�6q   ���	#00000000
���������6%   �� *
Compared+6�   5,      5-      