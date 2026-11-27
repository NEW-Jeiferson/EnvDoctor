using System.Text.Json;
using System.Text.Json.Serialization;

if (args.Length != 1)
{
    Console.Error.WriteLine("Uso: envdoctor <carpeta-del-proyecto>");
    return 2;
}

try
{
    var report = new ProjectScanner(new ConfigFileDetector()).Scan(args[0]);
    var options = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
    };
    Console.WriteLine(JsonSerializer.Serialize(report, options));
    return 0;
}
catch (DirectoryNotFoundException e)
{
    Console.Error.WriteLine(e.Message);
    return 1;
}
