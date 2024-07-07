using System.Threading.Tasks;
using Mailgen.Templates.Models;

namespace Mailgen.Templates;

public interface ITemplate
{
    public Task<string?> GetTemplate();

    public object GetModel<TRow>(ProductModel product, BodyModel<TRow> body);
}