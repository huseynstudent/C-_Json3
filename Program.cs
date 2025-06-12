using System;
using C__Json.Services;

class Program
{
    static void Main(string[] args)
    {
        bool hasExited = false;
        StudentService studentService = new StudentService();

        while (!hasExited)
        {
            Console.WriteLine("Enter a command \n1)add student\t2)remove student\t3)show all students\n\t'exit' to quit:");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "exit":
                    hasExited = true;
                    break;
                case "1":
                    studentService.AddStudent();
                    break;
                case "2":
                    studentService.RemoveStudents();
                    break;
                case "3":
                    studentService.ShowAllStudents();
                    break;
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
        }
    }
}
