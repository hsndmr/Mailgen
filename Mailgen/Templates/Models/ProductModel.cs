using System.Collections.Generic;

namespace Mailgen.Templates.Models;

public class ProductModel
{
    public string? Link { get; init; }
    public string? Logo { get; init; }
    public string? LogoHeight { get; init; }
    public string? Name { get; init; }
    public string? CopyrightLeft { get; init; }
    public string? CopyrightRight { get; init; }

    public Dictionary<string, object?> ToDictionary()
    {
        return new Dictionary<string, object?>
        {
            { "link", Link },
            { "logo", Logo },
            { "logoHeight", LogoHeight },
            { "name", Name },
            { "copyrightLeft", CopyrightLeft },
            { "copyrightRight", CopyrightRight }
        };
    }
}