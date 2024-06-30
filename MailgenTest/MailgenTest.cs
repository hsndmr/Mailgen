using Mailgen;
using Mailgen.Dtos;
using Mailgen.Templates.Models;

namespace MailgenTest;

public class MailgenTest
{
    private MailGenerator _mailGenerator;

    [SetUp]
    public void Setup()
    {
        var createMailGeneratorDto = new CreateMailGeneratorDto
        {
            Options = new TemplateOptionsModel
            {
                Product = new ProductModel
                {
                    CopyrightLeft = "© 2024",
                    CopyrightRight = "All rights reserved.",
                    Link = "https://github.com/hsndmr",
                    Name = "Example Product"
                }
            }
        };
        _mailGenerator = new MailGenerator(new HtmlGeneratorFactory(), createMailGeneratorDto);
    }

    [Test]
    public async Task GenerateMail_ReturnsExpectedHtmlString()
    {
        // Arrange
        var generateMailDto = new GenerateMailDto<object>
        {
            Body = new TemplateBodyModel<object>()
        };


        // Act
        var result = await _mailGenerator.GenerateMail(generateMailDto);

        // Assert
        Assert.That(result, Contains.Substring("https://github.com/hsndmr"));
    }

    //@TODO: Add all tests

    public async Task TearDown()
    {
        await _mailGenerator.DisposeAsync();
    }
}