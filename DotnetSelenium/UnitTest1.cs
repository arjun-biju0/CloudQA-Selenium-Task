using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotnetSelenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            try { 
                driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
                driver.Manage().Window.Maximize();
                string fname = @"
                return document.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form').querySelector('section[slot=""fname""]').querySelector('input');
            ";
                string lname = @"return document.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form').querySelector('section[slot=""lname""]').querySelector('input');";
                string description = @"return document.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form').querySelector('section[slot=""description""]').querySelector('textarea');";
                IWebElement inputFname = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(fname);
                IWebElement inputLname = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(lname);
                IWebElement inputDescription = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(description);
                inputFname.SendKeys("Arjun");
                inputLname.SendKeys("Biju");
                inputDescription.SendKeys("Hii I completed the work. And I really liked the assignment as it was challenging and fun too");
                Console.WriteLine("Name and Description fields have been entered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                driver.Quit();
            }

        }
    }
}