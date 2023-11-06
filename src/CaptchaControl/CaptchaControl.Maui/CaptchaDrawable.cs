// Inspiration from https://learn.microsoft.com/en-us/answers/questions/1416739/maui-captcha?page=1#answer-1355098
// For more information, use https://learn.microsoft.com/en-us/dotnet/maui/user-interface/graphics/draw#draw-attributed-text

using Microsoft.Maui.Graphics.Text;

namespace CaptchaControl.Maui;

public class CaptchaDrawable : IDrawable
{
    private readonly Random rand = new ();

    public CaptchaDrawable() { }

    public float Width { get; set; }

    public float Height { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        var str = "";

        // **** Phase 1 - Generate content (random letters and numbers) **** //

        for (var i = 0; i < 5; i++)
        {
            // Choose a random number or letter, then convert to their ASCII values
            switch (rand.Next(1, 3))
            {
                case 1:
                    str += $"{(char)rand.Next(48, 58)}";
                    break;
                case 2:
                    str += $"{(char)rand.Next(65, 91)}";
                    break;
            }
        }

        // **** Phase 2 - Render content **** //

        // Colors for random selection
        var colors = new [] { Colors.Black, Colors.Brown, Colors.Blue, Colors.Red, Colors.Green, Colors.Pink, Colors.PowderBlue, Colors.Gold };

        // Fonts for random selection
        var fonts = new [] { "OpenSansRegular", "Agbalumo", "Libre Baskerville", "Dancing Script" };

        // Create random brushes, fonts, and points to display in canvas objects
        for (var i = 0; i < 5; i++)
        {
            // Stabilize font size
            canvas.FontSize = 30;

            // Choose a random font color
            canvas.FontColor = colors[rand.Next(colors.Length)];

            // Choose a random Font
            canvas.Font = new Microsoft.Maui.Graphics.Font(fonts[rand.Next(fonts.Length)], 20, FontStyleType.Italic);

            // Get the character to render
            var text = MarkdownAttributedTextReader.Read($"{str[i]}");

            // Render the character to a specific location on the canvas
            canvas.DrawText(text, i * 30, 20, this.Width, this.Height);
        }


        // **** Phase 3 - Obscure Content **** //

        // Draws random lines over content to try to inhibit machine reading
        for (var i = 0; i <= 5; i++)
        {
            canvas.StrokeColor = colors[rand.Next(8)];
            canvas.StrokeSize = 2;
            canvas.DrawLine(rand.Next(50), rand.Next(50), rand.Next(150), rand.Next(50));
        }
    }
}