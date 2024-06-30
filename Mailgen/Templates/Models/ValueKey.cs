namespace Mailgen.Templates.Models;

public struct ValueKey(string key, string value)
{
    public string Key { get; set; } = key;
    public string Value { get; set; } = value;
}