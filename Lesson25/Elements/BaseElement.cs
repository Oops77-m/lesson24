using OpenQA.Selenium;

namespace Lesson25.Elements;

public class BaseElement
{
    private readonly IWebDriver _driver;
    private readonly By _locator;
    private string _name;

    public BaseElement(IWebDriver driver, By locator)
    {
        _driver = driver;
        _locator = locator;
    }

    private IWebElement Element => _driver.FindElement(_locator);

    public void Click() //нажать
    {
        Element.Click();
    }

    public void SendKeys(string text) //ввести текст
    {
        Element.SendKeys(text);
    }

    public string GetText() //получить текст
    {
        return Element.Text;
    }

    public bool IsDisplayed()
    {
        try
        {
            return Element.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
    }
    public int Count() //посчитать элементы
    {
        return _driver.FindElements(_locator).Count;
    }
    
}