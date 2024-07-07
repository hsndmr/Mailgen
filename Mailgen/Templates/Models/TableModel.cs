using System.Collections.Generic;
using System.Linq;

namespace Mailgen.Templates.Models;

public readonly struct TableModel<TRow>
{
    public string? Title { get; init; }
    public List<TableColumnModel<TRow>> Columns { get; init; }
    public List<TRow> Rows { get; init; }

    private List<Dictionary<string, object?>> GetRowsAsDictionary()
    {
        var rows = new List<Dictionary<string, object?>>();

        foreach (var row in Rows)
        {
            var rowColumns = new List<Dictionary<string, object?>>();


            foreach (var column in Columns)
            {
                var columnValue = column.ValueSelector(row);

                rowColumns.Add(new Dictionary<string, object?>
                {
                    { "value", columnValue },
                    { "style", column.GetStyle() }
                });
            }

            var rowDictionary = new Dictionary<string, object?>
            {
                { "columns", rowColumns }
            };


            rows.Add(rowDictionary);
        }

        return rows;
    }

    public Dictionary<string, object?> ToDictionary()
    {
        return new Dictionary<string, object?>
        {
            { "title", Title },
            { "columns", Columns.Select(column => column.ToDictionary()) },
            { "rows", GetRowsAsDictionary() }
        };
    }
}