using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager
{
    internal class Validation
    {
        public DateTime InputDate(string message, DateTime minDate)
        {
            DateTime currentDate;
            Console.Write(message);
            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(input))
                {
                    Console.Write("Date cannot be empty. Please enter again (dd/MM/yyyy): ");
                    continue;
                }

                if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    if (date < minDate)
                    {
                        Console.Write($"Date cannot be earlier than min date: {minDate:dd/MM/yyyy}. Please enter again (dd/MM/yyyy): ");
                        continue;
                    }
                    currentDate = date;
                    break;
                }
                else
                {
                    Console.Write("Invalid date format. Please enter again (dd/MM/yyyy): ");
                }
            }
            return currentDate;
        }

        public string InputString(string message)
        {
            string result = string.Empty;
            Console.Write(message);
            while (true)
            {
                result = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(result))
                {
                    Console.Write("This field cannot be empty. Please enter again: ");
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        public int InputInteger(string message, int minValue, int maxValue)
        {
            int result;
            while (true)
            {
                try
                {
                    Console.Write(message);
                    result = Convert.ToInt32(Console.ReadLine().Trim());
                    if (result < minValue || result > maxValue)
                    {
                        Console.WriteLine($"Please enter a value between {minValue} and {maxValue}: ");
                        continue;
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Overflowed integer.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
            return result;
        }
    }
}
