   M S B A M L   `   `   `  ����L  HAttendance_system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Attendance_system.ViewAttendance_system.View  5   	   $    Attendance_system.View.Welcome   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Attendance_system.View     5   	     � Title$  Welcome��5   	   $	��800��5	   	   $
��1100��5
   	    � Icon$ /View/Attendance.png��5   	    � 
ResizeMode$ NoResize=�5   	   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/    � MappingMode$ RelativeToBoundingBox=�6>   .��5      �  � Color$ #000000��6    � Offset$	 0.0Q�6+   � 5      $ #1A0F2E��6   $	 0.5Q�6+   � 5      $ #4C0D6D��6   $	 1.0Q�6+   5      .��5      �� $��Disabled=�6   $��Disabled=�6<   .��5   
   � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5       �� $��23,0,0,0q�6   $��/View/Attendance.png��6&   $
��Fill=�6D   $	��111��6S   $��Center=�6`   $
��Left=�6{   $	��118��6�   �� 5"      $&�� Welcome to the Attendance system��6   $��Center=�5#      $��38(�5$      $��
Calisto MT)�5%      $
��Bold"�5&      $��0,10,0,0q�5'      	 J� RenderTransformOrigin$	 	0.5,0.688&�6&   $��54��6H   $	��Top=�6T   ��5(      �� 5)      
 �� 
TargetType"
 ��6   .�5+      ��  �� Property � �� �� Value
 �����67    �� Triggers 5-      P� 5.       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5/   "   ��  � �� �	#FF9539E66?   50      52      54      � 57      $��1��6   $��10,20,20,20q�6    .+�58      �� $��9q�6    �� CornerRadius$ 5��6-   $��10q�6>   ��59      �� 5:      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5;      � $ #000000��6+   $	 0.0Q�6;   � 5<      $ #1A0F2E��6+   $	 0.5Q�6;   � 5=      $ #4C0D6D��6+   $	 1.0Q�6;   5>      ._�5@      �� .+�5A      � $��1��6   $��20q�6/   $��Stretch=�6;    5B      �� 5C   "   $
��Auto �60   .+�5E      �� $��/View/manager.png��6$   $	��190��6?   $��130,0,0,-261q�6K   $
��Left=�6a   $	��190��6|   $��Bottom=�6�   �� 5F      $��/View/employee.png��6$   $	��190��6@   $��663,0,0,-261q�6L   $
��Left=�6b   $	��190��6}   $��Bottom=�6�   �� 5H      -   5        $��Manager portal��5H   8   $��53��6Q   ���#4C0D6D$��20(�6r   
�������$��
Calisto MT)�5I   8   $
��Bold"�5J   %   $��129,367,632,-367q�67   �� 5L      -   5        $��Employee portal��5L   9   $��53��5M   %   ���#4C0D6D$��20(�6F   
�������$��
Calisto MT)�5N   8   $
��Bold"�5O   %   $��663,0,111,-367q�67   $��Bottom=�6O   5R      5T      5U      5V      5W      5X      5Y      