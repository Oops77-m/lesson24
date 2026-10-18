using Lesson25.Elements;
using Lesson25.Helpers;
using Lesson25.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lesson25;

public class HeanderSection : BasePage
{
    [FindBy(How.Id, "react-burger-menu-btn")]
    private BaseElement BtnBurgerMenu { get; set; }

    [FindBy(How.Id, "logout_sidebar_link")]
    private BaseElement BtnLogout { get; set; }
    
    public HeanderSection(IWebDriver driver) : base(driver)
    {
    }
    public HeanderSection OpenSideMenu()
    {
        BtnBurgerMenu.Click();
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(e => BtnLogout.IsDisplayed());
        return this;
    }

    public LoginPage ClickLogoutButton()
    {
        BtnLogout.Click();
        return PageFactory.Create<LoginPage>(_driver);
    }

    public LoginPage Logout()
    {
        return OpenSideMenu().ClickLogoutButton();
    }
}
