/*
     * Class Course: int id, string title, DateTime startDate
     * - Constructor ko tham so, nhieu tham so
     * - Input()
     * - ToString()
     * 
     * Class OnlineCourse ke thua tu Course
     * - String LinkMeet
     * - Constructor
     * - Input()
     * - To String()
     * 
     * Y/c: 
     * - Nhap danh sach (course (4 cai), onlinecourse (3 cai))
     * + Init Course c;
     * + Hoi la add Course hay OnlineCourse (press C or O)
     * + Neu la c thi c = new Course(), o thi c = new OnlineCourse()
     * - In danh sach vua nhap ra man hinh
     * - Nhap vao khoang ngay thang, startDate, endDate
     * - Tim cac Course co startDate trong khoang vua nhap
     * - Sap xep danh sach course theo thu tu Title Alphabet
     * 
     * Su dung List, Dictionary, SortedList, Stack, Queue
     */
using System.Globalization;

namespace CourseManager
{
    public class Program
    {
        public static void Main(String[] args)
        {
            // Tao Object Function
            Function function = new Function();
            Validation validation = new Validation();

            List<Course> courses;
            // Nhap danh sach
            while (true)
            {
                Console.Write("Do you want to load by file (Y/N): ");
                string input = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(input))
                {
                    Console.Write("Input cannot be empty. Please enter Y or N: ");
                    continue;
                }
                if (input.ToUpper() == "N")
                {
                    courses = function.InputCourses();
                    break;
                }
                else if (input.ToUpper() == "Y")
                {
                    string filePath = @"M:\courses.txt";
                    // Load courses from file
                    courses = function.LoadCoursesFromFile(filePath);
                    if (courses.Count == 0)
                    {
                        Console.WriteLine("No courses found in the file. Please enter courses manually.");
                        courses = function.InputCourses();
                    }
                    break;
                }
                else if (input.ToUpper() != "Y")
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                    continue;
                }
            }
            

            // In danh sach
            function.PrintCourses("Course List: ", courses);

            // New Line
            Console.WriteLine();

            // Nhap startDate, endDate
            DateTime startDate = validation.InputDate("Enter start date: ", DateTime.MinValue);
            DateTime endDate = validation.InputDate("Enter end date: ", startDate);

            // Tim cac Course co startDate trong khoang vua nhap
            List<Course> searchResult = function.SearchCoursesByDate(courses, startDate, endDate);

            // In danh sach vua tim duoc
            function.PrintCourses($"Course List in range {startDate} - {endDate}: ", searchResult);

            // Press enter to continue
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            // New Line
            Console.WriteLine();

            // Sap xep danh sach course theo thu tu Title Alphabet
            List<Course> sortedCourses = function.SortCoursesByTitle(courses);

            // In danh sach da sap xep
            function.PrintCourses("Sorted Course List: ", sortedCourses);
        }
    }
}
