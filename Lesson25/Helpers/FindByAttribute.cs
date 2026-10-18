using Lesson25.Models;

namespace Lesson25.Helpers;
[AttributeUsage(AttributeTargets.Property)]
public class FindByAttribute : Attribute
{
    public How How { get; } //By.Id
    public string Locator { get; }
    

    public FindByAttribute(How how, string locator)
    {
        How = how;
        Locator = locator;
    }
}