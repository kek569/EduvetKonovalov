   M S B A M L   `   `   `  ����J  FEduvetKonovalov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:EduvetKonovalov.PageFolder.AdminPageFolder*EduvetKonovalov.PageFolder.AdminPageFolder  5      @    :EduvetKonovalov.PageFolder.AdminPageFolder.AddProviderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jlocal8clr-namespace:EduvetKonovalov.PageFolder.AdminPageFolder     5        N� Title$/  )Добавление поставщика��5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��10 �6   �� 5      $	��200 �6   �� 5      $	��350 �6   �� 5      $��10 �6   �� 5      $��0 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��10 �6   �� 5      $��70 �6   �� 5      $��10 �6   �� 5      $��70 �6   �� 5      $��10 �6   �� 5      $��70 �6   �� 5      $��10 �6   �� 5      $��70 �6   �� 5      $��10 �6   �� 5      .+�5"   
   �� $��Наименование��6      LabelNormal#��[  5#      $��2��5$      $��2��5%      �� 5&   
   -   5         ��Name$ NameProviderTb��5&      $��2��5(      $��3��5)      ��5'      �� *NameProvider+5)      �� 5+   
   $!��Номер телефона��6   #��[  5,      $��4��5-      $��2��5.      �� 5/   
   -   5        $ NumberPhoneProviderTb��5/      $��4��51      $��3��52      ��50      �� *NumberPhoneProvider+52      �� 54   
   $#��Элктроная почта��6   #��[  55      $��6��56      $��2��57      �� 58   
   -   5        $ EmailProviderTb��58      $��6��5:      $��3��5;      ��59      �� *EmailProvider+5;      �� 5=   
   -   5         ��Name$ AddProviderBtn��5=      $+��%Добавить поставщика��5>      $��8��5?      $��3��5@      5A      �� 5B   
   -   5        $ BringExistingBtn��5B      $��Привезать сущ��5C      $��8��5D      $��2��5E      5F      �� 5H   
   -   5         ��Name$ 
ProviderCb��5H      $��5��5I      $��1��5J       �� SelectedValuePath$ 
IdProvider��5L       �� DisplayMemberPath$ 
IdProvider��5M       �� SelectedItem 5K      �� *
Provider+5M      5N      5O      