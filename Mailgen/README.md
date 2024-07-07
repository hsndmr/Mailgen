A .NET package that generates clean, responsive HTML e-mails for sending transactional mail. This package is inspired
by <a href="https://github.com/eladnava/mailgen">https://github.com/eladnava/mailgen</a>

## Demo

![Reset](https://raw.github.com/hsndmr/mailgen/main/screenshots/default/reset.png)
> These e-mails were generated using the built-in `default` theme.

## Usage

First, install the package using NuGet:

```bash
dotnet add package Mailgen
```

Then, use the following code to generate an e-mail:

Create an item class that will be used in the table.

```csharp
public class Item
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Price { get; set; }
}
```

```csharp
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
Console.WriteLine(html);
```

This code would output the following HTML template:

![Receipt](https://raw.github.com/hsndmr/mailgen/main/screenshots/default/receipt.png)

## Example

* [Example](Example/Program.cs)

## RTL Support

To change the default text direction (left-to-right), simply override it as follows:

```csharp
var body = new BodyModel<Item>
{
    TextDirection = "rtl"
};
```