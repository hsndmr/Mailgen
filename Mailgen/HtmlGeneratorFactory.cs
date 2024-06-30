using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mailgen;

public class HtmlGeneratorFactory : IHtmlGeneratorFactory
{
    public HtmlRenderer Create()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddLogging();
        IServiceProvider serviceProvider = services.BuildServiceProvider();
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        var htmlRenderer = new HtmlRenderer(serviceProvider, loggerFactory);

        return htmlRenderer;
    }
}