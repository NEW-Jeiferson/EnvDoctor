/// <summary>Reconoce archivos de configuración por su nombre, sin abrirlos.</summary>
public sealed class ConfigFileDetector
{
    private static readonly Dictionary<string, string> ByName = new(StringComparer.OrdinalIgnoreCase)
    {
        ["package.json"] = "node",
        ["package-lock.json"] = "node-lock",
        ["requirements.txt"] = "python",
        ["pyproject.toml"] = "python",
        ["global.json"] = "dotnet-sdk",
        ["Dockerfile"] = "dockerfile",
        ["docker-compose.yml"] = "compose",
        ["docker-compose.yaml"] = "compose",
        ["compose.yml"] = "compose",
        ["compose.yaml"] = "compose"
    };

    public string? Detect(string fileName)
    {
        if (ByName.TryGetValue(fileName, out var type)) return type;
        return Path.GetExtension(fileName).ToLowerInvariant() switch
        {
            ".csproj" => "dotnet-project",
            ".sln" or ".slnx" => "dotnet-solution",
            _ => null
        };
    }
}
