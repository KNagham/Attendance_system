   M S B A M L   `   `   `  ����L  HAttendance_system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Attendance_system.ViewAttendance_system.View  5   	   "    Attendance_system.View.Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Attendance_system.View     5   	     � Title$  Sign in��5   	   $	��800��5	   	   $
��1100��5
   	    � Icon$ /View/login.png��5   	    � 
ResizeMode$ NoResize=�5   	   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/    � MappingMode$ RelativeToBoundingBox=�6>   .��5      �  � Color$ #000000��6    � Offset$	 0.0Q�6+   � 5      $ #1A0F2E��6   $	 0.5Q�6+   � 5      $ #4C0D6D��6   $	 1.0Q�6+   5      .��5      �� $��Disabled=�6   $��Disabled=�6<   .��5   
   � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5!      �� $��
22,-21,0,0q�6   $��2��6(   $��/View/login.png��69   $
��Fill=�6R   $	��127��6a   $	��Top=�6n   $
��Left=�6�   $	��143��6�   �� 5#      $&�� Sign in to the Attendance system��6   $��Center=�5$      $	��Top=�5%      $��38(�5&      $��
Calisto MT)�5'      $
��Bold"�5(      $��10q�5)      ��5*      �� 5+      	 �� 
TargetType"	 ��6   .�5-      �� 
 �� Property
 � �� �� Value
 �����67    �� Triggers 5/      P� 50       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �51   "   �� 
 � �� �	#FF9539E66?   52      54      56      � 58      $��1��6   $��10,20,20,20q�6    .+�59      �� $��9q�6    �� CornerRadius$ 5��6-   $��10q�6>   ��5:      �� 5;      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5<      � $ #000000��6+   $	 0.0Q�6;   � 5=      $ #1A0F2E��6+   $	 0.5Q�6;   � 5>      $ #4C0D6D��6+   $	 1.0Q�6;   5?      ._�5A      �� .+�5B      � $��1��6   $��20q�6/   $��Stretch=�6;    5C      �� 5D   "   $
��Auto �60   .+�5G      �� $��Username or email address��6$   
�������$��
Calisto MT)�5H   7   $��20(�5I   $   $��341,98,0,-96q�62   $
��Left=�6H   $	��264��6c   �� 5J      -   5         ��Name$ txtUsername��5J   &   $	��300��6;   $��34��5K   &   ���#2A2A2A
����������	#FF71737B$��18(�5M   &   $��
Calisto MT)�64   $��347,136,0,-130q�6L   $
��Left=�6d   �� 5O      $��Password��6$   
�������$��
Calisto MT)�5P   $   $��20(�6<   $��35��5Q   $   $��347,265,491,-260q�60    J� RenderTransformOrigin$ 0.181,0.262&�6J   G� 5R      -   5         G�Name$ txtPassword��5R   *   $	��300��6?   $��34��5S   *   ���#2A2A2A
����������	#FF71737B$��18(�5U   *   $��
Calisto MT)�68   $��347,305,0,-299q�6P   $
��Left=�6h   �� 5W      -   5        $��Sign in��5W   6   $	��120��5X   %   $��40��61   ���#4C0D6D$��20(�6R   
�������$��
Calisto MT)�5Y   8   $
��Bold"�5Z   %   $��810,0,0,-482q�67   $��Bottom=�6M   $
��Left=�6h   �� 5\      -   5        $+��%New to the Attendance system? Sign Up��5\   $   $��Bottom=�6T    � Cursor$
 Hand��6o    J� 	AllowDrop$
 True��6}   $��Center=�5^   $   $��361,0,0,-343q�6H   $
��Left=�6^   $	��244��6y   ��5_   "   �� 5`   &   "	 ��6,   .�5b   *   �� 
 � ��
 �����6G    5d   *   P� 5e   .    �@J�IsMouseOver$
 True��6M   . �5f   2   �� 
 � �� �	#FF9539E66O   5g   /   5i   '   5k      �� 5l      -   5        $��Forgot password?��5l   $   $��Bottom=�5m   $   $
 Hand��6?   $
 True��5n   $   $��Center=�5o   $   $��540,0,0,-260q�6H   $
��Left=�6^   $	��107��6y   ��5p   "   �� 5q   &   "	 ��6,   .�5s   *   �� 
 � ��
 �����6G    5u   *   P� 5v   .    �@J�IsMouseOver$
 True��6M   . �5w   2   �� 
 � �� �	#FF9539E66O   5x   /   5z   '   5|      5~      5      5�      5�      5�      5�      5�      