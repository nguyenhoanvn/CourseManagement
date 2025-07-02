using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            CourseScheduleWindow scheduleWindow = new CourseScheduleWindow();
            scheduleWindow.Show();
            this.Close();
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentsWindow studentWindow = new StudentsWindow();
            Application.Current.MainWindow = studentWindow;
            studentWindow.Show();
            this.Close();
        }

        private void btnAttendance_Click(object sender, RoutedEventArgs e)
        {
            AttendanceWindow attendanceWindow = new AttendanceWindow();
            attendanceWindow.ShowDialog();
        }
    }
}