   M S B A M L   `   `   `  ���� >  :PDC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CoPFCoPF      CoPF.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:CoPF       � Title$  Project Directory Creator��$��654.666�� � 
ResizeMode$ NoResize=�$��372.667�� � WindowStartupLocation$ CenterScreen=� � Icon$ Resources/CoPF_Icon.ico�� � 	Resources    BorderGapMaskConverter  GroupBoxStyle1 �� 
TargetType �� Property �� Value �� 
TargetType	 J� SnapsToDevicePixels
 � ColumnDefinitions � RowDefinitions �� CornerRadius �� Padding J� OpacityMask `� 	Converter `� ConverterParameter �� ElementName �� Path �� RelativeSource��%�  &	        &	      7   �� �� " ��.���  � �� �#D5DFE5��  � ��$ 1q���  � �� �� " ��.R�� 	 . 
 �� $��6 ��� $
��Auto ��� $��* ��� $��6 � �� $
��Auto ��� $
��Auto ��� $��* ��� $��6 �.+��� $ 4��$��1��$��3��$��0��$��4��#��z��
������ #��z���� $��Header��$ 3,1,3,0q�$��0��$��2��$��1��._��� $��Header����. #	 z	 �� $��2��$��1��$��2��#��z��#	 z	 �� $��1��$��3��$��4��#��z��#��z��$ 3�� `� 8   $ 7��.1��� $ Header��$ ActualWidth��� $ ActualWidth� �� *Self+�� $ ActualHeight� �� *Self+����  �� ImageSource$ Resources/back.jpg��.��� .+��� #���  $��Inner Folders��$
��Left=�$	��220��$��
10,104,0,0q�$	��Top=�$	��354��$
��Bold"����	#FF383838$��2q��� -    ��Name$ tb_path��$
��Left=�$��24��$��
104,12,0,0q� �� TextWrapping$ NoWrap=�$	��C:\��$	��Top=�$	��422�� �� 
IsReadOnly . �� -    ��Name$ 	bt_browse��$��Browse��$
��Left=�$��
531,12,0,0q�$	��Top=�$��96��$��24���� $��Project name��$
��Left=�$��	19,40,0,0q�$	��Top=�$
��Bold"��� -   $ tb_projectName��$
��Left=�$��24��$��
104,42,0,0q�$ NoWrap=�$��New Project��$	��Top=�$	��226���� -    ��Name$ cb_drawings��$��drawings��$
��Left=�$��
17,149,0,0q�$	��Top=�$��15��$��68�� d� 	IsChecked$
 TrueY��� -   $ 	cb_models��$��models��$
��Left=�$��
17,169,0,0q�$	��Top=�$��15��$��59��$
 TrueY��� -   $ cb_photo��$��photo��$
��Left=�$��
17,189,0,0q�$	��Top=�$��15��$��52��$
 TrueY��� -   $ cb_proxy��$��
proxyFiles��$
��Left=�$��
17,209,0,0q�$	��Top=�$��15��$��81��$
 TrueY��� -   $ 
cb_renders��$��renders��$
��Left=�$��
17,229,0,0q�$	��Top=�$��15��$��71���� -	   $ cb_references��$��
references��$
��Left=�$��
17,249,0,0q�$	��Top=�$��15��$��75���� -
   $ cb_ideas��$��ideas��$
��Left=�$��
17,269,0,0q�$	��Top=�$��15��$��47���� -   $ 	cb_prefix��$��
use prefix��$
��Left=�$��
17,296,0,0q�$	��Top=��� -   $ 	tb_prefix��$
��Left=� �� 	MaxLength$ 3��$��23��$��
93,292,0,0q�$ NoWrap=�$��_��$	��Top=�$��38�� �� TextAlignment$ Center=��� $��Project location��$
��Left=�$��7,10,0,0q�$	��Top=�$
��Bold"��� -   $ cb_namePrefix��$��
use prefix��$
��Left=�$��
335,46,0,0q�$	��Top=��� -    ��Name$ comboPrefixList��$
��Left=�$��
415,44,0,0q�$	��Top=�$	��111���� -   $ bt_addNewPrefix��$��Add New��$
��Left=�$��
531,71,0,0q�$	��Top=�$��96��$��23���� -   $ tb_newPrefix��$
��Left=�$��23��$��
415,71,0,0q�$ NoWrap=�$	��Top=�$	��111���� -   $ bt_removePrefix��$��Remove Selected��$
��Left=�$��
531,44,0,0q�$	��Top=�$��96��$��22���� -   $ 	bt_create��$��Create��$��376,255,12,11q�$
��Bold"��� $��/��$
��Left=�$��
94,222,0,0q�$	��Top=��� -   $ cb_test��$
��test��$
��Left=�$��105,229,0,0q�$	��Top=�$
 TrueY��� -   $ tb_NewCustomFolder��$
��Left=�$��23��$��173,146,0,0q�$
 Wrap=�$	��Top=�$	��130���� -   $ bt_AddNewCustFolder��$	��Add��$
��Left=�$��308,146,0,0q�$	��Top=�$��40��$��23���� -    ��Name$ lb_CustFold��$
��Left=�$	��112��$��173,174,0,0q�$	��Top=�$	��175���� -   $ bt_RemoveCustFolder��$��Remove Selected��$
��Left=�$��174,291,0,0q�$	��Top=�$	��175���� $��Custom Folders��$
��Left=�$��173,120,0,0q�$	��Top=��� -   $ bt_about��$��About��$��376,231,12,83q��� -   $ cb_music��$��music on/off��$
��Left=�$��537,209,0,0q�$	��Top=��� -    ��Name$ warning_tbl��$
��Left=�$��376,114,0,0q�$
��Wrap=�$	��Top=�$��90��$	��261��$��Medium"�