using Lesson25.Models;

namespace Lesson25.Helpers;

public class BrowserOptions
{
    public Browser Browser  { get; set; }
    public bool Headless { get; set; }
    public bool Maximize { get; set; }
    public bool Remote { get; set; }
}