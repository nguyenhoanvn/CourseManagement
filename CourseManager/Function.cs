using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager
{
    internal class Function
    {
        public List<Course> InputCourses()
        {
            List<Course> courseList = new List<Course>();
            int count = 1;
            int courseCount = 0;
            int onlineCourseCount = 0;
            bool addMore = true;
            while (count <= 7 && addMore)
            {
                if (count >= 2)
                {
                    Console.Write("Do you want to add more courses? (Y/N): ");
                    string input = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.Write("Input cannot be empty. Please enter Y or N: ");
                        continue;
                    }
                    if (input.ToUpper() == "N")
                    {
                        addMore = false;
                        break;
                    }
                    else if (input.ToUpper() != "Y")
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                        continue;
                    }
                }
                Course c;
                Console.Write("Which type of course you want to add? (C for Course, O for OnlineCourse): ");
                string type = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(type))
                {
                    Console.WriteLine("Type cannot be empty. Please enter again.");
                    continue;
                }
                else if (type.ToUpper() == "C")
                {
                    if (courseCount >= 4)
                    {
                        Console.WriteLine("You can only add 4 Course objects.");
                        continue;
                    }
                    else if (courseCount < 4)
                    {
                        c = new Course();
                        courseList.Add(c.AInput(courseList));
                        courseCount++;
                        Console.WriteLine($"Course added successfully with information: {c.Id} - {c.Title} - {c.StartDate.ToString("dd/MM/yyyy")}");

                    }
                }
                else if (type.ToUpper() == "O")
                {
                    if (onlineCourseCount >= 3)
                    {
                        Console.WriteLine("You can only add 3 Online Course objects.");
                        continue;
                    }
                    else if (onlineCourseCount < 3)
                    {
                        c = new OnlineCourse();
                        courseList.Add(c.AInput(courseList));
                        onlineCourseCount++;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid type. Please enter again.");
                    continue;
                }
                count++;
            }
            return courseList;
        }

        public List<Course> LoadCoursesFromFile(string filePath)
        {
            List<Course> courseList = new List<Course>();
            StreamReader sr;
            try
            {
                sr = File.OpenText(filePath);
            } catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
                return courseList;
            }

            using (sr)
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');

                    if (parts.Length < 4)
                    {
                        Console.WriteLine($"Invalid line format: {line}");
                        continue;
                    }

                    string type = parts[0];
                    if (!int.TryParse(parts[1], out int id))
                    {
                        Console.WriteLine($"Invalid ID in line: {line}");
                        continue;
                    }

                    bool duplicateFound = courseList.Any(c => c.Id == id);
                    if (duplicateFound)
                    {
                        Console.WriteLine($"Duplicate ID found: {id}");
                        continue;
                    }


                    string title = parts[2];
                    if (!DateTime.TryParseExact(parts[3], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
                    {
                        Console.WriteLine($"Invalid date format in line: {line}");
                        continue;
                    }

                    if (type == "C")
                    {
                        courseList.Add(new Course(id, title, startDate));
                    }
                    else if (type == "OC" && parts.Length == 5)
                    {
                        string linkMeet = parts[4];
                        courseList.Add(new OnlineCourse(id, title, startDate, linkMeet));
                    }
                    else
                    {
                        Console.WriteLine($"Invalid course type or data format: {line}");
                    }
                }
            }
            return courseList;
        }

        public void PrintCourses(string outputMessage, List<Course> courses)
        {
            if (courses == null || courses.Count == 0)
            {
                Console.WriteLine("No courses available.");
                return;
            } else
            {
                Console.WriteLine(outputMessage);
                foreach (var c in courses)
                {
                    Console.WriteLine(c.ToString());
                }
            }
                
        }

        public List<Course> SearchCoursesByDate(List<Course> courses, DateTime startDate, DateTime endDate)
        {
            List<Course> result = new List<Course>();
            foreach (var c in courses)
            {
                if (c.StartDate >= startDate && c.StartDate <= endDate)
                {
                    result.Add(c);
                }
            }
            return result;
        }

        public List<Course> SortCoursesByTitle(List<Course> courses)
        {
            List<Course> sortedCourses = new List<Course>(courses);
            sortedCourses.Sort((x, y) => string.Compare(x.Title, y.Title));

            Console.WriteLine("Courses sorted!");
            return sortedCourses;
        }
    }
}
