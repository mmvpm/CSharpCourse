namespace CustomCache;

public class FileStreamWrapper : IDisposable
{
    public FileStream FileStream { get; set; }

    private readonly string _name;
    private bool _disposed;

    public FileStreamWrapper(string fileName = "test.txt")
    {
        _name = fileName;
        _disposed = false;
        FileStream = new FileStream(fileName, FileMode.OpenOrCreate);
    }
    
    public void Dispose()
    {
        _disposed = true;
        FileStream.Close();
    }

    public override string ToString()
    {
        return "FSW(name = " + _name + ", disposed = " + _disposed + ")";
    }
}