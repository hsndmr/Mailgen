using System.Threading.Tasks;
using Fluid;
using Mailgen.Templates;
using Mailgen.Templates.Models;

namespace Mailgen;

public class MailGenerator
{
    private readonly FluidParser _parser = new();

    private readonly ProductModel _product;
    private readonly ITemplate _template;

    public MailGenerator(ProductModel product, ITemplate template)
    {
        _product = product;
        _template = template;
    }

    public async ValueTask<string> GenerateMail<TRow>(BodyModel<TRow> body)
    {
        var parsedTemplate = _parser.Parse(await _template.GetTemplate());

        var model = _template.GetModel(_product, body);

        return await parsedTemplate.RenderAsync(new TemplateContext(model));
    }
}