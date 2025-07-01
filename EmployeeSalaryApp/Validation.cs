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

        public double InputDouble(string message, double minValue, double maxValue)
        {
            double result;
            while (true) { 
                try
                {
                    Console.Write(message);
                    result = Convert.ToDouble(Console.ReadLine().Trim());
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
                    Console.WriteLine("Overflowed double.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
            return result; 
        }

        public bool ValidateFileString(string input, int lineNumber, string line, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine($"\nLine {lineNumber}: Invalid {fieldName} at line {line}\n");
                return false;
            }
            return true;
        }

        public bool ValidateFileLength(string[] parts, int expectedLength, int lineNumber, string line)
        {
            if (parts.Length != expectedLength)
            {
                Console.WriteLine($"\nLine {lineNumber}: Invalid format at line {line}\n");
                return false;
            }
            return true;
        }

        public bool ValidateFileInteger(string input, out int result, int lineNumber, string line, string fieldName)
        {
            if (!int.TryParse(input, out result))
            {
                Console.WriteLine($"\nLine {lineNumber}: Invalid {fieldName} at line {line}\n");
                return false;
            }
            return true;
        }

        public bool ValidateFileDouble(string input, out double result, int lineNumber, string line, string fieldName)
        {
            if (!double.TryParse(input, out result))
            {
                Console.WriteLine($"\nLine {lineNumber}: Invalid {fieldName} at line {line}\n");
                return false;
            }
            return true;
        }

        public bool ValidateFileDoubleNonNegative(string input, out double result, int lineNumber, string line, string fieldName)
        {
            if (!ValidateFileDouble(input, out result, lineNumber, line, fieldName))
                return false;

            if (result < 0)
            {
                Console.WriteLine($"\nLine {lineNumber}: {fieldName} cannot be negative at line {line}\n");
                return false;
            }
            return true;
        }

        public bool ValidateFileValueInSet(string input, string[] validValues, out string normalized, int lineNumber, string line, string fieldName)
        {
            normalized = input.Trim().ToLower();
            if (!validValues.Contains(normalized))
            {
                Console.WriteLine($"\nLine {lineNumber}: Invalid {fieldName} at line {line}\n");
                return false;
            }
            return true;
        }

    }
}
