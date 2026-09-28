namespace PatternsLab.Problems.Singleton;

public sealed class AppConfigSingleton
{
    public static int LoadCount;

    private static readonly Lazy<AppConfigSingleton> _instance = new(() => new AppConfigSingleton());

    public static AppConfigSingleton Instance => _instance.Value;

    public string DbConnection { get; set; }
    public string Theme { get; set; }

    private AppConfigSingleton()
    {
        LoadCount++;
        Console.WriteLine($"[AppConfigSingleton] Loading settings from disk... (load #{LoadCount})");
        Thread.Sleep(300);
        DbConnection = "Server=localhost;Db=School";
        Theme = "Light";
    }
}

public class DatabaseService
{
    public AppConfigSingleton Config => AppConfigSingleton.Instance;

    public void Connect() => Console.WriteLine($"Connecting to {Config.DbConnection}");
}

public class UiService
{
    public AppConfigSingleton Config => AppConfigSingleton.Instance;

    public void Render() => Console.WriteLine($"UI is using theme: {Config.Theme}");
}