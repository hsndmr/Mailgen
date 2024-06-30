namespace Mailgen.Templates.Models;

public struct TemplateBodyModel<TRow>
{
    public string TextDirection { get; set; }
    public string? Title { get; set; }

    public List<string>? Intros { get; set; }

    public List<ValueKey>? Dictionary { get; set; }

    public List<TableModel<TRow>>? Tables { get; set; }

    public List<ActionModel>? Actions { get; set; }

    public List<string>? Outro { get; set; }

    public string? Signature { get; set; }
}