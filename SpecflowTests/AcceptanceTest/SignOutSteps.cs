using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowTests
{
    [Binding]
    public class SignOutSteps
	{
		public SignOutSteps()
		{
			CommonMethods.test = CommonMethods.extent.StartTest("Sign Out");
		}

		[Given(@"I have clicked the Sign out button")]
        public void GivenIHaveClickedTheSignOutButton()
        {
			// Click the Sign out button
			Driver.driver.FindElement(By.XPath("//button[contains(@class,'button')][contains(text(),'Sign Out')]")).Click();
		}

		[Then(@"It should sign out to the Home page")]
		public void ThenItShouldSignOutToTheHomePage()
		{
			// Verify if sign out to the Home page successfully
			IWebElement HomePage = Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(text(),'Sign In')]"));
			Assert.That(HomePage.Text, Is.EqualTo("Sign In"));
		}
    }
}
