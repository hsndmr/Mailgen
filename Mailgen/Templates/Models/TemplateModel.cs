namespace Mailgen.Templates.Models;

public struct TemplateModel<TRow>
{
    public TemplateOptionsModel Options { get; set; }
    public TemplateBodyModel<TRow> Body { get; set; }
}