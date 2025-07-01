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
    /// Interaction logic for EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {

        public Student EditedStudent { get; private set; }
        public bool IsSaved { get; private set; }

        private List<Course> allCourses;
        private List<Course> studentCourses;
        private List<Course> availableCourses;
        public EditStudentWindow(Student student, List<Course> allAvailableCourses)
        {
            InitializeComponent();
            allCourses = allAvailableCourses ?? new List<Course>();
            LoadStudentData(student);
            LoadCourseData();
            IsSaved = false;
        }

        private void LoadStudentData(Student student)
        {
            if (student != null)
            {
                txtStudentId.Text = student.StudentId.ToString();
                txtRoll.Text = student.Roll;
                txtFirstName.Text = student.FirstName;
                txtMiddleName.Text = student.MidName;
                txtLastName.Text = student.LastName;

                EditedStudent = new Student
                {
                    StudentId = student.StudentId,
                    Roll = student.Roll,
                    FirstName = student.FirstName,
                    MidName = student.MidName,
                    LastName = student.LastName,
                    Courses = new List<Course>(student.Courses ?? new List<Course>())
                };
                studentCourses = new List<Course>(EditedStudent.Courses);
            }        
        }

        private void LoadCourseData()
        {
            lbStudentCourses.ItemsSource = studentCourses;
            availableCourses = allCourses.Where(c => !studentCourses.Any(sc => sc.CourseId == c.CourseId)).ToList();
            cbAvailableCourses.ItemsSource = availableCourses;

            if (availableCourses.Any())
            {
                cbAvailableCourses.SelectedIndex = 0;
            }
            lbStudentCourses.Items.Refresh();
            cbAvailableCourses.Items.Refresh();
        }

        private void btnAddCourse_Click(object sender, RoutedEventArgs e)
        {
            if (cbAvailableCourses.SelectedItem is Course selectedCourse)
            {
                studentCourses.Add(selectedCourse);
                LoadCourseData();
                MessageBox.Show("Success add");
            } else
            {
                MessageBox.Show("Please select a course");
            }
        }

        private void btnRemoveCourse_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int courseId)
            {
                var courseToRemove = studentCourses.FirstOrDefault(c => c.CourseId == courseId);
                if (courseToRemove != null)
                {
                    // Confirm removal
                    var result = MessageBox.Show(
                        $"Are you sure you want to remove '{courseToRemove.CourseCode}' from this student's enrollment?",
                        "Confirm Removal",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        studentCourses.Remove(courseToRemove);
                        LoadCourseData();
                        MessageBox.Show($"Removed {courseToRemove.CourseCode}");
                    }
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                // Update the student object with new values
                EditedStudent.Roll = txtRoll.Text.Trim();
                EditedStudent.FirstName = txtFirstName.Text.Trim();
                EditedStudent.MidName = txtMiddleName.Text.Trim();
                EditedStudent.LastName = txtLastName.Text.Trim();

                // Update courses collection
                EditedStudent.Courses = new List<Course>(studentCourses);

                IsSaved = true;

                this.DialogResult = true;
                this.Close();
            }
        }
        private bool ValidateInput()
        {
            txtValidationMessage.Visibility = Visibility.Collapsed;

            // Check if required fields are filled
            if (string.IsNullOrWhiteSpace(txtRoll.Text))
            {
                MessageBox.Show("Roll is required");
                txtRoll.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("FirstName is required");
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("LastName is required");
                txtLastName.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
