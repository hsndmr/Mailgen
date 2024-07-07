using System.Threading.Tasks;
using Fluid;
using Mailgen.Templates;
using Mailgen.Templates.Models;

namespace Mailgen;

public class MailGenerator(ProductModel product, ITemplate template)
{
    private readonly FluidParser _parser = new();

    public async ValueTask<string> GenerateMail<TRow>(BodyModel<TRow> body)
    {
        var parsedTemplate = _parser.Parse(await template.GetTemplate());

        var model = template.GetModel(product, body);


        return await parsedTemplate.RenderAsync(new TemplateContext(model));
    }
}