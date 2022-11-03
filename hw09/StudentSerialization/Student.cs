namespace StudentSerialization;

[Serializable]
public class Student
{
    public Student(decimal studentId, string firstName, string lastName, int age, Group group)
    {
        StudentId = studentId;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Group = group;
    }

    public decimal StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Group Group { get; set; }
}
