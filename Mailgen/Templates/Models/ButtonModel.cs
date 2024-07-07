using System.Collections.Generic;

namespace Mailgen.Templates.Models;

public readonly struct ButtonModel
{
    public string Color { get; init; }
    public string Text { get; init; }
    public string Link { get; init; }

    public Dictionary<string, string> ToDictionary()
    {
        return new Dictionary<string, string>
        {
            { "color", Color },
            { "text", Text },
            { "link", Link }
        };
    }
}