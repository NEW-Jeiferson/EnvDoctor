/// <summary>Recorre la carpeta elegida y lista los archivos de configuración.</summary>
public sealed class ProjectScanner(ConfigFileDetector detector)
{
    private const int MaxDepth = 8;

    private static readonly HashSet<string> Ignored = new(StringComparer.OrdinalIgnoreCase)
    {
        ".git", ".vs", "bin", "obj", "node_modules", ".venv"
    };

    public ScanReport Scan(string folder)
    {
        var guard = new PathGuard(folder);
        var files = new List<DetectedFile>();
        var findings = new List<Finding>();
        Walk(guard, guard.Root, 0, files, findings);

        if (files.Count == 0)
            findings.Add(new Finding("SCAN001", Severity.Warning, "escaneo",
                "No se encontraron archivos de configuración compatibles.",
                Recommendation: "Verifica que elegiste la carpeta raíz del proyecto."));

        return new ScanReport("0.1", Path.GetFileName(guard.Root), DateTimeOffset.UtcNow,
            files.OrderBy(f => f.Path, StringComparer.Ordinal).ToList(), findings);
    }

    private void Walk(PathGuard guard, string directory, int depth,
        List<DetectedFile> files, List<Finding> findings)
    {
        try
        {
            foreach (var file in Directory.EnumerateFiles(directory))
            {
                var type = detector.Detect(Path.GetFileName(file));
                if (type is not null && guard.IsInside(file))
                    files.Add(new DetectedFile(Relative(guard, file), type));
            }

            if (depth >= MaxDepth) return;

            foreach (var child in Directory.EnumerateDirectories(directory))
                if (!Ignored.Contains(Path.GetFileName(child)) && guard.IsInside(child))
                    Walk(guard, child, depth + 1, files, findings);
        }
        catch (Exception e) when (e is UnauthorizedAccessException or IOException)
        {
            findings.Add(new Finding("SCAN002", Severity.Info, "escaneo",
                "No se pudo leer una carpeta.", Relative(guard, directory)));
        }
    }

    private static string Relative(PathGuard guard, string path) =>
        Path.GetRelativePath(guard.Root, path).Replace('\\', '/');
}
