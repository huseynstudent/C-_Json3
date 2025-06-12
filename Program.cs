using System;
using C__Json;
using C__Json.Models;
using C__Json.Abstract;
using C__Json.Services;
class Program
{
    static void Main(string[] args)
    {
        bool hasExited = false;
        string File = "Students.json";

        while (!hasExited)
        {
            Console.WriteLine("Enter a command \n1)add student\t2)remove student\t3)show all students: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                hasExited = true;
            }
            else if (input == "1")
            {
                AddStudent();
            }
            else if (input == "2")
            {
                RemoveStudents();
            }
            else if (input == "3")
            {
                ShowAllStudents();
            }
            else
            {
                Console.WriteLine("Invalid command. Please try again.");
            }
        }
    }
}
