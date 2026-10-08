using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson24;

public class BasePage
{
    protected IWebDriver _driver;
    public  BasePage(IWebDriver driver)
    {
       _driver = driver;
    }

    public void OpenSauceDemo()
    {
        _driver.Navigate().GoToUrl("https://www.saucedemo.com");
        _driver.Manage().Window.Maximize(); //увеличит окно
    }
    
    public string GetUrl()
    {
        return _driver.Url;
    }

    public string GetPageTitle()
    {
        return _driver.Title;
    }
    
}