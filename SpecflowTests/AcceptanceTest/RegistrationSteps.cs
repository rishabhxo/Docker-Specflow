using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class RegistrationSteps
	{
		public RegistrationSteps()
		{
			CommonMethods.test = CommonMethods.extent.StartTest("Registration");
		}

		[Given(@"I have clicked the Join button on the Home page")]
		public void GivenIHaveClickedTheJoinButtonOnTheHomePage()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the Join button on the Home page
			Driver.driver.FindElement(By.XPath("//button[contains(@class,'button')][contains(text(),'Join')]")).Click();
			Thread.Sleep(500);
		}

		[Given(@"I have input Frist name ""(.*)"", Last name ""(.*)"", Email address ""(.*)""")]
		public void GivenIHaveInputFristNameLastNameEmailAddress(string firstname, string lastname, string emailaddress)
		{
			// Wait 0.5 second
			Thread.Sleep(1000);

			// Input the First name field "ABC"
			Driver.driver.FindElement(By.Name("firstName")).SendKeys(firstname);

			// Input the Last name "ABC"
			Driver.driver.FindElement(By.Name("lastName")).SendKeys(lastname);

			// Input the Email address "ABC@ABC.ABC"
			Driver.driver.FindElement(By.Name("email")).SendKeys(emailaddress);
		}

		[Given(@"I have also input Password ""(.*)"", Confirm Password ""(.*)""")]
		public void GivenIHaveAlsoInputPasswordConfirmPassword(string password, string confirmpassword)
		{
			// Input the Password "123456"
			Driver.driver.FindElement(By.Name("password")).SendKeys(password);

			// Input the Confirm Password "123456"
			Driver.driver.FindElement(By.Name("confirmPassword")).SendKeys(confirmpassword);
		}
		
		[Given(@"I have ticked the I agree to the terms and conditions checkbox")]
        public void GivenIHaveTickedTheIAgreeToTheTermsAndConditionsCheckbox()
        {
			// Tick the I agree to the terms and conditions checkbox
			Driver.driver.FindElement(By.Name("terms")).Click();
		}
        
        [When(@"I click the Join button")]
        public void WhenIClickTheJoinButton()
        {
			// Click the Join button on the Registration form page
			Driver.driver.FindElement(By.XPath("//div[@id='submit-btn'][contains(text(),'Join')]")).Click();
		}

		[Then(@"The new account should be registered with the popup message ""(.*)""")]
		public void ThenTheNewAccountShouldBeRegisteredWithThePopupMessage(string message)
		{
			// verify if register a new account successfully
			IWebElement actualtext = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
			Assert.That(actualtext.Text, Is.EqualTo(message));
		}
    }
}
