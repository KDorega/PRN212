   M S B A M L   `   `   `  ����  HuynhPhucTanWPF"    HuynhPhucTanWPF.BookingPopup   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Booking Reservation��5   	   $	��350��5   	   $	��450��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   ���#FAFAFA.��5
      � $��20q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $	��140 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��0��6%   $��Booking Date:��65   $��Center=�6J   $	��0,5q�6e   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpBookingDate��5   6   $��0��6   $��1��6&   $	��0,5q�6M   $��5q�6Z   �� 5!      $��1��6   $��0��6%   $��Total Price:��65   $��Center=�6I   $	��0,5q�6d   �� 5"      -   5         ��Name$ txtTotalPrice��5"   3   $��1��6   $��1��6#   $	��0,5q�6J   $��5q�6W   �� 5%      $��2��6   $��0��6%   $��Customer ID:��65   $��Center=�6I   $	��0,5q�6d   �� 5&      -   5        $ txtCustomerId��5&   3   $��2��6   $��1��6#   $	��0,5q�6J   $��5q�6W   �� 5)      $��3��6   $��0��6%   $��Booking Status (0/1):��65   $��Center=�6R   $	��0,5q�6m   �� 5*      -   5        $ txtBookingStatus��5*   3   $��3��6   $��1��6#   $	��0,5q�6M   $��5q�6Z   $��1��6f   5+      �� 5.   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�5/      �� -   5        $
��Save��5/      $��90��6$   $��5q�6/   ���#4CAF50
�������$
��Bold"�6x   �� 50      -   5        $��Cancel��50      $��90��6&   $��5q�61   ���#F44336
�������$
��Bold"�6|   51      52      53      