   M S B A M L   `   `   `  ���� K  GCourseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CourseManagementCourseManagement  (    "CourseManagement.EditStudentWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:CourseManagement       � Title$  Edit Student��$	��650��$	��600�� � WindowStartupLocation$ CenterOwner=� � 
ResizeMode$ NoResize=�.��� $��20q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Edit Student Information��$��18(�$
��Bold"�$��Center=�$��0,0,0,20q��� $��1��$��Student Information��$��0,0,0,15q�.���� $��10q�.+���  �� Orientation$ 
Horizontal=�$	��0,5q�.+��� $��Student ID:��$	��100��$��Center=��� -   $��txtStudentId��$	��250�� �� 
IsReadOnly$
 True��
�������$��10,0,0,0q��� $ 
Horizontal=�$	��0,5q�.+��� $��Roll Number:��$	��100��$��Center=��� -   $��txtRoll��$	��250��$��10,0,0,0q��� $ 
Horizontal=�$	��0,5q�.+��� $��First Name:��$	��100��$��Center=��� -   $��txtFirstName��$	��250��$��10,0,0,0q��� $ 
Horizontal=�$	��0,5q�.+��� $��Middle Name:��$	��100��$��Center=��� -   $��txtMiddleName��$	��250��$��10,0,0,0q��� $ 
Horizontal=�$	��0,5q�.+��� $��
Last Name:��$	��100��$��Center=��� -   $��txtLastName��$	��250��$��10,0,0,0q��� $��2��$��Course Enrollment��$��0,0,0,15q�.���� $��10q�.+��� $ 
Horizontal=�$	��0,5q�.+��� $��Add Course:��$	��100��$��Center=��� -   $��cbAvailableCourses��$	��200��$��10,0,0,0q� �� DisplayMemberPath$ 
CourseCode�� �� SelectedValuePath$ CourseId���� -   $��btnAddCourse��$	��Add��$��60��$��25��$��10,0,0,0q��� $��Enrolled Courses:��$��0,10,0,5q�$
��Bold"��� -   $��lbStudentCourses��$	��150��$��0,0,0,10q����� .R��� $ 
Horizontal=�.+��� $	��200��$��Center=����� *
CourseName+�� $��80��$��Center=�
�������$��10,0,0,0q����� *
CourseCode+�� -	   $��Remove��$��60��$��20��
�������$��10,0,0,0q�
 � Tag �� *
CourseId+�� -
   $��txtValidationMessage��$��3��
���  ��$��12(�$��0,10,0,0q�$y�Visible=��� $��4��$ 
Horizontal=�$��Center=�$��0,20,0,0q�.+��� -   $��btnSave��$��Save Changes��$	��100��$��30��$��5q��� -   $��	btnCancel��$��Cancel��$��80��$��30��$��5q�