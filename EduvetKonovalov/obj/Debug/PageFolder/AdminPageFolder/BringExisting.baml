   M S B A M L   `   `   `  ����J  FEduvetKonovalov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:EduvetKonovalov.PageFolder.AdminPageFolder*EduvetKonovalov.PageFolder.AdminPageFolder  5      >    8EduvetKonovalov.PageFolder.AdminPageFolder.BringExisting   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jlocal8clr-namespace:EduvetKonovalov.PageFolder.AdminPageFolder     5        N� Title$3  -Привязывание поставщика��5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��10 �6   �� 5      $	��200 �6   �� 5      $	��350 �6   �� 5      $��10 �6   �� 5      $��0 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��10 �6   �� 5      $��70 �6   �� 5      $��10 �6   �� 5      $��70 �6   �� 5      $��10 �6   �� 5      $��70 �6   �� 5      $��10 �6   �� 5      $��70 �6   �� 5      $��10 �6   �� 5      $��70 �6   �� 5       $��10 �6   �� 5!      .+�5%   
   �� $��Наименование��6      LabelNormal#��[  5&      $��4��5'      $��2��5(      �� 5)   
   -   5         ��Name$ NameProviderTb��5)      $��4��5+   
   $��3��5,   
   {�.  ��5*   
   �� *Provider.NameProvider+5-      �� 5/   
   $!��Номер телефона��6   #��[  50      $��6��51      $��2��52      �� 53   
   -   5        $ NumberPhoneProviderTb��53      $��6��55   
   $��3��56   
   {�.  ��54   
   �� *Provider.NumberPhoneProvider+57      �� 59   
   $#��Элктроная почта��6   #��[  5:      $��8��5;      $��2��5<      �� 5=   
   -   5        $ EmailProviderTb��5=      $��8��5?   
   $��3��5@   
   {�.  ��5>   
   �� *Provider.EmailProvider+5A      �� 5C   
   -   5         ��Name$ AddProviderBtn��5C      $��Привезять��5D   	   $��10��5E   	   $��3��5F   	   5G   	   �� 5I   
   $��Поставщик��6   #��[  5J      $��2��5K      $��2��5L      �� 5M   
   -   5         ��Name$ 
ProviderCb��5M      $��3��5N      $��2��5O       �� SelectedValuePath$ 
IdProvider��5Q       �� DisplayMemberPath$ NameProvider��5R       �� SelectedItem 5P      �� *
Provider+5R      5S      5T      