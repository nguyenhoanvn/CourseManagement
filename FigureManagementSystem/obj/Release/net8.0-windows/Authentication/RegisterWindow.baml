   M S B A M L   `   `   `  ����   FigureManagementSystem+    %FigureManagementSystem.RegisterWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Register��$	��725��$	��900�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�
������  � AllowsTransparency$
 True�� � 	Resources    
GloriaFont  NotoSans  BackgroundGradient �� 
StartPoint �� EndPoint � Color	 � Offset  SignupButtonStyle
 �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers P� Property P� Value  InputTextBoxStyle ��Name ��Name �� 
TargetName  InputPasswordBoxStyle  ButtonHoverTransparent �� Triggers  LinkButtonStyle��%�  &	        &	 D     &	 �     &	 �     7  &	 �    &	 �    &	 �    &	 �    *�>:/FigureManagementSystem;component/Fonts/#Gloria Hallelujah)�*�62/FigureManagementSystem;component/Fonts/#Noto Sans)��� $	 0,0&�$	 1,1&�.��� $ #F0F8FF��$	 0Q�� $ #E6E6FA��$	 1Q��� "
 ��.���  � �� �#20B2AA��  � ��
 �������  � ��$ 0q���  � ��$ 12q���  � ��8   ��  � ��$ 14(���  � ��$ Medium"���  �@�Cursor$
 Hand����  � �� �� " ��.R��� #��z��$ 8��#��z��#��z��# z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#008B8BP�  � ��$
 True��. ���  � �� �#006666�� "
 ��.���  � ��$ 5q���  � ��$ 12(���  � ��$ 1q���  � �� �#DDD��  � ��
 �������  �@J�SnapsToDevicePixels$
 True����  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$ 8��._��� $ PART_ContentHost��#��z��$|�False�� P�  � {�$ False��. ��� $ border�� � �� �	#FFF0F0F0�� $ border�� � �� �	#FFD9D9D9P�  �@J�	IsFocused$
 True��. ��� $ border�� � �� �#20B2AA�� $ border�� � ��$ 2q��� "
 G�.���  � ��$ 5q���  � ��$ 12(���  � ��$ 1q���  � �� �#DDD��  � �� �� " G�.R��� $��border��
�������$ 8��#��z��#��z��._��� $ PART_ContentHost��#��z�� P�  �@J�	IsFocused$
 True��. ��� $ border�� � �� �#20B2AA�� $ border�� � ��$ 2q��� "
 ��.���  � ��
 ���� ��  � ��
 ���� ��  � ��$ 0q���  �@�OverridesDefaultStyle$
 True����  � �� �� " ��.R��� $��Center=�$��Center=�$
��True�� P�  �@J�IsMouseOver$
 True��. ���  � ��
 ���� ��  � ��
 ���� P�  � ��$
 True��. ���  � ��
 ���� ��  � ��
 ���� P�  � {�$ False��. ���  � �� �#CCC�� "
 ��.���  � ��
 ���� ��  � �� �#20B2AA��  � ��$ 0q���  �@�Cursor$
 Hand����  � ��$ 13(���  � �� �� " ��.R���  P�  �@J�IsMouseOver$
 True��. ���  � �� �#008B8B��  � ��$ 	Underline{�.���� $ 14��
�������._��  � ColumnDefinitions �� $��2* ��� $��3* �.+��� $��0�����#18305B$ 	14,0,0,14��._��� $8��2/mnt/data/ba5e5e00-e88b-49e4-92f1-80127e655112.png��$��UniformToFill=� J� Opacity$	 0.8Q�� $��1�� � RowDefinitions �� $��* ��� $
��Auto ��� $��* �.+��� -    ��Name$ CloseButton��$	��✕��$��Right=�$	��Top=�$��0,0,10,0q�$��30��$��30��
������ $��0q����#999$��16(� � Cursor$
 Hand��$|�False��#��[ �� $��1��$��Center=�$��Center=�$	��360��.+��� $��Sign up��$
��Bold"�$��20(����#222$��0,0,0,10q��� $��First name *��$��SemiBold"�$��0,0,0,6q�$��13(��� -    ��Name$ FirstNameTextBox��$��0,0,0,16q�#��[ 
 � Tag$ Enter your first name���� -    ��Name$ FirstNameError��$��10(�$��
10,-10,0,0q�
���  ���� $��Last name *��$��SemiBold"�$��0,0,0,6q�$��13(��� -   $ LastNameTextBox��$��0,0,0,16q�#��[ �� -   $ LastNameError��$��10(�$��
10,-10,0,0q�
���  ���� $��
Username *��$��SemiBold"�$��0,0,0,6q�$��13(��� -   $ UsernameTextBox��$��0,0,0,16q�#��[ �� -   $ UsernameError��$��10(�$��
10,-10,0,0q�
���  ���� $��
Password *��$��SemiBold"�$��0,0,0,6q�$��13(�G� -    G�Name$ PasswordBox��$��0,0,0,16q�#��[ �� -	   $ PasswordError��$��10(�$��
10,-10,0,0q�
���  ���� $��Email��$��SemiBold"�$��0,0,0,6q�$��13(��� -
   $ EmailTextBox��$��0,0,0,16q�#��[ �� -   $ 
EmailError��$��10(�$��
10,-10,0,0q�
���  ���� $��Address��$��SemiBold"�$��0,0,0,6q�$��13(��� -   $ AddressTextBox��$��0,0,0,16q�#��[ �� -   $ AddressError��$��10(�$��
10,-10,0,0q�
���  ���� $��Phone *��$��SemiBold"�$��0,0,0,6q�$��13(��� -   $ PhoneTextBox��$��0,0,0,20q�#��[ �� -   $ 
PhoneError��$��10(�$��
10,-10,0,0q�
���  ���� -   $ RegisterButton��$��Sign up��$
��Bold"�$��15(�#��[ $��0,14,0,0q�