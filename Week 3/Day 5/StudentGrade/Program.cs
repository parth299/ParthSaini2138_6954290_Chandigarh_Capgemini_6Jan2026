using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGrading
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> studentGrades = new Dictionary<int, double>
            {
                { 101, 78.5 },
                { 102, 62.0 },
                { 103, 49.5 },
                { 104, 85.0 },
                { 105, 55.0 }
            };

            Console.WriteLine("=== Initial Student Grades ===");
            DisplayGrades(studentGrades);

            Func<Dictionary<int, double>, double> calculateAverage =
                grades => grades.Values.Average();

            double averageGrade = calculateAverage(studentGrades);
            Console.WriteLine($"\nAverage Grade: {averageGrade:F2}");

            double riskThreshold = 60.0;
            Predicate<double> isAtRisk = grade => grade < riskThreshold;

            var atRiskStudents = studentGrades
                .Where(s => isAtRisk(s.Value))
                .ToDictionary(s => s.Key, s => s.Value);

            Console.WriteLine($"\n=== Students At Risk (Grade < {riskThreshold}) ===");
            DisplayGrades(atRiskStudents);

            // 4. Update a student's grade
            int rollToUpdate = 103;
            double newGrade = 65.0;

            if (studentGrades.ContainsKey(rollToUpdate))
            {
                studentGrades[rollToUpdate] = newGrade;
                Console.WriteLine($"\nUpdated Roll No {rollToUpdate} to Grade {newGrade}");
            }

            atRiskStudents = studentGrades
                .Where(s => isAtRisk(s.Value))
                .ToDictionary(s => s.Key, s => s.Value);

            Console.WriteLine("\n=== At-Risk Students After Update ===");
            DisplayGrades(atRiskStudents);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DisplayGrades(Dictionary<int, double> grades)
        {
            foreach (var student in grades)
            {
                Console.WriteLine($"Roll No: {student.Key}, Grade: {student.Value:F2}");
            }
        }
    }
}
