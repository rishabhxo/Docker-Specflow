using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SearchSkillsSteps
	{
		public SearchSkillsSteps()
		{
			CommonMethods.test = CommonMethods.extent.StartTest("Search skills by categories and filters");
		}

		[Given(@"I have input Search skills ""(.*)""")]
		public void GivenIHaveInputSearchSkills(string name)
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Input Search skills "Test"
			Driver.driver.FindElement(By.XPath("//input[@placeholder='Search skills']")).SendKeys(name);
		}

		[Given(@"I have clicked the search icon of Test")]
		public void GivenIHaveClickedTheSearchIconofTest()
		{
			// Click the search icon
			Driver.driver.FindElement(By.XPath("//i[@class='search link icon']")).Click();
			Thread.Sleep(1000);
		}

		[When(@"I have selected Category ""(.*)"" and Subategory ""(.*)""")]
		public void WhenIHaveSelectedCategoryAndSubategory(string category, string subcategory)
		{
			// Select Category "Programming & Tech"
			Driver.driver.FindElement(By.XPath("//a[@class='item category'][contains(text(),'Programming & Tech')]")).Click();

			// Select Subategory "QA"
			Driver.driver.FindElement(By.XPath("//a[@class='item subcategory'][contains(text(),'QA')]")).Click();
			Thread.Sleep(1000);
		}

		[Then(@"The selected category result should be showing")]
		public void ThenTheSelectedCategoryResultShouldBeShowing()
		{
			// Verify if the selected category result showing succesfully
			IWebElement CategoryResult = Driver.driver.FindElement(By.XPath("//p[@class='row-padded'][contains(text(),'Testing')]"));
			Assert.That(CategoryResult.Text, Is.EqualTo("Testing"));
		}

		[Given(@"I have input Search ""(.*)"" skill")]
		public void GivenIHaveInputSearchSkill(string name)
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Input Search skills "Test"
			Driver.driver.FindElement(By.XPath("//input[@placeholder='Search skills']")).SendKeys(name);
		}

		[Given(@"I have clicked the search icon of QA")]
		public void GivenIHaveClickedTheSearchIconofQA()
		{
			// Click the search icon
			Driver.driver.FindElement(By.XPath("//i[@class='search link icon']")).Click();
			Thread.Sleep(1000);
		}

		[When(@"I click the Onsite option")]
		public void WhenIClickTheOnsiteOption()
		{
			// Click the Onsite option
		    Driver.driver.FindElement(By.XPath("//button[contains(text(),'Onsite')]")).Click();
			Thread.Sleep(1000);
		}

		[Then(@"The selected filter result should be showing")]
		public void ThenTheSelectedFilterResultShouldBeShowing()
		{
			// Verify if the selected filter result showing succesfully
			IWebElement CategoryResult = Driver.driver.FindElement(By.XPath("//p[@class='row-padded'][contains(text(),'QA')]"));
			Assert.That(CategoryResult.Text, Is.EqualTo("QA"));
		}
	}
}
