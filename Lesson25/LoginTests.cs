using Allure.NUnit;
using Lesson25.Helpers;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson25;
[AllureNUnit]
[TestFixture]
public class LoginTests : BaseTest
{

    [Test] public void LoginSuccess()
    {
        //LoginPage loginPage = new LoginPage(driver);
        LoginPage loginPage = PageFactory.Create<LoginPage>(driver);
        ProductsPage  productsPage = loginPage.Login();
        productsPage.WaitUntilLoaded();
        Assert.That(productsPage.IsCartIconDisplayed(), Is.True);
    }
    [Test]
    public void LoginLockedUser()
    {
        LoginPage loginPage = PageFactory.Create<LoginPage>(driver);
        loginPage.Login(username: "locked_out_user");
        loginPage.WaitForErrorMessage();
        Assert.That(loginPage.GetErrorMessage(), 
            Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
    }
}