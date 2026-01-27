using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public int Id { get; set; }
}

class Student : Person
{
    public List<string> Courses = new List<string>();
}

class Professor : Person
{
    public string Subject { get; set; }
}

class Staff : Person
{
    public string Department { get; set; }
}

class Course
{
    public string CourseName { get; set; }
    public Professor AssignedProfessor { get; set; }
}
