using System.Collections.Generic;

namespace Mailgen.Templates.Models;

public class ButtonModel
{
    public required string Color { get; init; }
    public required string Text { get; init; }
    public required string Link { get; init; }

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