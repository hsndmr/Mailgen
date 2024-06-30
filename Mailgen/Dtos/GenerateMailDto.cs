using Mailgen.Templates.Models;

namespace Mailgen.Dtos;

public class GenerateMailDto<TRow>
{
    public TemplateBodyModel<TRow> Body { get; set; }
}