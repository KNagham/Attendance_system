   M S B A M L   `   `   `  ����L  HAttendance_system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Attendance_system.ViewAttendance_system.View  5   	   *    $Attendance_system.View.ResetPassword   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Attendance_system.View     5   	     � Title$  Reset password��5   	   $	��800��6    $
��1200��6-    � Icon$ /View/password.png��5	   	    � 
ResizeMode$ NoResize=�5
   	   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/    � MappingMode$ RelativeToBoundingBox=�6>   .��5      �  � Color$ #000000��6    � Offset$	 0.0Q�6+   � 5      $ #1A0F2E��6   $	 0.5Q�6+   � 5      $ #4C0D6D��6   $	 1.0Q�6+   5      .��5      �� $��Disabled=�6   $��Disabled=�6<   .��5   
   � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $
��Left=�6   $	��109��6/   $��34,0,0,0q�6<   $��Center=�6N   $	��155��6i   $��/View/password.png��6u   �� 5!      $��Reset your password��6   $��Center=�5"      $	��Top=�5#      $��38(�5$      $��
Calisto MT)�5%      $
��Bold"�5&      $��10q�5'      ��5(      �� 5)      	 �� 
TargetType"	 ��6   .�5+      �� 
 �� Property
 � �� �� Value
 �����67    �� Triggers 5-      P� 5.       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5/   "   �� 
 � �� �	#FF9539E66?   50      52      54      � 57      $��1��6   $��10,20,20,20q�6    .+�58      �� $��9q�6    �� CornerRadius$ 5��6-   $��10q�6>   ��59      �� 5:      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5;      � $ #000000��6+   $	 0.0Q�6;   � 5<      $ #1A0F2E��6+   $	 0.5Q�6;   � 5=      $ #4C0D6D��6+   $	 1.0Q�6;   5>      ._�5@      �� $��	0,-29,0,0q�6!   .+�5A      � $��1��6   $��20q�6/   $��Stretch=�6;    5B      �� 5C   "   $
��Auto �60   .+�5G      �� 
�������$��
Calisto MT)�5H   $   $��18(�6<   $��52��5I   $   $	��Top=�61   $��Right=�5J   $   $��
0,10,257,0q�6A   $	��594��6U   .��5K   "   �� $
��Wrap=�6,   $��64��6@   $	��573��6L   DBEnter the verified email address for your user account and we will�� 5M   .   ><send you a verified code and then you can set a new password5O   #   5P      �� 5Q      -   5         ��Name$ txtEmail��5Q   &   ���#2A2A2A
����������	#FF71737B$��18(�5S   >   $��
Calisto MT)�5T   &   $��201,67,0,-27q�6>   $
��Left=�6T   $	��461��6o   �� 5V      -   5        $��	send code��5W   %   $��43��69   ���#4C0D6D$��20(�5X   :   
�������$��
Calisto MT)�5Y   8   $
��Bold"�5Z   %   $��0,67,72,-27q�67   $��Right=�6L   $	��177��6h   �� 5\      $B��<We have sent you a code, please enter the code to confirm it��6$   
�������$��
Calisto MT)�5^   $   $��18(�5_   $   $��35��5`   $   $��0,138,374,-90q�60   $��Right=�6G   $	��477��6c   �� 5a      -   5        $ txtResetCode��5a   &   ���#2A2A2A
����������	#FF71737B$��18(�5d   '   $��
Calisto MT)�65   $��201,178,390,-138q�6M   �� 5g      -   5        $��Confirm��5g   8   $��43��5h   %   ���#4C0D6D$��20(�6F   
�������$��
Calisto MT)�5i   8   $
��Bold"�5j   %   $��0,0,72,-138q�67   $��Bottom=�6L   $��Right=�6g   $	��177��6�   �� 5l      -   5        $
��Back��5l   5   $��43��6D   ���#4C0D6D$��20(�6e   
�������$��
Calisto MT)�5m   8   $
��Bold"�5n   %   $��14,484,913,-444q�67   �� 5p      $��New password:��6$   
�������$��
Calisto MT)�5q   $   $��20(�6<   $��35��5r   $   $��201,258,658,-210q�60   G� 5s      -   5         G�Name$ txtPassword��5s   *   ���#2A2A2A
����������	#FF71737B$��18(�5u   B   $��
Calisto MT)�5v   *   $��201,298,390,-258q�6B   �� 5x      $��Confirm password:��6$   
�������$��
Calisto MT)�5y   $   $��20(�6<   $��35��5z   $   $��201,360,591,-313q�60   G� 5{      -   5        $ txtCPassword��5{   *   ���#2A2A2A
����������	#FF71737B$��18(�5}   B   $��
Calisto MT)�5~   *   $��201,400,390,-360q�6B   �� 5�      -   5        $��Reset password��5�   >   $��43��5�   %   ���#4C0D6D$��20(�6F   
�������$��
Calisto MT)�5�   8   $
��Bold"�5�   %   $��802,0,72,-360q�67   $��Bottom=�6N   5�      5�      5�      5�      5�      5�      5�      