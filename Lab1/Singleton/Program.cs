public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Course { get; set; }
}

public sealed class StudentDatabase
{
    private static readonly StudentDatabase _instance = new StudentDatabase();

    private List<Student> _students;

    private StudentDatabase() 
    {
        _students = new List<Student>();
    }

    public static StudentDatabase Instance
    {
        get
        {
            return _instance;
        }
    }

    public void DisplayStudents()
    {

        if (_students.Count != 0)
        {
            foreach (var student in _students)
            {
                Console.WriteLine("Student ID: " + student.Id);
                Console.WriteLine("Student Name: " + student.Name);
                Console.WriteLine("Student Age: " + student.Age);
                Console.WriteLine("Student Course: " + student.Course + "\n");
            }
        }
        
    }

    public void AddStudent()
    {
        Student student = new Student();

        Console.WriteLine("Enter Student ID:");
        student.Id = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Enter Student Age:");
        student.Age = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Enter Student Name:");
        student.Name = Console.ReadLine();

        Console.WriteLine("Enter Student Course:");
        student.Course = Console.ReadLine();

        _students.Add(student);

        Console.Clear();
    }

    public void UpdateStudent(int id)
    {
        _students.Find(u => u.Id == id).Age = int.Parse(Console.ReadLine() ?? "0");
        _students.Find(u => u.Id == id).Course = Console.ReadLine();
    }

    public void DeleteStudent(int id)
    {
        _students.Remove(_students.Find(u => u.Id == id));
    }
}

class Program
{
    static void Main(string[] args)
    {

        while (true)
        {
            StudentDatabase.Instance.DisplayStudents();
            StudentDatabase.Instance.AddStudent();
        }

    }
}