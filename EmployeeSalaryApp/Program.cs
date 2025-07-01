using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

/*
 * - Doc dl tu file:
 * 1 | Hoang | 1000 | manager
 * 2 | Nga | 950 | developer
 * 3 | Duong | 500 | Tester
 * 
 * - Tim employee theo id, name, position (using LinQ)
 * - Tim employee theo: salary theo khoang nhap vao
 * - Tim employee theo getSalaryYear theo khoang nhap vao
 */

namespace EmployeeSalaryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Function function = new Function();
            List<Employee> employees;
            employees = function.InitializeEmployeeList();
            function.Menu(employees);
        }
    }
}
