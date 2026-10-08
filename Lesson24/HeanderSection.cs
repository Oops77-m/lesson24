using Lesson24.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lesson24;

public class HeanderSection : BasePage
{
    private readonly BaseElement _btnBurgerMenu;
    private readonly BaseElement _btnLogout;
    
    public HeanderSection(IWebDriver driver) : base(driver)
    {
        _btnBurgerMenu = new BaseElement(
            driver,
            By.Id("react-burger-menu-btn"));

        _btnLogout = new BaseElement(
            driver,
            By.Id("logout_sidebar_link"));
    }

    public HeanderSection OpenSideMenu()
    {
        _btnBurgerMenu.Click();

        WebDriverWait wait = new WebDriverWait(
            _driver,
            TimeSpan.FromSeconds(10));

        wait.Until(e => _btnLogout.IsDisplayed());

        return this;
    }

    public LoginPage ClickLogoutButton()
    {
        _btnLogout.Click();
        return new LoginPage(_driver);
    }

    public LoginPage Logout()
    {
        return OpenSideMenu().ClickLogoutButton();
    }
}
