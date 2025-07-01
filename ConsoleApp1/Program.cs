using System;
using System.Collections;
using System.Data.SqlClient;
using ConsoleApp2;
internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Enter ID: ");
        //int id = Int16.Parse(Console.ReadLine());
        //int id = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Enter Name: ");
        //string name = Console.ReadLine();
        //Console.WriteLine("Enter Age: ");
        //int age = Int16.Parse(Console.ReadLine());
        //Student student = new Student(id, name, age);

        //student.Show();
        Student s1 = new Student(1, "Hoang", "Ha Noi");
        Student s2 = new Student(1, "Hoang", "Ha Noi");
    }

    public static void DemoArrayList()
    {
        ArrayList a1 = new ArrayList();
        a1.Add(1);
        a1.Add("Hoang");
        a1.Add(2.5);
        a1.Add(new Student(1, "Hoang", "Ha Noi"));
        a1.Add(10);
    }

    public static void DemoList()
    {
        List<Student> list = new List<Student>();
        list.Add(new Student(1, "Hoang", "Ha Noi"));
        list.Add(new Student(2, "Nam", "Ha Noi"));
        list.Add(new Student(3, "Hanh", "Ha Noi"));
        foreach (Student s in list)
        {
            s.Show();
        }
    }

    //BTVN
    /*
     * Class Course: int id, string title, DateTime startDate
     * - Constructor ko tham so, nhieu tham so
     * - Input()
     * - ToString()
     * 
     * Class OnlineCourse ke thua tu Course
     * - String LinkList
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

}