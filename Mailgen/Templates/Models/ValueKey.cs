using System.Collections.Generic;

namespace Mailgen.Templates.Models;

public class ValueKey(string key, string value)
{
    public required string Key { get; init; } = key;
    public required string Value { get; init; } = value;

    public Dictionary<string, string> ToDictionary()
    {
        return new Dictionary<string, string>
        {
            { "key", Key },
            { "value", Value }
        };
    }
}