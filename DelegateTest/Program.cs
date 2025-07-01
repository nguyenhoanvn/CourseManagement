using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            demoUsingComparison();
        }
        public static int Add(int x, int y)
        {
            Console.WriteLine("Add method");
            return x + y;
        }

        public static int Subtract(int x, int y)
        {
            Console.WriteLine("Subtract method");
            return x - y;
        }

        public static int Compute(int x, int y, Calculation calculation)
        {
            return calculation(x, y);
        }

        public static void demoBasicDelegate()
        {
            Calculation calculation = Add;
            calculation += Subtract;
            Console.WriteLine($"Output: {calculation(9, 4)}");
            Compute(9, 5, calculation);
        }

        public static void demoMulticastDelegate()
        {
            Calculation calculation = Subtract;
            calculation += Subtract;
            calculation += Add;
            calculation += Add;
            calculation -= Subtract;
            calculation -= Subtract;

            Console.WriteLine($"Output: {calculation(9, 4)}");
        }

        public static void demoUsingComparison()
        {
            CourseList courseList = new CourseList();
            courseList.initData();
            Console.WriteLine("Before sorting:");
            courseList.showCourse();
            // Sort by title using the delegate
            courseList.SortByTitle();
            Console.WriteLine("After sorting by title:");
            courseList.showCourse();
        }
    }
}

    


