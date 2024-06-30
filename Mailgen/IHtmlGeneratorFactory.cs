using Microsoft.AspNetCore.Components.Web;

namespace Mailgen;

public interface IHtmlGeneratorFactory
{
    public HtmlRenderer Create();
}