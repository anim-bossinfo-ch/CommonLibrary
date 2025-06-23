using System;

namespace BossInfo.Dms.CommonLibrary;

public class FilePathString : PathString
{
    public FilePathString(string path) : base(path) {}

    /// <summary>
    /// Empties the content of the file at this path. If the file does not exist, it creates an empty file.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the path does not represent a file.</exception>
    public void EmptyFileContent()
    {
        if (!IsFile)
            throw new InvalidOperationException("Path does not represent a file.");

        // Overwrite the file with empty content (creates file if it does not exist)
        System.IO.File.WriteAllText(Full, string.Empty);
    }

    // Allow implicit conversion to and from string
    public static implicit operator string(FilePathString p) => p.path;
    public static implicit operator FilePathString(string s) => new FilePathString(s);
}