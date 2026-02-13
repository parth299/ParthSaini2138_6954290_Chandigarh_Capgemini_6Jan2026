class Student {
    public int Id;
    public string Name;
    public int Age;

    public Student() {
        Console.WriteLine("Normal ctor called");
    }

    public Student(int _id, string _name, int _age) {
        this.Id = _id;
        this.Name = _name;
        this.Age = _age;
        Console.WriteLine("Parameter ctor called");
    }
}

class Program {
    public static void Main(string[] args) {
        Student s1 = new Student
        {
            Id = 1,
            Name = "Parth",
            Age = 21
        };
    }
}