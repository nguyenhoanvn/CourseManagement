using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
{
    // Define a delegate type, Calculation as delegate name
    // The delegate takes two integers as parameters and returns an integer
    delegate int Calculation(int x, int y);
}

/*BTVN
 * Class Employee: int id, string name, double salary (luong theo month), string position (manager, developer, tester)
 * Getter setter, constructor k tham so, nhieu tham so, input()
 *  display(delegate inside using to compute salary) {
 *  hien thi thong tin Employee + salaryYear
 *  }
 *  salaryYear 
 *  = if position == manager => salaryYear = salary * 18
 *  = if position == dev => salaryYear = salary * 14
 *  = if position == tester => salaryYear = salary * 12
 *  delegate Salary(double salary, string position)
 */  

