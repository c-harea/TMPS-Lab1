public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Course { get; set; }
}

public class StudentBuilder
{
    private Student _student;

    public StudentBuilder() 
    { 
        _student = new Student(); 
    }

    public void SetStudentId()
    {
        Console.WriteLine("Enter Student ID:");
        _student.Id = int.Parse(Console.ReadLine());
    }

    public void SetStudentAge()
    {
        Console.WriteLine("Enter Student Age:");
        _student.Age = int.Parse(Console.ReadLine());
    }

    public void SetStudentName()
    {
        Console.WriteLine("Enter Student Name:");
        _student.Name = Console.ReadLine();
    }

    public void SetStudentCourse()
    {
        Console.WriteLine("Enter Student Course:");
        _student.Course = Console.ReadLine();
    }

    public Student Build()
    { 
        return _student; 
    }

}

class Program
{

    static void DisplayStudents(List<Student>? students)
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

    static void Main(string[] args)
    {

        List<Student>? students = new List<Student>();
        StudentBuilder builder = new StudentBuilder();


        while (true)
        {
            DisplayStudents(students);

            builder.SetStudentId();
            builder.SetStudentName();
            builder.SetStudentCourse();
            builder.SetStudentAge();

            Console.Clear();
            students.Add(builder.Build());
        }

    }
}
