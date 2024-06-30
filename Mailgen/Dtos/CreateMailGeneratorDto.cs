using Mailgen.Templates.Models;

namespace Mailgen.Dtos;

public class CreateMailGeneratorDto
{
    public TemplateOptionsModel Options { get; set; }
}