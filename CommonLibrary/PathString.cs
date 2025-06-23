using System;
using System.IO;

namespace BossInfo.Dms.CommonLibrary;

public class PathString
{
    protected readonly string path;

    public PathString(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Path cannot be null or whitespace.", nameof(path));

        this.path = Normalize(path);
    }

    private static string Normalize(string path)
    {
        return Path.GetFullPath(path.Trim().Replace('/', Path.DirectorySeparatorChar));
    }

    public string Full => path;

    public string FileName => Path.GetFileName(path);

    public string Directory => Path.GetDirectoryName(path) ?? "";

    public bool Exists => File.Exists(path) || System.IO.Directory.Exists(path);

    public bool IsFile => File.Exists(path);

    public bool IsDirectory => System.IO.Directory.Exists(path);

    // Combine with another path
    public PathString Combine(string relativePath)
    {
        return new PathString(Path.Combine(path, relativePath));
    }

    public override string ToString() => path;

    // Allow implicit conversion to and from string
    public static implicit operator string(PathString p) => p.path;
    public static implicit operator PathString(string s) => new PathString(s);

    public override bool Equals(object? obj)
    {
        return obj is PathString other && string.Equals(path, other.path, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return path == null
            ? 0
            : StringComparer.OrdinalIgnoreCase.GetHashCode(path);
    }
}