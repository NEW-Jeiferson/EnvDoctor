public sealed record DetectedFile(string Path, string Type);

public sealed record ScanReport(
    string SchemaVersion,
    string ProjectName,
    DateTimeOffset GeneratedAt,
    IReadOnlyList<DetectedFile> Files,
    IReadOnlyList<Finding> Findings);
