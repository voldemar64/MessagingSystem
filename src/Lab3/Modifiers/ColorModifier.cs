using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class ColorModifier(Color color) : ITextModifier
{
    public string Modify(string body)
    {
        return Crayon.Output.Rgb(color.R, color.G, color.B).Text(body);
    }
}