
using Allure.NUnit;
using Lesson25.Helpers;

namespace Lesson25;
[AllureNUnit]
[TestFixture]
public class LogoutTests : BaseTest
{
    [Test]
    public void LoginSuccess()
    {
        LoginPage loginPage = PageFactory.Create<LoginPage>(driver);
        ProductsPage productsPage = loginPage.Login();
        var newLoginPage = productsPage.Heander.Logout();
        Assert.That(newLoginPage.IsLoginPageDisplayed(), Is.True);
    }
}