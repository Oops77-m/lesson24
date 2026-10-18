using Lesson25.Elements;
using Lesson25.Helpers;
using Lesson25.Models;
using OpenQA.Selenium;

namespace Lesson25;

public class LoginPage : BasePage
{
    /*
    private readonly BaseElement _inpUsername;
    private readonly BaseElement _inpPassword;
    private readonly BaseElement _btnLogin;
    */
    private readonly WaitHelper _waitHelper;
    [FindBy(How.Id, "user-name")]
    private Input UserName { get; set; }
    
    [FindBy(How.CssSelector, "input[data-test='password']")]
    private Input Password { get; set; }
    
    [FindBy(How.Id, "login-button")]
    private BaseElement LoginButton { get; set; }
    
    [FindBy(How.CssSelector, "h3[data-test='error']")]
    private BaseElement ErrorMessage { get; set; }
    
    public LoginPage(IWebDriver driver) : base(driver)
    {
         _waitHelper = new WaitHelper(driver);
         _waitHelper.WaitForElement(By.Id("login-button"));
    }

    public override bool IsLoaded()
    {
        return LoginButton.IsDisplayed();
    }
    public LoginPage SetUserName(string username)
    {
        UserName.SendKeys(username);
        return this;
    }

    public LoginPage SetPassword(string password)
    {
        Password.SendKeys(password);
        return this;
    }

    public ProductsPage ClickLoginButton()
    {
        LoginButton.Click();

        return PageFactory.Create<ProductsPage>(_driver);
    }
    public void WaitForErrorMessage()
    {
        _waitHelper.WaitForElement(
            By.CssSelector("h3[data-test='error']"));
    }

    public ProductsPage Login(
        string username = "standard_user",
        string password = "secret_sauce") =>
        SetUserName(username).SetPassword(password).ClickLoginButton();

    public string GetErrorMessage() =>
        ErrorMessage.GetText();

    public bool IsLoginPageDisplayed() =>
        LoginButton.IsDisplayed()
        && UserName.IsDisplayed()
        && Password.IsDisplayed();
    
}
