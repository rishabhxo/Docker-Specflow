@SignedIn
Feature: AddNewLanguages
	 As a Skill Trader
      I want to be able to Add,update,delete Language
      In order to update my profile details


@AddLanguages
Scenario: Check if seller is able to add a new language
	Given I am on the Languages tab
	And I have clicked the Add New button
	And I have input Language name "Kannada1" and chosen Language level "Native/Bilingual"
	When I click the Add button
	Then The new Language 'Kannada1' record added to my listing