using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using Lesson25.Models;
using OpenQA.Selenium;

namespace Lesson25.Helpers;

public static class PageFactory
{
    public static T Create<T>(IWebDriver driver) where T : BasePage
    {
        var page = (T)Activator.CreateInstance(typeof(T), driver);
        InitializeElements(page, driver);
        return page;
    }

    private static void InitializeElements(BasePage page, IWebDriver driver)
    {
        var properties = page.GetType().GetProperties(
            BindingFlags.Instance | BindingFlags.Public  | BindingFlags.NonPublic);
        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute<FindByAttribute>();
            if (attribute == null)
                continue;
            var by = CreateBy(attribute.How, attribute.Locator);

            var element = CreateElement(
                property.PropertyType, driver, by);
            property.SetValue(page, element);
        }
        
    }

    private static By CreateBy(How how, string locator)
    {
        return how switch
        {
            How.Id => By.Id(locator),
            How.CssSelector => By.CssSelector(locator),
            How.XPath => By.XPath(locator),
            _ => throw new NotSupportedException(
                $"Locator type {how} is not supported.")
        };
    }

    private static object CreateElement(Type elementType, IWebDriver driver, By locator)
    {
        return Activator.CreateInstance(elementType, driver, locator)!;
    }
}