   M S B A M L   `   `   `  ����L  HAttendance_system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Attendance_system.ViewAttendance_system.View  5   	   %    Attendance_system.View.Activate   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Attendance_system.View     5   	     � Icon$  /View/password.png��5   	    � Title$ Activate��5	   	   $	��800��6   $
��1100��6'    � 
ResizeMode$ NoResize=�5
   	   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/    � MappingMode$ RelativeToBoundingBox=�6>   .��5      �  � Color$ #000000��6    � Offset$	 0.0Q�6+   � 5      $ #1A0F2E��6   $	 0.5Q�6+   � 5      $ #4C0D6D��6   $	 1.0Q�6+   5      .��5      �� $��Disabled=�6   $��Disabled=�6<   .��5   
   � $��20q�6   $	��718��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $
��Left=�6   $	��109��6/   $��34,0,0,0q�6<   $��Center=�6N   $	��155��6i   $��/View/password.png��6u   �� 5       $��Activation your Account��6   $��Center=�5!      $	��Top=�5"      $��38(�5#      $��
Calisto MT)�5$      $
��Bold"�5%      $��10q�5&      ��5'      �� 5(      	 �� 
TargetType"	 ��6   .�5*      �� 
 �� Property
 � �� �� Value
 �����67    �� Triggers 5,      P� 5-       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5.   "   �� 
 � �� �	#FF9539E66?   5/      51      53      � 55      $��1��6   $��10,20,20,20q�6    .+�56      �� $��9q�6    �� CornerRadius$ 5��6-   $��10q�6>   ��57      �� 58      $ 0.5,1&�6.   $ 0.5,0&�6?   .��59      � $ #000000��6+   $	 0.0Q�6;   � 5:      $ #1A0F2E��6+   $	 0.5Q�6;   � 5;      $ #4C0D6D��6+   $	 1.0Q�6;   5<      ._�5>      �� $��0,0,0,-9q�6!   .+�5?      � $��1��6   $��20q�6/   $��Stretch=�6;    5@      �� 5A   "   $
��Auto �60   .+�5D      �� $��E-Mail address��6$   
�������$��
Calisto MT)�5F       $��20(�5G       $��38��6.   $	��234��5H       $��350,21,368,21q�6,   �� 5I      -   5         ��Name$ txtEmail��5I   &   $��34��68   ���#2A2A2A
����������	#FF71737B$��18(�5K   :   $��
Calisto MT)�5L   "   $��350,64,350,-18q�6:   �� 5O      -   5        $��	send code��5P   !   $��40��65   ���#4C0D6D$��20(�5Q   6   
�������$��
Calisto MT)�5R   4   $
��Bold"�5S   !   $��390,150,376,-110q�63   �� 5T      $��Activation code��6$   
�������$��
Calisto MT)�5V       $��20(�5W       $��35��5X       $	��302��6,   $��350,248,300,-203q�68   �� 5[      -   5        $ txtActivationCode��5[   &   $��34��6A   ���#2A2A2A
����������	#FF71737B$��18(�5^   "   $��
Calisto MT)�60   $��350,298,349,-252q�6H   �� 5`      -   5        $��Activate��5a   !   $	��127��64   $��40��5b   !   ���#4C0D6D$��20(�6B   
�������$��
Calisto MT)�5c   4   $
��Bold"�5d   !   $��794,453,0,-413q�5e   !   $
��Left=�69    J� RenderTransformOrigin$ 0.322,-0.804&�6T   �� 5f      -   5        $��Sign in��5g   !   $��40��5h   !   ���#4C0D6D$��20(�6B   
�������$��
Calisto MT)�5i   4   $
��Bold"�5j   !   $��21,453,806,-413q�5k   !   5l      5m      5n      5o      5p      5q      5r      