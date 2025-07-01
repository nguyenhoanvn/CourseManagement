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
    public partial class CourseScheduleWindow : Window
    {
        ApContext context = new ApContext();
        public CourseScheduleWindow()
        {
            InitializeComponent();
            LoadCourse();
            LoadData();
        }

        private void LoadData(int? id = null)
        {
            if (id == null)
            {
                var schedules = context.CourseSchedules;
                dgSchedule.ItemsSource = schedules.ToList();
            }
            else
            {
                var schedules = context.CourseSchedules.Where(s => s.CourseId == id).ToList();
                dgSchedule.ItemsSource = schedules;
            }

        }

        private void LoadCourse()
        {
            var courses = context.Courses.Include(c => c.Subject).ToList();
            cbCourse.ItemsSource = courses;
            cbCourse.DisplayMemberPath = "CourseCode";
            cbCourse.SelectedValuePath = "CourseId";
        }

        private void cbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCourse.SelectedValue is int courseId)
            {
                LoadData(courseId);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            cbCourse.SelectedIndex = -1;
            LoadData();
        }
    }
}