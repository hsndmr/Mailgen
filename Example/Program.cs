using Mailgen;
using Mailgen.Templates;
using Mailgen.Templates.Models;

await TemplateGenerator.GenerateReceiptTemplate();
await TemplateGenerator.GenerateResetTemplate();

public class Item
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Price { get; set; }
}

public class TemplateGenerator
{
    public static async Task GenerateReceiptTemplate()
    {
        var product = new ProductModel
        {
            CopyrightLeft = "© 2024",
            CopyrightRight = "All rights reserved.",
            Link = "https://github.com/hsndmr",
            Name = "Example Product"
        };
        var mailGenerator = new MailGenerator(product, new DefaultTemplate());
        var body = new BodyModel<Item>
        {
            Title = "Hi John Appleseed,",
            Intros =
            [
                "Your order has been processed successfully."
            ],
            Tables = new List<TableModel<Item>>
            {
                new()
                {
                    Columns =
                    [
                        new TableColumnModel<Item>
                        {
                            Header = "Item",
                            ValueSelector = item => item.Name,
                            Width = "20%"
                        },
                        new TableColumnModel<Item>
                        {
                            Header = "Description",
                            ValueSelector = item => item.Description
                        },
                        new TableColumnModel<Item>
                        {
                            Header = "Price",
                            ValueSelector = item => item.Price,
                            Width = "15%",
                            Align = "right"
                        }
                    ],
                    Rows =
                    [
                        new Item
                        {
                            Name = "Node.js",
                            Description = "Event-driven I/O server-side JavaScript environment based on V8.",
                            Price = "$10.99"
                        },
                        new Item
                        {
                            Name = "Mailgen",
                            Description = "A .NET library for generating HTML emails.",
                            Price = "$1.99"
                        }
                    ]
                }
            },
            Actions =
            [
                new ActionModel
                {
                    Instructions = "You can check the status of your order and more in your dashboard:",
                    Button = new ButtonModel
                    {
                        Color = "#22BC66",
                        Text = "Go to Dashboard",
                        Link = "https://github.com/hsndmr"
                    }
                }
            ],
            Outro =
            [
                "We thank you for your purchase."
            ],
            Signature = "Yours truly"
        };

        var html = await mailGenerator.GenerateMail(body);
        await File.WriteAllTextAsync(@"GeneratedTemplates/receipt.html", html);
    }

    public static async Task GenerateResetTemplate()
    {
        var product = new ProductModel
        {
            Link = "https://github.com/hsndmr",
            Name = "Example Product"
        };
        var mailGenerator = new MailGenerator(product, new DefaultTemplate());
        var body = new BodyModel<Item>
        {
            Title = "Hi John Appleseed,",
            Intros =
            [
                "You have received this email because a password reset request for your account was received."
            ],
            Actions =
            [
                new ActionModel
                {
                    Instructions = "Click the button below to reset your password:",
                    Button = new ButtonModel
                    {
                        Color = "#DC4D2F",
                        Text = "Reset your password",
                        Link = "https://github.com/hsndmr"
                    }
                }
            ],
            Outro =
            [
                "If you did not request a password reset, no further action is required on your part."
            ]
        };

        var html = await mailGenerator.GenerateMail(body);
        await File.WriteAllTextAsync(@"GeneratedTemplates/reset.html", html);
    }
}