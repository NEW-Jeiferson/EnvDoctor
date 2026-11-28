/// <summary>Limita la lectura a la carpeta que eligió el usuario.</summary>
public sealed class PathGuard
{
    public string Root { get; }

    public PathGuard(string root)
    {
        Root = Path.TrimEndingDirectorySeparator(Path.GetFullPath(root));
        if (!Directory.Exists(Root))
            throw new DirectoryNotFoundException($"La carpeta no existe: {Root}");
    }

    public bool IsInside(string path)
    {
        var full = Path.GetFullPath(path, Root);
        var relative = Path.GetRelativePath(Root, full);
        if (Path.IsPathRooted(relative) || relative == ".."
            || relative.StartsWith(".." + Path.DirectorySeparatorChar))
            return false;

        // Ningún tramo bajo la raíz puede ser un enlace que lleve a otro sitio.
        var current = Root;
        foreach (var part in relative.Split(Path.DirectorySeparatorChar))
        {
            if (part == ".") continue;
            current = Path.Combine(current, part);
            if (new FileInfo(current).LinkTarget is not null) return false;
        }
        return true;
    }
}
