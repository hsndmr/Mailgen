using System.IO;
using System.Threading.Tasks;
using Mailgen.Templates.Models;

namespace Mailgen.Templates;

public abstract class BaseTemplate : ITemplate

{
    private string? _template;

    public object GetModel<TRow>(ProductModel product, BodyModel<TRow> body)
    {
        return body.ToObject(product);
    }

    public async Task<string?> GetTemplate()
    {
        await LoadTemplate();


        return _template;
    }

    protected abstract string GetTemplatePath();

    private async Task LoadTemplate()
    {
        if (_template != null) return;


        _template = await File.ReadAllTextAsync(GetTemplatePath());
    }
}