public sealed record Finding(
    string Id,
    Severity Severity,
    string Category,
    string Message,
    string? File = null,
    string? Recommendation = null);
