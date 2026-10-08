using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson24;

[TestFixture]
public class BaseTest
{
    protected IWebDriver driver;
      
    [SetUp]
    public void Setup()
    {
         driver = new ChromeDriver();
        //driver.Navigate().GoToUrl("https://www.saucedemo.com");
        //driver.Manage().Window.Maximize(); //увеличит окно
        //Thread.Sleep(3000);
        var basePage = new BasePage(driver);
        basePage.OpenSauceDemo();
    }
    [Test]
    public void CheckSauceDemoUrl()
    {
        Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
    }
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

}