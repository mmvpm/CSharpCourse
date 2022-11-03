using System.Runtime.Serialization.Formatters.Binary;
using StudentSerialization;

void PrintGroup(Group group)
{
    Console.WriteLine("Group id: " + group.GroupId);
    Console.WriteLine("Group name: " + group.Name);
    Console.WriteLine("Students (" + group.StudentsCount + "): ");
    foreach (var student in group.Students)
    {
        Console.WriteLine("    Student(" +
                          student.StudentId + ", " +
                          student.FirstName + ", " +
                          student.LastName + ", " +
                          student.Age + ", " +
                          student.Group.Name + ")");
    }
}

MemoryStream SerializeGroup(Group group)
{
    var formatter = new BinaryFormatter();
    var stream = new MemoryStream();
    formatter.Serialize(stream, group);
    stream.Position = 0;
    return stream;
}

Group DeserializeGroup(Stream stream)
{
    var formatter = new BinaryFormatter();
    return (Group) formatter.Deserialize(stream);
}

var group = new Group(decimal.Zero, "group name");
var student0 = new Student(decimal.Zero, "first name 0", "last name 0", 20, group);
var student1 = new Student(decimal.One, "first name 1", "last name 1", 21, group);
group.Students = new List<Student> { student0, student1 };
PrintGroup(group);
Console.WriteLine();
/*
Output:
    Group id: 0
    Group name: group name
    Students (2):
        Student(0, first name 0, last name 0, 20, group name)
        Student(1, first name 1, last name 1, 21, group name)
*/

var newGroup = DeserializeGroup(SerializeGroup(group));
PrintGroup(newGroup);
/*
Output:
    Group id: 0
    Group name: group name
    Students (2):
        Student(0, first name 0, last name 0, 20, group name)
        Student(1, first name 1, last name 1, 21, group name)
*/
