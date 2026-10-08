using Lesson24.Elements;
using OpenQA.Selenium;

namespace Lesson24;

public class CheckoutCompletePage : BasePage
{
    private readonly BaseElement _label;
    private readonly BaseElement _completeHeader;
    private readonly BaseElement _buttonGeneratePdfOrder;
    private readonly BaseElement _buttonBackHome;

    public CheckoutCompletePage(IWebDriver driver) : base(driver)
    {
        _label = new BaseElement(driver, By.CssSelector("[data-test='pony-express']"));
        _completeHeader = new BaseElement(driver, By.CssSelector("[data-test='complete-header']"));
        _buttonGeneratePdfOrder = new BaseElement(driver,By.Id("generate-pdf-order"));
        _buttonBackHome = new BaseElement(driver, By.Id("back-to-products"));
    }

    public bool IsDisplayedLabel()
    {
        return _label.IsDisplayed();
    }
    public string GetOrderCompleteText()
    {
        return _completeHeader.GetText();
    }
    public void ClickGeneratePdfOrder()
    {
        _buttonGeneratePdfOrder.Click();
    }
    public void ClickBackHome()
    {
        _buttonBackHome.Click();
    }
}