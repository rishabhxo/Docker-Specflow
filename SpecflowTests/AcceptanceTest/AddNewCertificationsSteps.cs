using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowTests
{
	[Binding]
	public class AddNewCertificationsSteps
	{
		public AddNewCertificationsSteps()
		{
			CommonMethods.test = CommonMethods.extent.StartTest("Add a new Certification");
		}

		[Given(@"I am on the Certifications tab")]
        public void GivenIAmOnTheCertificationsTab()
        {
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the Certification cab
			Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(text(),'Certifications')]")).Click();
		}

		[Scope(Tag = "AddCertifications")]
		[Given(@"I have clicked the Add New button")]
		public void GivenIHaveClickedTheAddNewButton()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the Add New button
			Driver.driver.FindElement(By.XPath("//div[contains(@class,'active')]//div[contains(@class,'button')][contains(text(),'Add New')]")).Click();
		}

		[Given(@"I have input Certificate or Award ""(.*)"", Certified From ""(.*)"" and chosen Year ""(.*)""")]
		public void GivenIHaveInputCertificateOrAwardCertifiedFromAndChosenYear(string name, string from, string year)
		{
			// Input Certificate or Award "Information Technology"
			Driver.driver.FindElement(By.Name("certificationName")).SendKeys(name);

			// Input Certified From "Adobe" 
			Driver.driver.FindElement(By.Name("certificationFrom")).SendKeys(from);

			// Choose Year "2018"
			Driver.driver.FindElement(By.Name("certificationYear")).SendKeys(year);
		}
		
		[Scope(Tag = "AddCertifications")]
		[When(@"I click the Add button")]
		public void WhenIClickTheAddButton()
		{
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the Add button
			Driver.driver.FindElement(By.XPath("//input[@type='button'][@value='Add']")).Click();
		}

		[Then(@"The new certification record should be added with the popup message ""(.*)""")]
		public void ThenTheNewCertificationRecordShouldBeAddedWithThePopupMessage(string p0)
		{
			// Verify if add the new Certification successfully
			IWebElement Certification = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
			Assert.That(Certification.Text, Is.EqualTo("Information Technology has been added to your certification"));
		}
    }
}




