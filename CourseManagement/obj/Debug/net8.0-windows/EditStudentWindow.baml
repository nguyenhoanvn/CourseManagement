   M S B A M L   `   `   `  ����K  GCourseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CourseManagementCourseManagement  5   	   (    "CourseManagement.EditStudentWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CourseManagement     5   	     � Title$  Edit Student��5   	   $	��650��6   $	��600��6+    � WindowStartupLocation$ CenterOwner=�5	   	    � 
ResizeMode$ NoResize=�5
   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Edit Student Information��6!   $��18(�5      $
��Bold"�6"   $��Center=�5      $��0,0,0,20q�5      �� 5!   
   $��1��6   $��Student Information��6    $��0,0,0,15q�6=   .��5"      �� $��10q�6   .+�5$      ��  �� Orientation$ 
Horizontal=�6   $	��0,5q�66   .+�5%      �� $��Student ID:��6    $	��100��63   $��Center=�6?   �� 5&      -   5        $��txtStudentId��5&      $	��250��62    �� 
IsReadOnly$
 True��6>   
�������$��10,0,0,0q�5'   5   5(      �� 5+      $ 
Horizontal=�6   $	��0,5q�66   .+�5,      �� $��Roll Number:��6    $	��100��64   $��Center=�6@   �� 5-      -   5        $��txtRoll��5-      $	��250��6-   $��10,0,0,0q�69   5.      �� 51      $ 
Horizontal=�6   $	��0,5q�66   .+�52      �� $��First Name:��6    $	��100��63   $��Center=�6?   �� 53      -   5        $��txtFirstName��53      $	��250��62   $��10,0,0,0q�6>   54      �� 57      $ 
Horizontal=�6   $	��0,5q�66   .+�58      �� $��Middle Name:��6    $	��100��64   $��Center=�6@   �� 59      -   5        $��txtMiddleName��59      $	��250��63   $��10,0,0,0q�6?   5:      �� 5=      $ 
Horizontal=�6   $	��0,5q�66   .+�5>      �� $��
Last Name:��6    $	��100��62   $��Center=�6>   �� 5?      -   5        $��txtLastName��5?      $	��250��61   $��10,0,0,0q�6=   5@      5A      5B      �� 5E   
   $��2��6   $��Course Enrollment��6    $��0,0,0,15q�6;   .��5F      �� $��10q�6   .+�5H      �� $ 
Horizontal=�6   $	��0,5q�66   .+�5I      �� $��Add Course:��6    $	��100��63   $��Center=�6?   �� 5J      -   5        $��cbAvailableCourses��5J      $	��200��69   $��10,0,0,0q�6E    �� DisplayMemberPath$ 
CourseCode��5K       �� SelectedValuePath$ CourseId��6>   �� 5L      -   5        $��btnAddCourse��5L      $	��Add��61   $��60��6?   $��25��6J   $��10,0,0,0q�5M      6/   5N      �� 5Q      $��Enrolled Courses:��6   $��0,10,0,5q�65   $
��Bold"�6G   �� 5R      -   5        $��lbStudentCourses��5R      $	��150��62   $��0,0,0,10q�6?   ��5S      �� 5T      .R�5U      �� $ 
Horizontal=�6)   .+�5V   "   �� $	��200��6H   $��Center=�6T   ��6,   �� *
CourseName+6T   �� 5W   "   $��80��6H   $��Center=�6S   
�������$��10,0,0,0q�5X   =   ��5W   ,   �� *
CourseCode+5X   =   �� 5Y   "   -	   5        $��Remove��5Y   )   $��60��6:   $��20��6E   
�������$��10,0,0,0q�5]   )   
 � Tag 5[   )   �� *
CourseId+5]   )   5^      5_      5a      5b      5c      �� 5f   
   -
   5        $��txtValidationMessage��5f   !   $��3��6   
���  ��$��12(�5g   %   $��0,10,0,0q�5h      $y�Visible=�5i      �� 5l   
   $��4��6   $ 
Horizontal=�6"   $��Center=�5m      $��0,20,0,0q�5n      .+�5o      �� -   5        $��btnSave��5o      $��Save Changes��6$   $	��100��6;   $��30��6G   $��5q�5p      6    �� 5q      -   5        $��	btnCancel��5q      $��Cancel��6&   $��80��67   $��30��6B   $��5q�5r      6    5s      5t      5u      