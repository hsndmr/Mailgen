using Mailgen;
using Mailgen.Templates;
using Mailgen.Templates.Models;

namespace MailgenTest;

public class MailgenTest
{
    private MailGenerator _mailGenerator;

    [SetUp]
    public void Setup()
    {
        var product = new ProductModel
        {
            CopyrightLeft = "© 2024",
            CopyrightRight = "All rights reserved.",
            Link = "https://github.com/hsndmr",
            Name = "Example Product"
        };

        _mailGenerator = new MailGenerator(product, new DefaultTemplate());
    }

    [Test]
    public async Task GenerateMail_ReturnsExpectedHtmlString()
    {
        // Arrange
        var body = new BodyModel<object>();


        // Act
        var result = await _mailGenerator.GenerateMail(body);

        // Assert
        Assert.That(result, Contains.Substring("dir=\"ltr\""));
    }

    //@TODO: Add all tests
}