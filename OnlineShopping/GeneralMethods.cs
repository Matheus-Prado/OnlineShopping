using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

namespace OnlineShopping
{
    public class GeneralMethods
    {
        IWebDriver driver = new ChromeDriver(@"C:\ChromeDrive");

        public void startSettings()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }
        
        public void OnlineStoreHomePage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        public void CloseBrowser()
        {
            driver.Close();
        }

        public void ClickByClass(string _class)
        {
            driver.FindElement(By.ClassName(_class)).Click();
        }

        public void ClickById(string id)
        {
            driver.FindElement(By.Id(id)).Click();
            
        }

        public bool existByClass(string _class)
        {
            return driver.PageSource.Contains(_class);
        }

        public void SingInPage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication");
        }

        public void SingInCredentials(string email, string password)
        {
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("passwd")).SendKeys(password);
        }

        public string MsgError()
        {
            return driver.FindElement(By.XPath("//*[@class='alert alert-danger']")).Text;
        }
    }
}
