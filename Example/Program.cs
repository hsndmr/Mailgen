using Example;
using Mailgen;
using Mailgen.Dtos;
using Mailgen.Templates.Models;

var projectPath = Environment.CurrentDirectory;


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


// receipt.html
var mailGenerator = new MailGenerator(new HtmlGeneratorFactory(), createMailGeneratorDto);
var generateMailDto = new GenerateMailDto<Item>
{
    Body = new TemplateBodyModel<Item>
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
    }
};
var receipt = await mailGenerator.GenerateMail(generateMailDto);
var mailPath = Path.Combine(projectPath, "receipt.html");
File.WriteAllText(mailPath, receipt);


// reset.html

var generateMailForResetDto = new GenerateMailDto<Item>
{
    Body = new TemplateBodyModel<Item>
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
    }
};
var reset = await mailGenerator.GenerateMail(generateMailForResetDto);
var resetMailPath = Path.Combine(projectPath, "reset.html");
File.WriteAllText(resetMailPath, reset);