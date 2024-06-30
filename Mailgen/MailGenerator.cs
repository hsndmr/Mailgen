using Mailgen.Dtos;
using Mailgen.Templates;
using Mailgen.Templates.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Mailgen;

public class MailGenerator(IHtmlGeneratorFactory htmlGeneratorFactory, CreateMailGeneratorDto createMailGeneratorDto)
{
    private readonly HtmlRenderer _htmlRenderer = htmlGeneratorFactory.Create();

    public async Task<string> GenerateMail<TRow>(GenerateMailDto<TRow> generateMailDto)
    {
        var templateModel = new TemplateModel<TRow>
        {
            Options = createMailGeneratorDto.Options,
            Body = generateMailDto.Body
        };

        return await _htmlRenderer.Dispatcher.InvokeAsync(async () =>
        {
            var dictionary = new Dictionary<string, object?>
            {
                ["TemplateModel"] = templateModel
            };

            var parameters = ParameterView.FromDictionary(dictionary);
            var output = await _htmlRenderer.RenderComponentAsync(GetTemplate<TRow>(), parameters);

            return output.ToHtmlString();
        });
    }


    private Type GetTemplate<TRow>()
    {
        return typeof(DefaultTemplate<TRow>);
    }

    public async ValueTask DisposeAsync()
    {
        await _htmlRenderer.DisposeAsync();
    }
}