using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest
{
	[Binding]
	public class AddNewEducationSteps
	{
		public AddNewEducationSteps()
		{
			CommonMethods.test = CommonMethods.extent.StartTest("Add a new Education");
		}

		[Given(@"I am on the Education tab")]
		public void GivenIAmOnTheEducationTab()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click on the Education cab
			Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(text(),'Education')]")).Click();
		}

		[Scope(Tag = "AddEducation")]
		[Given(@"I have clicked the Add New button")]
		public void GivenIHaveClickedTheAddNewButton()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			Driver.driver.FindElement(By.XPath("//div[contains(@class,'active')]//div[contains(@class,'button')][contains(text(),'Add New')]")).Click();
		}

		[Given(@"I have input College/University Name ""(.*)"" and chosen Country of College/University ""(.*)""")]
		public void GivenIHaveInputCollegeUniversityNameAndChosenCountryOfCollegeUniversity(string name, string country)
		{
			// Input College/University Name "Oxford"
			Driver.driver.FindElement(By.Name("instituteName")).SendKeys(name);

			// Choose Country of College/University "United Kingdom"
			Driver.driver.FindElement(By.Name("country")).SendKeys(country);
		}

		[Given(@"I have chosen Title ""(.*)"", input Degree ""(.*)"" and chosen Year of graduation ""(.*)""")]
		public void GivenIHaveChosenTitleInputDegreeAndChosenYearOfGraduation(string title, string degree, string year)
		{
			// Choose Title "PHD"
			Driver.driver.FindElement(By.Name("title")).SendKeys(title);

			// Input Degree "Master"
			Driver.driver.FindElement(By.Name("degree")).SendKeys(degree);

			// Choose Year of graduation "2018"
			Driver.driver.FindElement(By.Name("yearOfGraduation")).SendKeys(year);

		}

		[Scope(Tag = "AddEducation")]
		[When(@"I click the Add button")]
		public void WhenIClickTheAddButton()
		{
			Driver.driver.FindElement(By.XPath("//input[@type='button'][@value='Add']")).Click();
		}

		[Then(@"The new education record should be added with the popup message ""(.*)""")]
		public void ThenTheNewEducationRecordShouldBeAddedWithThePopupMessage(string p0)
		{
			// Verify if add the new Education successfully 
			IWebElement actualtext = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
			Assert.That(actualtext.Text, Is.EqualTo("Education has been added"));
		}
	}
}