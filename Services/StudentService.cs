namespace C__Json.Services;
using C__Json.Abstract;
using C__Json.Models;
using System;
using System.Text.Json;

public class StudentService : IStudentservice
{
    public void AddStudent()
    {
        Console.WriteLine("Enter Studentname:");
        string newStudentname = Console.ReadLine();

        var student = new Student { Studentname = newStudentname };
        var json = File.Exists("Students.json") ? File.ReadAllText("Students.json") : "[]";
        var students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        students.Add(student);
        json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("Students.json", json);
        Console.WriteLine("Student added.");
    }
    public void ShowAllStudents()
    {
        var json = File.Exists("Students.json") ? File.ReadAllText("Students.json") : "[]";
        var students = JsonSerializer.Deserialize<List<Student>>(json);
        if (students == null || students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }
        Console.WriteLine("All Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"Studentname: {student.Studentname}");
        }
    }

    public void RemoveStudents()
    {
        Console.WriteLine("Enter Studentname to remove:");
        string studentname = Console.ReadLine();

        var json = File.Exists("Students.json") ? File.ReadAllText("Students.json") : "[]";
        var students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        int removed = students.RemoveAll(s => s.Studentname == studentname);
        if (removed > 0)
        {
            json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Students.json", json);
            Console.WriteLine("Student(s) removed.");
        }
        else
        {
            Console.WriteLine("No student found with that name.");
        }
    }
}