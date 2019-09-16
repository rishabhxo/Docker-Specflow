using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowTests
{
	[Binding]
	public class ProfileEditDetailsSteps
	{
		public ProfileEditDetailsSteps()
		{
			CommonMethods.test = CommonMethods.extent.StartTest("Edit the Profile details");
		}

		[Given(@"I have clicked the dropdown icon of Name")]
		public void GivenIHaveClickedTheDropdownIconOfName()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the dropdown icon of Name
			Driver.driver.FindElement(By.XPath("//div[@class='title']//i[@class='dropdown icon']")).Click();
		}

		[Given(@"I have input  First Name ""(.*)"" and Last Name ""(.*)""")]
		public void GivenIHaveInputFirstNameAndLastName(string firstname, string lastname)
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Input First Name
			Driver.driver.FindElement(By.Name("firstName")).Clear();
			Driver.driver.FindElement(By.Name("firstName")).SendKeys(firstname);
            Thread.Sleep(500);

            // Input Last Name 
            Driver.driver.FindElement(By.Name("lastName")).Clear();
			Driver.driver.FindElement(By.Name("lastName")).SendKeys(lastname);
			Thread.Sleep(500);
		}

		
		[When(@"I click the Save button of Name")]
		public void WhenIClickTheSaveButtonOfName()
		{
			// Click the Save button
			Driver.driver.FindElement(By.XPath("//button[contains(@class,'button')][contains(text(),'Save')]")).Click();
			Thread.Sleep(2000);
		}

          

    [Then(@"The new name should be updated with the popup message ""(.*)""")]
    public void ThenTheNewNameShouldBeUpdatedWithThePopupMessage(string message)
    {
            // Verify if Name updated successfully
            
            IWebElement actualtext = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
            Assert.That(actualtext.Text, Is.EqualTo(message));

            IWebElement FullName = Driver.driver.FindElement(By.XPath("//div[@class='title'][contains(.,'Prabha QA')]"));
			Assert.That(FullName.Text, Is.EqualTo("Prabha QA"));
            Thread.Sleep(1000);
        }

		[Given(@"I have clicked the write icon of Availability")]
		public void GivenIHaveClickedTheWriteIconOfAvailability()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the write icon of Availability
			Driver.driver.FindElement(By.XPath("//span[contains(text(),'Time')]//i[contains(@class,'write icon')]")).Click();
		}
		[When(@"I have selected Availability type ""(.*)""")]
		public void WhenIHaveSelectedAvailabilityType(string availability)
		{
			// Select Availability type "Full Time"
			Driver.driver.FindElement(By.Name("availabiltyType")).SendKeys(availability);
		}

		[Then(@"The new availability should be updated with the popup message ""(.*)""")]
		public void ThenTheNewAvailabilityShouldBeUpdatedWithThePopupMessage(string message)
		{
			// Verify if edit the Availability successfully
			IWebElement actualtext = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
			Assert.That(actualtext.Text, Is.EqualTo(message));
		}

		[Given(@"I have clicked the write icon of Hours")]
		public void GivenIHaveClickedTheWriteIconOfHours()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the write icon of Hours
			Driver.driver.FindElement(By.XPath("//span[contains(text(),'week')]//i[contains(@class,'write icon')]")).Click();
		}

		[When(@"I have selected Hours type ""(.*)""")]
		public void WhenIHaveSelectedHoursType(string hours)
		{
			// Select Hours type "More than 30hours a week"
			Driver.driver.FindElement(By.Name("availabiltyHour")).SendKeys(hours);
            Thread.Sleep(1000);
		}

		[Then(@"The new hours should be updated with the popup message ""(.*)""")]
		public void ThenTheNewHoursShouldBeUpdatedWithThePopupMessage(string message)
		{
			// Verify if edit the Hours successfully
			IWebElement actualtext = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
			Assert.That(actualtext.Text, Is.EqualTo(message));
		}

		[Given(@"I have clicked the write icon of Earn Target")]
		public void GivenIHaveClickedTheWriteIconOfEarnTarget()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the write icon of Earn Target
			Driver.driver.FindElement(By.XPath("//span[contains(text(),'month')]//i[contains(@class,'write icon')]")).Click();
		}

		[When(@"I have selected Earn Target type ""(.*)""")]
		public void WhenIHaveSelectedEarnTargetType(string earntype)
		{
			// Select Earn Target type "More than $1000 per month"
			Driver.driver.FindElement(By.Name("availabiltyTarget")).SendKeys(earntype);
            Thread.Sleep(1000);
		}

		[Then(@"The new earn target should be updated with the popup message ""(.*)""")]
		public void ThenTheNewEarnTargetShouldBeUpdatedWithThePopupMessage(string message)
		{
			// Verify if edit the Earn Target successfully
			IWebElement actualtext = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
			Assert.That(actualtext.Text, Is.EqualTo(message));
		}

		[Given(@"I have clicked the write icon of Description")]
		public void GivenIHaveClickedTheWriteIconOfDescription()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the write icon of Description
			Driver.driver.FindElement(By.XPath("//i[contains(@class,'outline write icon')]")).Click();
			Thread.Sleep(500);
		}

		[Given(@"I have input Description ""(.*)""")]
		public void GivenIHaveInputDescription(string description)
		{
			// Input Description "Test Analyst experienced with Selenium, C#."
			Driver.driver.FindElement(By.Name("value")).Clear();
			Driver.driver.FindElement(By.Name("value")).SendKeys(description);
		}

		[Scope(Tag = "SaveDescription")]
		[When(@"I click the Save button of Description")]
		public void WhenIClickTheSaveButtonOfDescription()
		{
			// Click the Save button
			Driver.driver.FindElement(By.XPath("//button[@type='button'][contains(text(),'Save')]")).Click();
			Thread.Sleep(1000);
		}

		[Then(@"The new description should be updated with the popup message ""(.*)""")]
		public void ThenTheNewDescriptionShouldBeUpdatedWithThePopupMessage(string message)
		{
			// Verify if edit the Description successfully 
			IWebElement actualtext = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
			Assert.That(actualtext.Text, Is.EqualTo(message));
		}
	}
}

