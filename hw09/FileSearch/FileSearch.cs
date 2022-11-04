using System.Security;

namespace FileSearch;

public static class FileSearch
{
    public static FileInfo? FindFile(string fileName)
    {
        return FindFile(fileName, new DirectoryInfo(@"C:\"));
    }

    private static FileInfo? FindFile(string fileNameToFind, DirectoryInfo inDirectory)
    {
        try
        {
            var mbFileInfo = inDirectory.EnumerateFiles()
                .FirstOrDefault(fileInfo => fileInfo.Name == fileNameToFind);
            if (mbFileInfo != null)
                return mbFileInfo;

            return inDirectory.GetDirectories()
                .Select(directory => FindFile(fileNameToFind, directory))
                .FirstOrDefault(fileInfo => fileInfo != null);
        }
        catch (Exception ex)
        {
            if (ex is SecurityException or DirectoryNotFoundException or UnauthorizedAccessException)
                return null;
            throw;
        }
    }
}