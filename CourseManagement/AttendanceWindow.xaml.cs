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
using Microsoft.EntityFrameworkCore;

namespace CourseManagement
{
    /// <summary>
    /// Interaction logic for AttendanceWindow.xaml
    /// </summary>
    public partial class AttendanceWindow : Window
    {
        private List<Course> courses;
        private List<CourseSchedule> courseSchedules;
        private List<StudentAttendanceViewModel> attendanceList;

        public AttendanceWindow()
        {
            InitializeComponent();
            LoadCourse();
        }

        private void LoadCourse()
        {
            try { 
                using (var context = new ApContext())
                {
                    courses = context.Courses.Include(c => c.CourseSchedules).ToList();
                }
                cbCourse.ItemsSource = courses;
                cbCourse.DisplayMemberPath = "CourseCode";
                cbCourse.SelectionChanged += cbCourse_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in LoadCourse: " + ex.Message);
            }
        }

        private void cbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCourse = cbCourse.SelectedItem as Course;
            if (selectedCourse == null) { return; }

            var schedules = selectedCourse.CourseSchedules.ToList();
            cbDate.ItemsSource = schedules;
            cbDate.DisplayMemberPath = "TeachingDate";
            cbDate.SelectionChanged += cbDate_SelectionChanged;
        }

        private void cbDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDate = cbDate.SelectedItem as CourseSchedule;
            if (selectedDate == null) { return; }

            using (var context = new ApContext())
            {
                var rollCalls = context.RollCallBooks
                    .Where(rcb => rcb.TeachingScheduleId == selectedDate.TeachingScheduleId)
                    .Include(rcb => rcb.Student)
                    .ToList();

                attendanceList = rollCalls.Select(rc => new StudentAttendanceViewModel
                {
                    RollCallBookId = rc.RollCallBookId,
                    StudentId = rc.Student.StudentId,
                    Roll = rc.Student.Roll,
                    FullName = $"{rc.Student.FirstName} {rc.Student.MidName} {rc.Student.LastName}",
                    IsAbsent = rc.IsAbsent,
                    Comment = rc.Comment
                }).ToList();

                dataGrid.ItemsSource = attendanceList;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApContext())
            {
                foreach (var att in attendanceList)
                {
                    var rollCall = context.RollCallBooks.FirstOrDefault(rc => rc.RollCallBookId == att.RollCallBookId);
                    if (rollCall != null)
                    {
                        rollCall.IsAbsent = att.IsAbsent;
                        rollCall.Comment = att.Comment;
                    }
                }
                context.SaveChanges();
                MessageBox.Show("Attendance updated successfully!");
            }
        }
    }
}
