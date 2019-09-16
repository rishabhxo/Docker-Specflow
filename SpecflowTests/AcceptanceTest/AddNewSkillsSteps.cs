using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddNewSkillsSteps
    {
		public AddNewSkillsSteps()
		{
			CommonMethods.test = CommonMethods.extent.StartTest("Add a new Skill");
		}

		[Given(@"I an on the Skills tab")]
        public void GivenIAnOnTheSkillsTab()
        {
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the Skills tab
			Driver.driver.FindElement(By.XPath("//a[contains(@class,'item')][contains(text(),'Skills')]")).Click();
		}
        
		[Scope(Tag = "AddSkills")]
        [Given(@"I have the Add New button")]
        public void GivenIHaveTheAddNewButton()
        {
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the Add New button
			Driver.driver.FindElement(By.XPath("//div[contains(@class,'active')]//div[contains(@class,'button')][contains(text(),'Add New')]")).Click();
		}
        
        [Given(@"I have input Skill name ""(.*)"" and chosen Language level ""(.*)""")]
        public void GivenIHaveInputSkillNameAndChosenLanguageLevel(string name, string level)
        {
			// Input Skill name "Java"
			Driver.driver.FindElement(By.Name("name")).SendKeys(name);

			// Choose Skill level "Expert"
			Driver.driver.FindElement(By.Name("level")).SendKeys(level);
		}
        
		[Scope(Tag = "AddSkills")]
        [When(@"I click the Add button")]
        public void WhenIClickTheAddButton()
        {
			// Wait 0.5 second
			Thread.Sleep(500);

			// Click the Add button
			Driver.driver.FindElement(By.XPath("//input[@type='button'][@value='Add']")).Click();
		}
        
        [Then(@"The new Language record should be added with the popuup message ""(.*)""")]
        public void ThenTheNewLanguageRecordShouldBeAddedWithThePopuupMessage(string p0)
        {
			// Verify if add the new Skill successfully 
			IWebElement actualtext = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
			Assert.That(actualtext.Text, Is.EqualTo("Java has been added to your skills"));
		}
    }
}
