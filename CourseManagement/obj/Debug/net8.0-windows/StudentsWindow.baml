   M S B A M L   `   `   `  ����K  GCourseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CourseManagementCourseManagement  5   	   %    CourseManagement.StudentsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CourseManagement     5   	     � Title$  Course Student��5   	   $	��450��6    $	��800��6-   .��5	      � $��10q�6   .+�5
   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   .+�5      �� $��	0,0,10,10q�6   	Search:68   �� 5      -   5        $��	searchBar��5      $	��200��6+   $��0,0,0,10q�67   6o   5      �� 5      $ Vertical=�6   $
��Left=�60   
�������.+�5      �� $ 
Horizontal=�6   $��10,0,0,5q�66   .+�5      �� -   5        $��idLabel��5       $
��Id: ��6/   $��80��6;   6H   �� 5      -   5        $��
idInputBox��5      $	��150��60   $��	10,0,0,10q�6<   6R   �� 5      -   5        $��idError��5       $��
Error here��6/   $��20,0,0,0q�6A   $��80��6S   $y�	Collapsed=�6^   6w   5      �� 5      $ 
Horizontal=�6   $��10,0,0,5q�66   .+�5      �� -   5        $��	rollLabel��5       $��Roll#: ��61   $��80��6@   6M   �� 5      -   5        $��rollInputBox��5      $	��150��62   $��	10,0,0,10q�6>   6S   �� 5      -   5        $��	rollError��5       $��
Error here��61   $��20,0,0,0q�6C   $��80��6U   $y�	Collapsed=�6`   6y   5      �� 5      $ 
Horizontal=�6   $��10,0,0,5q�66   .+�5      �� -   5        $��firstNameLabel��5       $��First Name: ��66   $��80��6J   6W   �� 5      -	   5        $��firstNameInputBox��5      $	��150��67   $��	10,0,0,10q�6C   6Y   �� 5      -
   5        $��firstNameError��5       $��
Error here��66   $��20,0,0,0q�6H   $��80��6Z   $y�	Collapsed=�6e   6~   5      �� 5       $ 
Horizontal=�6   $��10,0,0,5q�66   .+�5!      �� -   5        $��midNameLabel��5!       $��
Mid Name: ��64   $��80��6F   6S   �� 5"      -   5        $��midNameInputBox��5"      $	��150��65   $��	10,0,0,10q�6A   6W   �� 5#      -   5        $��midNameError��5#       $��
Error here��64   $��20,0,0,0q�6F   $��80��6X   $y�	Collapsed=�6c   6|   5$      �� 5%      $ 
Horizontal=�6   $��10,0,0,5q�66   .+�5&      �� -   5        $��lastNameLabel��5&       $��Last Name: ��65   $��80��6H   6U   �� 5'      -   5        $��lastNameInputBox��5'      $	��150��66   $��	10,0,0,10q�6B   6X   �� 5(      -   5        $��lastNameError��5(       $��
Error here��65   $��20,0,0,0q�6G   $��80��6Y   $y�	Collapsed=�6d   6}   5)      �� 5*      $ 
Horizontal=�6   .+�5+      �� -   5        $��	addButton��5+      $	��Add��6.   $��80��6<   $��	20,0,0,10q�6G   6q   �� 5,      -   5        $��
editButton��5,      $
��Edit��6/   $��80��6>   $��	20,0,0,10q�6I   6t   �� 5-      -   5        $��deleteButton��5-      $��Delete��61   $��80��6B   $��	10,0,0,10q�6M   6z   �� 5.      -   5        $��resetButton��5.      $��Reset��60   $��80��6@   $��20,0,20, 10q�6K   6y   5/      51      &   System.Windows.Controls.DataGrid  52      -   5        $��	dgStudent��52         AutoGenerateColumns$ False��6(   $	��162��6D   $��0,0,0,10q�6Q      Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ 	StudentId��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	StudentId+6\     55      $ Roll#��6)    68   �� *Roll+6S     56      $ 	FirstName��6)    6<   �� *	FirstName+6\     57      $ MidName��6)    6:   �� *	MidName+6X     58      $ LastName��6)    6;   �� *
LastName+6Z   5:      5;      5<      5=      