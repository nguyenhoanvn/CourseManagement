namespace BusinessLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a new student object
            Student student = new Student(1, "John Doe", 20);

            // Show the student's details
            student.Show();

            // Wait for user input before closing the console window
            Console.ReadLine();
        }
    }
}