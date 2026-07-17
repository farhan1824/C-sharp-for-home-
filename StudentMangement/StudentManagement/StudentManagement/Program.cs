using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement
{
    // --- Data Models ---
    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Mark { get; set; }

        public string Grade
        {
            get
            {
                if (Mark >= 80) return "A+";
                if (Mark >= 70) return "A";
                if (Mark >= 60) return "B";
                if (Mark >= 50) return "C";
                if (Mark >= 40) return "D";
                return "F";
            }
        }

        public bool IsPassed => Mark >= 40;
    }

    // --- Main Program ---
    class Program
    {
        private static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            // Seed some initial data for easier testing
            //SeedData();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Student Result App");
                Console.WriteLine("\n===== STUDENT RESULT APP SYSTEM =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Remove Student");
                Console.WriteLine("5. Search By Student ID");
                Console.WriteLine("6. Search By Student Name");
                Console.WriteLine("7. Mark for Highest Mark, Lowest Mark, Average Mark");
                Console.WriteLine("8. Display Passed Students");
                Console.WriteLine("9. Display Students By Grade");
                Console.WriteLine("10. Filter Students Above Average");
                Console.WriteLine("11. Sort Students By Mark");
                Console.WriteLine("12. Display Top Performer");
                Console.WriteLine("0. Exit");
                Console.Write("Enter Choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": DisplayAllStudents(); break;
                    case "3": UpdateStudent(); break;
                    case "4": RemoveStudent(); break;
                    case "5": SearchById(); break;
                    case "6": SearchByName(); break;
                    case "7": ShowCalculatedMarks(); break;
                    case "8": DisplayPassedStudents(); break;
                    case "9": DisplayStudentsByGrade(); break;
                    case "10": FilterStudentsAboveAverage(); break;
                    case "11": SortStudentsByMark(); break;
                    case "12": DisplayTopPerformer(); break;
                    case "0":
                        Console.WriteLine("\nThank you for using the app. Exiting...");
                        return;
                    default:
                        Console.WriteLine("\nInvalid Choice! Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // --- Features Implementation ---

        private static void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("=== Add Student ===");

            Console.Write("Enter Student ID: ");
            string id = Console.ReadLine().Trim();
            bool idExist = false;
            foreach (var s in students)
            {
                if (s.ID.ToLower() == id.ToLower())
                {
                    idExist = true;
                }
                
            }
            if (idExist)
            {
                Console.WriteLine("Already Id Exists");
                PressAnyKey();
            }

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine().Trim();

            Console.Write("Enter Mark: ");
            string input = Console.ReadLine();
            int marks = int.Parse(input);

            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Error: Invalid Mark input (Must be between 0 and 100).");
                PressAnyKey();
                return;
            }

            students.Add(new Student { ID = id, Name = name, Mark = marks });
            Console.WriteLine("\nStudent added successfully!");
        }

        private static void DisplayAllStudents()
        {
            Console.Clear();
            Console.WriteLine("=== Display All Students ===");
            PrintStudentHeader();

            if (students.Count == 0)
            {
                Console.WriteLine("No student records found.");
            }
            else
            {
                foreach (var s in students)
                {
                    PrintStudentRow(s);
                }
            }
            PressAnyKey();
        }

        private static void UpdateStudent()
        {
            Console.Clear();
            Console.WriteLine("=== Update Student ===");
            Console.Write("Enter Student ID to update: ");
            string id = Console.ReadLine().Trim();

            Student student = null;
            foreach (var s in students)
            {
                if (s.ID.ToLower() == id.ToLower())
                {
                    student = s;
                    break;
                }
            }

            if (student == null)
            {
                Console.WriteLine("Student not found!");
                PressAnyKey();
                return;
            }

            Console.Write($"Enter New Name (Current: {student.Name} / Leave blank to skip): ");
            string newName = Console.ReadLine().Trim();
            if (newName != "")
            {
                student.Name = newName;
            }
            Console.Write($"Enter New Mark (Current: {student.Mark}, Leave blank to skip): ");
            string markInput = Console.ReadLine().Trim();

            if (markInput != "")
            {
                double newMark;
                bool isValidNumber = double.TryParse(markInput, out newMark);

                if (isValidNumber == false)
                {
                    Console.WriteLine("Invalid mark entry (Must be a number). Keeping old mark.");
                }
                else if (newMark < 0)
                {
                    Console.WriteLine("Invalid mark entry (Cannot be less than 0). Keeping old mark.");
                }
                else if (newMark > 100)
                {
                    Console.WriteLine("Invalid mark entry (Cannot be more than 100). Keeping old mark.");
                }
                else
                {
                    student.Mark = newMark;
                }
            }

            Console.WriteLine("\nStudent updated successfully!");
            PressAnyKey();
        }

        private static void RemoveStudent()
        {
            Console.Clear();
            Console.WriteLine("=== Remove Student ===");
            Console.Write("Enter Student ID to remove: ");
            string id = Console.ReadLine().Trim();
            Student student = null;
            foreach (var s in students)
            {
                if (s.ID.ToLower() == id.ToLower())
                {
                    student = s;
                    break;
                }
            }
            if (student == null)
            {
                Console.WriteLine("Student not found!");
            }
            else
            {
                students.Remove(student);
                Console.WriteLine("Student record deleted successfully.");
            }
            PressAnyKey();
        }

        private static void SearchById()
        {
            Console.Clear();
            Console.WriteLine("=== Search By Student ID ===");
            Console.Write("Enter Student ID: ");
            string id = Console.ReadLine().Trim();

            Student student= null;
            foreach(var s in students)
            {
                if (s.ID.ToLower() == id.ToLower())
                {
                    student = s;
                    break;
                }
            }
            if (student == null)
            {
                Console.WriteLine("No student found with that ID.");
            }
            else
            {
                PrintStudentHeader();
                PrintStudentRow(student);
            }
            PressAnyKey();
        }

        private static void SearchByName()
        {
            Console.Clear();
            Console.WriteLine("=== Search By Student Name ===");
            Console.Write("Enter Name/Part of Name: ");
            string searchName = Console.ReadLine().Trim();

            var results = students.Where(s => s.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();
            if (results.Count == 0)
            {
                Console.WriteLine("No students match your search criteria.");
            }
            else
            {
                PrintStudentHeader();
                foreach (var s in results) PrintStudentRow(s);
            }
            PressAnyKey();
        }

        private static void ShowCalculatedMarks()
        {
            Console.Clear();
            Console.WriteLine("=== Student Mark Analytics ===");
            if (students.Count == 0)
            {
                Console.WriteLine("No data available to calculate statistics.");
                PressAnyKey();
                return;
            }

            double highest = students.Max(s => s.Mark);
            double lowest = students.Min(s => s.Mark);
            double average = students.Average(s => s.Mark);

            Console.WriteLine($"Highest Mark : {highest:F2}");
            Console.WriteLine($"Lowest Mark  : {lowest:F2}");
            Console.WriteLine($"Average Mark : {average:F2}");
            PressAnyKey();
        }

        private static void DisplayPassedStudents()
        {
            Console.Clear();
            Console.WriteLine("=== Passed Students ===");
            var passedList = students.Where(s => s.IsPassed).ToList();

            if (passedList.Count == 0)
            {
                Console.WriteLine("No students passed.");
            }
            else
            {
                PrintStudentHeader();
                foreach (var s in passedList) PrintStudentRow(s);
            }
            PressAnyKey();
        }

        private static void DisplayStudentsByGrade()
        {
            Console.Clear();
            Console.WriteLine("=== Display Students By Grade ===");
            Console.Write("Enter targeted Grade (e.g., A+, A, B, F): ");
            string targetGrade = Console.ReadLine().Trim();

            var results = students.Where(s => s.Grade.Equals(targetGrade, StringComparison.OrdinalIgnoreCase)).ToList();
            if (results.Count == 0)
            {
                Console.WriteLine($"No students found with grade '{targetGrade}'.");
            }
            else
            {
                PrintStudentHeader();
                foreach (var s in results) PrintStudentRow(s);
            }
            PressAnyKey();
        }

        private static void FilterStudentsAboveAverage()
        {
            Console.Clear();
            Console.WriteLine("=== Students Scoring Above Average ===");
            if (students.Count == 0)
            {
                Console.WriteLine("No records found.");
                PressAnyKey();
                return;
            }

            double average = students.Average(s => s.Mark);
            Console.WriteLine($"Current Average Mark: {average:F2}\n");

            var results = students.Where(s => s.Mark > average).ToList();
            if (results.Count == 0)
            {
                Console.WriteLine("No students are scoring above average.");
            }
            else
            {
                PrintStudentHeader();
                foreach (var s in results) PrintStudentRow(s);
            }
            PressAnyKey();
        }

        private static void SortStudentsByMark()
        {
            Console.Clear();
            Console.WriteLine("=== Sort Students By Mark ===");
            Console.WriteLine("1. Sort Ascending (Lowest to Highest)");
            Console.WriteLine("2. Sort Descending (Highest to Lowest)");
            Console.Write("Enter Option: ");
            string sortOpt = Console.ReadLine();

            IOrderedEnumerable<Student> sortedList;
            if (sortOpt == "1")
            {
                sortedList = students.OrderBy(s => s.Mark);
            }
            else if (sortOpt == "2")
            {
                sortedList = students.OrderByDescending(s => s.Mark);
            }
            else
            {
                Console.WriteLine("Invalid option. Returning to menu.");
                PressAnyKey();
                return;
            }

            PrintStudentHeader();
            foreach (var s in sortedList) PrintStudentRow(s);
            PressAnyKey();
        }

        private static void DisplayTopPerformer()
        {
            Console.Clear();
            Console.WriteLine("=== Top Performer ===");
            if (students.Count == 0)
            {
                Console.WriteLine("No data available.");
                PressAnyKey();
                return;
            }

            double highestMark = students.Max(s => s.Mark);
            var topPerformers = students.Where(s => s.Mark == highestMark).ToList();

            PrintStudentHeader();
            foreach (var s in topPerformers)
            {
                PrintStudentRow(s);
            }
            PressAnyKey();
        }

        // --- Helper Layout Methods ---

        private static void PrintStudentHeader()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{"ID",-10} | {"Name",-20} | {"Mark",-8} | {"Grade",-5}");
            Console.WriteLine(new string('-', 50));
        }

        private static void PrintStudentRow(Student s)
        {
            Console.WriteLine($"{s.ID,-10} | {s.Name,-20} | {s.Mark,-8:F2} | {s.Grade,-5}");
        }

        private static void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }

     }
}