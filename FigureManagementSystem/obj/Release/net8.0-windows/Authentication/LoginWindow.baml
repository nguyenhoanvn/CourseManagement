   M S B A M L   `   `   `  ���� Q  MFigureManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:FigureManagementSystemFigureManagementSystem  (    "FigureManagementSystem.LoginWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:FigureManagementSystem       � Title$  FMS - Login��$	��750��$	��550�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������  � 
ResizeMode$ NoResize=� � 	Resources    
GloriaFont  NotoSans  BackgroundGradient �� 
StartPoint �� EndPoint � Color	 � Offset  LoginButtonStyle
 �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers P� Property P� Value  GoogleButtonStyle  InputTextBoxStyle ��Name �� 
TargetName  InputPasswordBoxStyle  ButtonHoverTransparent �� Triggers  LinkButtonStyle��%�	  &	        &	 D     &	 �     &	 �     7  &	 �    &	     &	 `    &	 �    &	 X    *�>:/FigureManagementSystem;component/Fonts/#Gloria Hallelujah)�*�62/FigureManagementSystem;component/Fonts/#Noto Sans)��� $	 0,0&�$	 1,1&�.��� $ #F0F8FF��$	 0Q�� $ #E6E6FA��$	 1Q��� "
 ��.���  � �� �#20B2AA��  � ��
 �������  � ��$ 0q���  � ��$
 0,12q���  � ��8   ��  � ��$ 14(���  � ��$ Medium"���  �@�Cursor$
 Hand����  � �� �� " ��.R��� #��z��$ 8��#��z��#��z��# z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#008B8BP�  � ��$
 True��. ���  � �� �#006666�� "
 ��.���  � ��
 �������  � �� �#666��  � ��$ 1q���  � �� �#DDD��  � ��$
 0,12q���  � ��$ 14(���  � ��$ Medium"���  �@�Cursor$
 Hand����  � �� �� " ��.R��� #��z��$ 8��#��z��#��z��# z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#F8F8F8�� "
 ��.���  � ��$ 12,10q���  � ��$ 14(���  � ��$ 1q���  � �� �#DDD��  � �� �� " ��.R��� $��border��
�������$ 8��#��z��#��z��._��� $ PART_ContentHost��#��z�� P�  �@J�	IsFocused$
 True��. ��� $ border�� � �� �#20B2AA�� $ border�� � ��$ 2q��� "
 G�.���  � ��$ 12,10q���  � ��$ 14(���  � ��$ 1q���  � �� �#DDD��  � �� �� " G�.R��� $��border��
�������$ 8��#��z��#��z��._��� $ PART_ContentHost��#��z�� P�  �@J�	IsFocused$
 True��. ��� $ border�� � �� �#20B2AA�� $ border�� � ��$ 2q��� "
 ��.���  � ��
 ���� ��  � ��
 ���� ��  � ��$ 0q���  �@�OverridesDefaultStyle$
 True����  � �� �� " ��.R��� $��Center=�$��Center=�$
��True�� P�  �@J�IsMouseOver$
 True��. ���  � ��
 ���� ��  � ��
 ���� P�  � ��$
 True��. ���  � ��
 ���� ��  � ��
 ���� P�  � {�$ False��. ���  � �� �#CCC�� "
 ��.���  � ��
 ���� ��  � �� �#20B2AA��  � ��$ 0q���  �@�Cursor$
 Hand����  � ��$ 13(���  � �� �� " ��.R���  P�  �@J�IsMouseOver$
 True��. ���  � �� �#008B8B��  � ��$ 	Underline{�.���� #��[ $ 16��._�� .+��� -    ��Name$ CloseButton��$	��✕��$��Right=�$	��Top=�$��	0,10,15,0q�$��30��$��30��
������ $��0q����#999$��16(� � Cursor$
 Hand���� $��Center=�$��Center=�$	��320��.+��� $��Center=�$��0,0,0,40q�.+��� $��96��$��96��$ 16��$��0,0,0,16q�._�(� $��48��$��48��.���� $��64��$��64��.+�F� 
������������ H� z � ?� z  6n���  6n��� � 6n��� 6n -1@x}��O�����^�@x}��� 6n@��@x}���� Q%� 6n l�� 6n���@x} u��� u�@�� u�@�� ���@������ ��@�� ���� ���S���S ����S u�@�q u�� � u c���� c� l��@�q Q%�� �� c�@��� ����@�q��^�� ���O c� -1 c���� c���� � c����  Zb z  Q% z 	A�  �� Left$ 20��
 �� Top$ 55��$��24��$��6��
������� J� Opacity$	 0.6Q��� $��Welcome to SaeFigure��$��24(�$
��Bold"����#333$��Center=�$��0,0,0,8q��� $��Figure Management System��$��12(����#666$��Center=��� .+��� $��0,0,0,20q�.+��� $��Email or username��$��13(�$��Medium"����#333$��0,0,0,8q��� -    ��Name$ UsernameTextBox��#��[ 
 � Tag$" Enter your email or username���� $��0,0,0,24q�.+��� $��Password��$��13(�$��Medium"����#333$��0,0,0,8q�� .+�G� -    G�Name$ PasswordBox��#��[ $y�Visible=��� -   $ PasswordTextBox��#��[ $y�	Collapsed=��� -   $ ShowPasswordButton��#��[ $
��👁��$��Right=�$��Center=�$��0,0,12,0q�
������ $��0q����#999$��16(�$
 Hand���� -   $ LoginButton��$��Log in��#��[ $��0,0,0,24q���  �� Orientation$ 
Horizontal=�$��Center=�$��0,0,0,24q�.+��� $��1��$��80�����#DDD�� $��Or��$
��12,0q�$��13(����#666�� $��1��$��80�����#DDD�� -   $ GoogleLoginButton��#��[ $��0,0,0,32q�.���� $ 
Horizontal=�.+��� $��20��$��20��$��0,0,8,0q�.+�F� ���#4285F4������+�� Ӏ+Е� ��)n� �A' �| � �  �| � � `�� ��-`�� � 6� �{� ��(\��/@0/� �t� � ��t� `Z�@�`ZS@�6�z�G!0@�+�
� �+�� 	F� ���#34A853����� �  -1Ӑl�  -1 k
�8"�0&`��0�� R� ��� 0d� @�� �~�  � �~� � w� �~� �bf gfffff+@�Y 433333&@Q�C! 433333&@Q�C! �z�G�+@���< �| ~u  -1 �  -1	F� ���#FBBC05������Y P8� � �U 0&� P�S �w� P�S @T� �P�S �0~  �U P�s �Y 0pi Q�Y H�z�G@Q�C! H�z�G@��� ��T  +n @T� S@B ���(\�%@�� ��� p=
ףp@�� рY P8� 	F� ���#EA4335����� �  �3 �>
ףp=+@ �3  �� �< PX� `�L Q i'�Q����?�D
�_ �l�  � � ~u ������< 0n �C! �\M рY p�x ��bf 0Q  w�  �3  �  �3 	�� $��Log in with Google���� $��Center=�.+��� -   $ ForgotPasswordButton��$��Forgot password?��#��[ $��0,0,0,16q��� $ 
Horizontal=�$��Center=�.+��� $��Don't have an account? ��$��13(����#666�� -	   $ RegisterButton��$��Sign up��#��[ 