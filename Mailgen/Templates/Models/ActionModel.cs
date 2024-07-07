using System.Collections.Generic;

namespace Mailgen.Templates.Models;

public class ActionModel
{
    public string? Instructions { get; init; }
    public required ButtonModel Button { get; init; }

    public Dictionary<string, object?> ToDictionary()
    {
        return new Dictionary<string, object?>
        {
            { "instructions", Instructions },
            { "button", Button.ToDictionary() }
        };
    }
}