using System;
using System.Collections.Generic;

namespace Mailgen.Templates.Models;

public class TableColumnModel<TRow>
{
    public required string Header { get; init; }
    public required Func<TRow, object> ValueSelector { get; init; }
    public string? Width { get; init; }
    public string? Align { get; init; }

    public string GetStyle()
    {
        var style = "";

        style += $@"text-align:{Align ?? "left"};";

        return style;
    }

    public Dictionary<string, object?> ToDictionary()
    {
        return new Dictionary<string, object?>
        {
            { "header", Header },
            { "width", Width != null ? $@" width='{Width}'" : "" },
            { "style", GetStyle() }
        };
    }
}