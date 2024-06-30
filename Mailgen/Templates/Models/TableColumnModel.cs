using System;

namespace Mailgen.Templates.Models;

public struct TableColumnModel<TRow>
{
    public string Header { get; set; }
    public Func<TRow, object> ValueSelector { get; set; }
    public string? Width { get; set; }
    public string? Align { get; set; }
}