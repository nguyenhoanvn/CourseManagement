using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CourseManagement.Models;

namespace CourseManagement
{
    /// <summary>
    /// Interaction logic for AddEditEntityWindow.xaml
    /// </summary>
    public partial class AddEditEntityWindow : Window
    {
        Validation validation = new Validation();
        ApContext context = new ApContext();
        public AddEditEntityWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var courseList = context.Courses.ToList();
            lbCourse.ItemsSource = courseList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string studentId = studentIdInput.Text;
            
            string rollNo = rollNoInput.Text;
            if (string.IsNullOrWhiteSpace(rollNo) || rollNo.ToCharArray()[0] != '0')
            {
                MessageBox.Show("Please enter a roll number starts with 0.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                rollNoInput.BorderBrush = Brushes.Red;
                return;
            } else
            {
                rollNoInput.ClearValue(TextBox.BorderBrushProperty);
            }
            string firstName = firstNameInput.Text;
            string midName = midNameInput.Text;
            string lastName = lastNameInput.Text;

            var selectedCourses = lbCourse.SelectedItems.Cast<Course>().ToList();

            Student newStudent = new Student();
            newStudent.StudentId = int.Parse(studentId);
            newStudent.Roll = rollNo;
            newStudent.FirstName = firstName;
            newStudent.MidName = midName;
            newStudent.LastName = lastName;
            newStudent.Courses = selectedCourses;

            context.Students.Add(newStudent);
            context.SaveChanges();

            MessageBox.Show("Student added!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);

            ClearTextBoxes(spField);

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var field = sender as TextBox;
            field.Foreground = Brushes.Black;
            field.Text = "";
        }

        private void StudentId_LostFocus(object sender, RoutedEventArgs e)
        {
            var tb = sender as TextBox;
            string studentId = tb.Text;
            if (string.IsNullOrWhiteSpace(studentId) || !int.TryParse(studentId, out int id))
            {
                studentIdError.Text = "Validation Error";
                studentIdError.Visibility = Visibility.Visible;
                studentIdInput.BorderBrush = Brushes.Red;
                return;
            } else if (context.Students.Any(s => s.StudentId == id))
            {
                studentIdError.Text = "Id existed";
                studentIdError.Visibility = Visibility.Visible;
                studentIdInput.BorderBrush = Brushes.Red;
                return;
            }
            else
            {
                studentIdError.ClearValue(TextBlock.TextProperty);
                studentIdError.Visibility = Visibility.Collapsed;
                studentIdInput.ClearValue(TextBox.BorderBrushProperty);
            }
        }

        private void ClearTextBoxes(DependencyObject parent)
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is TextBox tb)
                {
                    tb.Text = string.Empty;
                    tb.ClearValue(TextBox.BorderBrushProperty);
                }
                else
                {
                    ClearTextBoxes(child);
                }
            }
        }
    }
}
