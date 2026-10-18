using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lesson25.Helpers;

public class WaitHelper
{
    private readonly IWebDriver _driver;

    public WaitHelper(IWebDriver driver)
    {
        _driver = driver;
    }

    public void WaitForElement(By locator)
    {
        var wait = new WebDriverWait(
            _driver,
            TimeSpan.FromSeconds(10));

        wait.Until(driver =>
            driver.FindElement(locator).Displayed);
    }
    public void WaitUntil(Func<bool> condition)
    {
        var wait = new WebDriverWait(
            _driver,
            TimeSpan.FromSeconds(10));

        wait.Until(_ => condition());
    }
}