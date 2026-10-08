using Lesson24.Elements;
using OpenQA.Selenium;

namespace Lesson24;

public class LoginPage : BasePage
{
    
    private readonly BaseElement _inpUsername;
    private readonly BaseElement _inpPassword;
    private readonly BaseElement _btnLogin;
    private readonly BaseElement _msgError;

    public LoginPage(IWebDriver driver) : base(driver)
    {
        _inpUsername = new BaseElement(
            driver,
            By.Id("user-name"));

        _inpPassword = new BaseElement(
            driver,
            By.CssSelector("input[data-test='password']"));

        _btnLogin = new BaseElement(
            driver,
            By.Id("login-button"));

        _msgError = new BaseElement(
            driver,
            By.CssSelector("h3[data-test='error']"));
    }

    public LoginPage SetUserName(string username)
    {
        _inpUsername.SendKeys(username);
        return this;
    }

    public LoginPage SetPassword(string password)
    {
        _inpPassword.SendKeys(password);
        return this;
    }

    public ProductsPage ClickLoginButton()
    {
        _btnLogin.Click();
        return new ProductsPage(_driver);
    }

    public ProductsPage Login(
        string username = "standard_user",
        string password = "secret_sauce") =>
        SetUserName(username).SetPassword(password).ClickLoginButton();

    public string GetErrorMessage() =>
        _msgError.GetText();

    public bool IsLoginPageDisplayed() =>
        _btnLogin.IsDisplayed()
        && _inpUsername.IsDisplayed()
        && _inpPassword.IsDisplayed();
    
}