   M S B A M L   `   `   `  ����Q  MPP2023_KozlovS_ISP3120, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:PP2023_KozlovS_ISP3120.Pages.MainWindow'PP2023_KozlovS_ISP3120.Pages.MainWindow  5      6    0PP2023_KozlovS_ISP3120.Pages.MainWindow.MainPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:PP2023_KozlovS_ISP3120.Pages.MainWindow     5      -   5          N� Title$  MainPage��5	       N� 
Background
 �����.��5      � $
��1300��6   $��0 0 0 20q�6    � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��0��6   $��0��6$   $��2��5      $��20(�5      $��Center=�5      $��Center=�5      $
��Wrap=�5      ��5      �� *%#ServerRequests.CurrentUser.FullName+ �� StringFormat$+ %Добро пожаловать, {0}!���� 5!   
    �� CornerRadius$ 5��6   $��0��6"   $��1��62   $��Stretch=�5"      $��10q�6/   ���#EEEEEE._�5$      ]� $
��15 5q�6   $
��True��6&   .+�5%      �� $%��Просмотр товаров��6   $��16(�5&      $	��Top=�5'      $��0 0 0 5q�61   $��Center=�5(      ]� 5*      $	��Top=�6   $��0 0 0 5q�5+      $��30��6-   .+�5,      �� -   5        $��FilterComboBox��5,      $��Right=�5-      $	��130��5.      $��10 0 0 0q�5/      $��Center=�50      51      �� 52      -   5        $��SearchTextBox��52      $
��Left=�53      $��Center=�54      $��14(�55      56      57      �� 59       �� Orientation$ 
Horizontal=�6   $��Bottom=�5:      $��Center=�5;      $��0 5 0 0q�5<      .+�5=      �� -   5        $��AddProductButton��5=      $��Center=�5>      y�5?      �� */-ServerRequests.CurrentUser.EmployeeVisibility+.��5A      �� $��Добавить��6$   $
��10 5q�5B   $   5C      5D      �� 5E      $��Disabled=�6   $
��Auto=�5F      .��5G      �� -   5        $��ProductsItemsControl��5G   #   ��5H      �� 5I      .R�5J   "   �� $ 3��6)   $��0 0 3 3q�5L   )   ��5K   )   �� *QuantityColor+._�5M   &   ]� $��10q�60   .+�5N   *   �� $��EditProductButton��61   -   5        $��Right=�5O   1   $��Center=�5P   1   $��5 0 0 0q�5Q   1   .��5T   .   �� $ ��Редактировать��68   $
��10 5q�5U   8   5V   +   �� 5W   *   $��BuyProductButton��61   -   5        $��Right=�5X   1   $��Center=�5Y   1   $��5 0 0 0q�5Z   1   .��5]   .   �� $��Купить��68   $
��10 5q�5^   8   5_   +   �� 5`   *   .+�5a   .   �� $��16(�5b   8   $��0 0 0 5q�6F   $��SemiBold"�5c   8   $
��Wrap=�5d   8   ��5a   8   �� *Name+5d   8   �� 5e   .   $
��Wrap=�5g   8   ��5e   8   �� *PriceToString+$ Цена: {0} руб.��5g   8   �� 5h   .   $
��Wrap=�68   ��5i   2   `� 5j   6   $# Количество: {0} {1}��6C   .1�5k   :   ��  �� Path$ QuantityToString�6B   �� 5l   :   $
 Unit�6B   5m   7   5o   /   5p   +   5q   '   5r   #   5s      5u      5v      5w      5x      �� 5z   
   $ 5��6   $��1��6"   $��1��62   $��Stretch=�5{      $��10q�6/   ���#EEEEEE._�5}      ]� $
��15 5q�6   $
��True��6&   .+�5~      �� $#��Просмотр заявок��6   $��16(�5      $	��Top=�5�      $��0 0 0 5q�61   $��Center=�5�      ]� 5�      $	��Top=�6   $��0 0 0 5q�5�      $��30��6-   .+�5�      �� -   5        $��FilterOrdersComboBox��5�      $��Right=�5�      $	��130��5�      $��10 0 0 0q�5�      $��Center=�5�      5�      �� 5�      -	   5        $��SearchOrdersTextBox��5�      $
��Left=�5�      $��Center=�5�      $��14(�5�      5�      5�      �� 5�      $��Disabled=�6   $
��Auto=�5�      .��5�      �� -
   5        $��OrdersItemsControl��5�   #   ��5�      �� 5�      .R�5�   "   �� $ 3��6)   $��0 0 3 3q�5�   )   ��5�   )   �� *AcceptColor+._�5�   &   ]� $��10q�60   .+�5�   *   �� $��Right=�65   $��5 0 0 0q�5�   5   $��Center=�6F   .+�5�   .   �� $��AcceptOrderButton��65   -   5        $��Center=�5�   1   $��0 0 0 5q�5�   1   .��5�   2   �� $��Принять��6<   $
��10 5q�5�   8   5�   /   �� 5�   .   $��DeclineOrderButton��65   -   5        $��Center=�5�   1   .��5�   2   �� $��Отклонить��6<   $
��10 5q�5�   8   5�   /   5�   +   �� 5�   *   .+�5�   .   �� $��16(�5�   8   $��0 0 0 5q�6F   $��SemiBold"�5�   8   $
��Wrap=�5�   8   ��5�   8   �� *ProductName+5�   8   �� 5�   .   $
��Wrap=�5�   8   ��5�   8   �� *BuyerFullName+$$ ФИО заказчика: {0}��5�   8   �� 5�   .   $
��Wrap=�5�   8   $��0 0 0 3q�6L   ��5�   8   �� *BuyerPhoneNumber+$( "Номер заказчика: {0}��5�   L   �� 5�   .   $
��Wrap=�5�   8   ��5�   8   �� *PriceToString+$ Цена: {0} руб.��5�   8   �� 5�   .   $
��Wrap=�68   $��0 0 0 3q�6L   ��5�   2   `� 5�   6   $# Количество: {0} {1}��6C   .1�5�   :   �� $ QuantityToString�6B   �� 5�   :   $ ProductUnit�6B   5�   7   5�   /   �� 5�   .   $
��Wrap=�5�   8   ��5�   8   �� *DateToString+$$ Дата создания: {0}��5�   8   �� 5�   .   $
��Wrap=�5�   8   ��5�   8   �� *AcceptStatus+$$ Статус заявки: {0}��5�   8   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      