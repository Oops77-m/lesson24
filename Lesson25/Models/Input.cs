using Lesson25.Elements;
using OpenQA.Selenium;

namespace Lesson25.Models;

public class Input : BaseElement
{
    
    public Input(IWebDriver driver, By locator)
        : base(driver, locator)
    {
    }
}