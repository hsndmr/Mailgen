using System;
using System.IO;
using System.Reflection;
using System.Text;
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

        var assembly = Assembly.GetExecutingAssembly();

        var templatePath = GetTemplatePath();

        var resourceName = $"{assembly.GetName().Name}.{templatePath}";

        await using var stream = assembly.GetManifestResourceStream(resourceName);

        if (stream == null) throw new ArgumentException($"Resource '{resourceName}' not found.");

        using var reader = new StreamReader(stream, Encoding.UTF8);

        _template = await reader.ReadToEndAsync();
    }
}