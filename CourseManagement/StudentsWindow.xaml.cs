using System;
using System.Collections.Generic;
using System.Globalization;
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
using Microsoft.EntityFrameworkCore;

namespace CourseManagement
{
    /// <summary>
    /// Interaction logic for StudentsWindow.xaml
    /// </summary>
    public partial class StudentsWindow : Window
    {
        ApContext context = new ApContext();
        public StudentsWindow()
        {
            try
            {
                InitializeComponent();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\n" + ex.StackTrace);
                Application.Current.Shutdown();
            }
        }

        private List<Student> LoadData(int? id=null)
        {
            List<Student> students;
            if (id == null)
            {
                students = context.Students.ToList();
                dgStudent.ItemsSource = students;

            } else
            {
                students = context.Students.Where(s => s.Courses.Any(c => c.CourseId == id)).ToList();
                dgStudent.ItemsSource = students;
            }
            return students;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = sender as TextBox;
            if (!(tb.Foreground == Brushes.Black))
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;

            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var tb = sender as TextBox;
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string initialName = textInfo.ToTitleCase(tb.Name.Replace("search", "", StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = $"Enter {initialName} Name...";
                tb.Foreground = Brushes.Gray;
            }
        }



        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput())
                return;

            // Now it's safe to parse
            int id = int.Parse(idInputBox.Text.Trim());
            string rollNo = rollInputBox.Text?.Trim() ?? "";
            string firstName = firstNameInputBox.Text?.Trim() ?? "";
            string midName = midNameInputBox.Text?.Trim() ?? "";
            string lastName = lastNameInputBox.Text?.Trim() ?? "";

            var newStudent = new Student
            {
                StudentId = id,
                Roll = rollNo,
                FirstName = firstName,
                MidName = midName,
                LastName = lastName
            };
            context.Students.Add(newStudent);
            context.SaveChanges();
            LoadData();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgStudent.SelectedItem == null)
            {
                MessageBox.Show("Please select a student before click to edit button.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string editButtonText = (string) editButton.Content;

            if (editButtonText.Equals("Confirm", StringComparison.OrdinalIgnoreCase))
            {
                int id = int.Parse(idInputBox.Text);

                string? firstName = firstNameInputBox.Text;
                string? midName = midNameInputBox.Text;
                string? lastName = lastNameInputBox.Text;

                var studentToEdit = context.Students.Find(id);
                if (studentToEdit != null)
                {
                    studentToEdit.FirstName = firstName;
                    studentToEdit.MidName = midName;
                    studentToEdit.LastName = lastName;
                    context.SaveChanges();
                    LoadData();
                } else
                {
                    MessageBox.Show("Student null");
                }

                MessageBox.Show("Edited");
                editButton.Content = "Edit";

            } else
            {
                Student selectedStudentNotCourse = dgStudent.SelectedItem as Student;
                var selectedStudent = context.Students.Include(s => s.Courses).FirstOrDefault(s => s.StudentId == selectedStudentNotCourse.StudentId);
                if (selectedStudent != null)
                {
                    idInputBox.Text = selectedStudent.StudentId.ToString();
                    rollInputBox.Text = selectedStudent.Roll;
                    firstNameInputBox.Text = selectedStudent.FirstName;
                    midNameInputBox.Text = selectedStudent.MidName;
                    lastNameInputBox.Text = selectedStudent.LastName;

                    idInputBox.IsReadOnly = true;
                    rollInputBox.IsReadOnly = true;

                    editButton.Content = "Confirm";

                }
                else
                {
                    MessageBox.Show("Student is null");
                }
            }        
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgStudent.SelectedItem == null)
            {
                MessageBox.Show("Please select a student before click to edit button.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Student selectedStudentItem = dgStudent.SelectedItem as Student;
            if (selectedStudentItem == null)
            {
                MessageBox.Show("Selected item is not a valid student.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedStudent = context.Students
            .Include(s => s.Courses)
            .FirstOrDefault(s => s.StudentId == selectedStudentItem.StudentId);

            if (selectedStudent == null)
            {
                MessageBox.Show("Could not find the student in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                selectedStudent.Courses.Clear();
                context.Students.Remove(selectedStudent);
                context.SaveChanges();

                if (context.Students.Any(s => s.StudentId == selectedStudent.StudentId))
                {
                    MessageBox.Show("Delete failed");
                }
                else
                {
                    MessageBox.Show("Delete success");
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during delete: {ex.Message}");
            }
        }

        private bool ValidateInput()
        {
            // Hide previous error messages first
            idError.Visibility = Visibility.Collapsed;
            rollError.Visibility = Visibility.Collapsed;
            firstNameError.Visibility = Visibility.Collapsed;
            midNameError.Visibility = Visibility.Collapsed;
            lastNameError.Visibility = Visibility.Collapsed;

            // 1. Null check on controls themselves
            if (idInputBox == null || rollInputBox == null || firstNameInputBox == null ||
                midNameInputBox == null || lastNameInputBox == null)
            {
                MessageBox.Show("Some input fields are missing in the UI.");
                return false;
            }

            // 2. Check if required fields are filled
            if (string.IsNullOrWhiteSpace(idInputBox.Text))
            {
                idError.Text = "ID is required!";
                idError.Visibility = Visibility.Visible;
                idInputBox.Focus();
                return false;
            }

            // 3. Check if ID is a valid int
            if (!int.TryParse(idInputBox.Text.Trim(), out int id))
            {
                idError.Text = "ID must be a valid integer!";
                idError.Visibility = Visibility.Visible;
                idInputBox.Focus();
                return false;
            }

            // 4. Check duplicate student ID
            if (context.Students.Any(s => s.StudentId == id))
            {
                idError.Text = "Duplicate Student ID found!";
                idError.Visibility = Visibility.Visible;
                idInputBox.Focus();
                return false;
            }

            // 5. Roll number required
            string rollNo = rollInputBox.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(rollNo))
            {
                rollError.Text = "Roll number is required!";
                rollError.Visibility = Visibility.Visible;
                rollInputBox.Focus();
                return false;
            }

            // 6. Check duplicate roll number (assuming roll is unique)
            if (context.Students.Any(s => s.Roll == rollNo))
            {
                rollError.Text = "Duplicate Roll Number found!";
                rollError.Visibility = Visibility.Visible;
                rollInputBox.Focus();
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(rollNo, @"^0\d{4}$"))
            {
                rollError.Text = "Roll number must be 5 digits, start with '0', and contain only digits!";
                rollError.Visibility = Visibility.Visible;
                rollInputBox.Focus();
                return false;
            }

            // 7. First, Mid, Last name required
            if (string.IsNullOrWhiteSpace(firstNameInputBox.Text))
            {
                firstNameError.Text = "First name is required!";
                firstNameError.Visibility = Visibility.Visible;
                firstNameInputBox.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(midNameInputBox.Text))
            {
                midNameError.Text = "Mid name is required!";
                midNameError.Visibility = Visibility.Visible;
                midNameInputBox.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(lastNameInputBox.Text))
            {
                lastNameError.Text = "Last name is required!";
                lastNameError.Visibility = Visibility.Visible;
                lastNameInputBox.Focus();
                return false;
            }

            // All checks passed
            return true;
        }


        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchBar == null || dgStudent == null)
                return;
            string searchText = searchBar.Text?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadData();
                return;
            }

            var students = context.Students
                .ToList()
                .Where(s => FullNameJoin(s.FirstName, s.MidName, s.LastName)
                .IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            dgStudent.ItemsSource = students;
            dgStudent.Items.Refresh();
        }

        private string FullNameJoin(string firstName, string midName, string lastName)
        {
            var parts = new[] { firstName, midName, lastName }
            .Select(x => (x ?? "").Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x));

            var joinedString = string.Join(" ", parts);
            return joinedString;
        }
    }
}
