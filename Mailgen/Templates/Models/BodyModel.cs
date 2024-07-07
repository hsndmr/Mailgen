using System.Collections.Generic;
using System.Linq;

namespace Mailgen.Templates.Models;

public class BodyModel<TRow>
{
    public string TextDirection { get; set; } = "ltr";
    public string? Title { get; init; }

    public List<string>? Intros { get; init; }

    public List<ValueKey>? Dictionaries { get; init; }

    public List<TableModel<TRow>>? Tables { get; init; }

    public List<ActionModel>? Actions { get; init; }

    public List<string>? Outro { get; init; }

    public string? Signature { get; init; }

    public object ToObject(ProductModel product)
    {
        return new
        {
            product = product.ToDictionary(),
            textDirection = TextDirection,
            title = Title,
            intros = Intros,
            dictionaries = Dictionaries?.Select(i => i.ToDictionary()),
            tables = Tables?.Select(i => i.ToDictionary()),
            actions = Actions?.Select(i => i.ToDictionary()),
            outro = Outro,
            signature = Signature
        };
    }
}