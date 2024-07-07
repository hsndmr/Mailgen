using System.Collections.Generic;

namespace Mailgen.Templates.Models;

public readonly struct ValueKey
{
    public string Key { get; init; }
    public string Value { get; init; }

    public Dictionary<string, string> ToDictionary()
    {
        return new Dictionary<string, string>
        {
            { "key", Key },
            { "value", Value }
        };
    }
}