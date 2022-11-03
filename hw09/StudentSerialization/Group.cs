using System.Runtime.Serialization;

namespace StudentSerialization;

[Serializable]
public class Group
{
    public Group(decimal groupId, string name)
    {
        GroupId = groupId;
        Name = name;
        Students = new List<Student>();
    }

    public decimal GroupId { get; set; }
    public string Name { get; set; }

    public List<Student> Students
    {
        get => _students;
        set
        {
            _students = value;
            _studentsCount = value.Count;
        }
    }
    public int StudentsCount => _studentsCount;

    private List<Student> _students;
    
    [NonSerialized]
    private int _studentsCount;

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        _studentsCount = _students.Count;
    }
}
