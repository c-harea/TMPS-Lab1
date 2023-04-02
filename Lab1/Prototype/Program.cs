using System.Xml.Linq;

public interface IPrototype
{
    IPrototype Clone();
}

public class Student : IPrototype
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Course { get; set; }

    public IPrototype Clone()
    {
        return (Student)MemberwiseClone();
    }

}

public static class StudentUtil
{
    public static void AddStudentInfo(Student student)
    {

        Console.WriteLine("Enter Student ID:");
        student.Id = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Enter Student Age:");
        student.Age = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Enter Student Name:");
        student.Name = Console.ReadLine();

        Console.WriteLine("Enter Student Course:");
        student.Course = Console.ReadLine();

    }

    public static void DisplayStudents(List<Student>? students)
    {
        if (students.Count != 0)
        {
            foreach (var student in students)
            {
                Console.WriteLine("Student ID: " + student.Id);
                Console.WriteLine("Student Name: " + student.Name);
                Console.WriteLine("Student Age: " + student.Age);
                Console.WriteLine("Student Course: " + student.Course + "\n");
            }
        }
    }
}

class Program
{

    static void Main(string[] args)
    {

        var prototype = new Student { Id = 0, Name = "John", Age = 18, Course = "Computer Science"};

        Student student = new Student();
        List<Student>? students = new List<Student>();

        while (true)
        {
            StudentUtil.DisplayStudents(students);

            students.Add((Student)prototype.Clone());

            Console.WriteLine("\n New Student was added! Change his fields? (y/n)");

            if(Console.ReadLine() == "y")
            {
               StudentUtil.AddStudentInfo(students.Last());
            }

            Console.Clear();
        }

    }
}
