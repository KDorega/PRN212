   M S B A M L   `   `   `  ����   HuynhPhucTanWPF"    HuynhPhucTanWPF.BookingPopup   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Booking Reservation��$	��350��$	��450�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=����#FAFAFA.��� $��20q� � RowDefinitions �� $��* ��� $
��Auto �.+�� $��0�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $	��140 ��� $��* �.+��� $��0��$��0��$��Booking Date:��$��Center=�$	��0,5q�(  "System.Windows.Controls.DatePicker  -     Name$ dpBookingDate��$��0��$��1��$	��0,5q�$��5q��� $��1��$��0��$��Total Price:��$��Center=�$	��0,5q��� -    ��Name$ txtTotalPrice��$��1��$��1��$	��0,5q�$��5q��� $��2��$��0��$��Customer ID:��$��Center=�$	��0,5q��� -   $ txtCustomerId��$��2��$��1��$	��0,5q�$��5q��� $��3��$��0��$��Booking Status (0/1):��$��Center=�$	��0,5q��� -   $ txtBookingStatus��$��3��$��1��$	��0,5q�$��5q�$��1���� $��1�� �� Orientation$ 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� -   $
��Save��$��90��$��5q����#4CAF50
�������$
��Bold"��� -   $��Cancel��$��90��$��5q����#F44336
�������$
��Bold"�