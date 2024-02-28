using CRUD_UsingADO;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Insert a new student");
            Console.WriteLine("2. Retrieve all students");
            Console.WriteLine("3. Update a student");
            Console.WriteLine("4. Delete a student");
            Console.WriteLine("5. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    InsertStudent();
                    break;
                case 2:
                    RetrieveStudents();
                    break;
                case 3:
                    // UpdateStudent();
                    break;
                case 4:
                    // DeleteStudent();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }

    static void InsertStudent()
    {
        Console.WriteLine("Enter student details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Gender: ");
        string gender = Console.ReadLine();
        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());

        Student st = new Student(name, gender, age);
        Student.InsertStudent(st);
        Console.WriteLine();

    }

    static void RetrieveStudents()
    {
        Console.WriteLine("List of all students:");
        Student.RetrieveStudents();
        Console.WriteLine();
    }





}

