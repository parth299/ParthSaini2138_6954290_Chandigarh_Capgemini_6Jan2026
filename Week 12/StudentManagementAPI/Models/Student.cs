namespace StudentManagementAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; } // Sensitive

        public DateTime CreatedAt { get; set; }
    }
}