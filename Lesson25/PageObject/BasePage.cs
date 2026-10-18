using Lesson25.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Lesson25;

public class BasePage
{
    private readonly WaitHelper _waitHelper;
    protected IWebDriver _driver;
    public  BasePage(IWebDriver driver)
    {
       _driver = driver;
       _waitHelper = new WaitHelper(driver);
    }

    public void OpenSauceDemo()
    {
        _driver.Navigate().GoToUrl("https://www.saucedemo.com");
        _driver.Manage().Window.Maximize(); //увеличит окно
    }
    public virtual bool IsLoaded()
    {
        return true;
    }
    public void WaitUntilLoaded()
    {
        _waitHelper.WaitUntil(() => IsLoaded());
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