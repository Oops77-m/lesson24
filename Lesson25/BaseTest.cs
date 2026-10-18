using System.Text.Json;
using System.Text.Json.Serialization;
using Allure.NUnit;
using Lesson25.Helpers;
using Lesson25.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson25;

[TestFixture]
public class BaseTest
{
    protected IWebDriver driver = null!;
      
    [SetUp]
    public void Setup()
    {
        var settings = GetBrowserOptions();
        driver = WebDriverFactory.Create(settings);
        PageFactory.Create<BasePage>(driver).OpenSauceDemo();
    }
    [Test]
    public void CheckSauceDemoUrl()
    {
        Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
    }
    [TearDown]
    public void TearDown()
    {
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }

    private BrowserOptions GetBrowserOptions()
    {
        var json = File.ReadAllText("appsettings.json");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        options.Converters.Add(new JsonStringEnumConverter());
        return JsonSerializer.Deserialize<BrowserOptions>(json, options);
    }
}