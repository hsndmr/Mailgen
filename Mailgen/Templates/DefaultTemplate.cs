namespace Mailgen.Templates;

public class DefaultTemplate : BaseTemplate
{
    protected override string GetTemplatePath()
    {
        return "Templates.default.liquid";
    }
}