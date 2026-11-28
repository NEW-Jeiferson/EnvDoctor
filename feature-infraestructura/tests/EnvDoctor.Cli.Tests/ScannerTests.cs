public sealed class ScannerTests : IDisposable
{
    private readonly string _root = Directory.CreateTempSubdirectory("envdoctor").FullName;

    public void Dispose() => Directory.Delete(_root, true);

    private void Create(string path)
    {
        var full = Path.Combine(_root, path);
        Directory.CreateDirectory(Path.GetDirectoryName(full)!);
        File.WriteAllText(full, "");
    }

    private ScanReport Scan() => new ProjectScanner(new ConfigFileDetector()).Scan(_root);

    [Fact]
    public void Detects_config_files_and_skips_ignored_folders()
    {
        Create("app/App.csproj");
        Create("package.json");
        Create("node_modules/x/package.json");
        Create("notes.txt");

        Assert.Equal(["app/App.csproj", "package.json"], Scan().Files.Select(f => f.Path));
    }

    [Fact]
    public void Warns_when_nothing_is_found() =>
        Assert.Equal("SCAN001", Assert.Single(Scan().Findings).Id);

    [Theory]
    [InlineData("../fuera.txt")]
    [InlineData("a/../../fuera.txt")]
    public void Rejects_paths_outside_root(string path) =>
        Assert.False(new PathGuard(_root).IsInside(path));

    [Fact]
    public void Accepts_paths_inside_root() =>
        Assert.True(new PathGuard(_root).IsInside("a/b.json"));

    [Fact]
    public void Does_not_follow_links_to_outside()
    {
        if (OperatingSystem.IsWindows()) return; // crear enlaces exige permisos especiales
        var outside = Directory.CreateTempSubdirectory("fuera").FullName;
        File.WriteAllText(Path.Combine(outside, "package.json"), "");
        Directory.CreateSymbolicLink(Path.Combine(_root, "enlace"), outside);

        Assert.Empty(Scan().Files);
        Directory.Delete(outside, true);
    }
}
