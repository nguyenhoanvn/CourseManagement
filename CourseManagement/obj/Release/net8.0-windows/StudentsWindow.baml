   M S B A M L   `   `   `  ���� K  GCourseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CourseManagementCourseManagement  %    CourseManagement.StudentsWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:CourseManagement       � Title$  Course Student��$	��450��$	��800��.��� $��10q�.+��� .+���  �� Orientation$ 
Horizontal=�$
��Left=�.+��� $��	0,0,10,10q�	Search:�� -   $��	searchBar��$	��200��$��0,0,0,10q��� $ Vertical=�$
��Left=�
�������.+��� $ 
Horizontal=�$��10,0,0,5q�.+��� -   $��idLabel��$
��Id: ��$��80���� -   $��
idInputBox��$	��150��$��	10,0,0,10q��� -   $��idError��$��
Error here��$��20,0,0,0q�$��80��$y�	Collapsed=��� $ 
Horizontal=�$��10,0,0,5q�.+��� -   $��	rollLabel��$��Roll#: ��$��80���� -   $��rollInputBox��$	��150��$��	10,0,0,10q��� -   $��	rollError��$��
Error here��$��20,0,0,0q�$��80��$y�	Collapsed=��� $ 
Horizontal=�$��10,0,0,5q�.+��� -   $��firstNameLabel��$��First Name: ��$��80���� -	   $��firstNameInputBox��$	��150��$��	10,0,0,10q��� -
   $��firstNameError��$��
Error here��$��20,0,0,0q�$��80��$y�	Collapsed=��� $ 
Horizontal=�$��10,0,0,5q�.+��� -   $��midNameLabel��$��
Mid Name: ��$��80���� -   $��midNameInputBox��$	��150��$��	10,0,0,10q��� -   $��midNameError��$��
Error here��$��20,0,0,0q�$��80��$y�	Collapsed=��� $ 
Horizontal=�$��10,0,0,5q�.+��� -   $��lastNameLabel��$��Last Name: ��$��80���� -   $��lastNameInputBox��$	��150��$��	10,0,0,10q��� -   $��lastNameError��$��
Error here��$��20,0,0,0q�$��80��$y�	Collapsed=��� $ 
Horizontal=�.+��� -   $��	addButton��$	��Add��$��80��$��	20,0,0,10q��� -   $��
editButton��$
��Edit��$��80��$��	20,0,0,10q��� -   $��deleteButton��$��Delete��$��80��$��	10,0,0,10q��� -   $��resetButton��$��Reset��$��80��$��20,0,20, 10q�&   System.Windows.Controls.DataGrid  -   $��	dgStudent��   AutoGenerateColumns$ False��$	��162��$��0,0,0,10q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	StudentId��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	StudentId+  $ Roll#�� �� *Roll+  $ 	FirstName�� �� *	FirstName+  $ MidName�� �� *	MidName+  $ LastName�� �� *
LastName+