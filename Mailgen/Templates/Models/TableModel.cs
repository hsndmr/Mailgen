namespace Mailgen.Templates.Models;

public struct TableModel<TRow>
{
    public string? Title { get; set; }
    public List<TableColumnModel<TRow>> Columns { get; set; }
    public List<TRow> Rows { get; set; }
}