@SignedIn
Feature: AddNewSkills
	 As a Skill Trader
      I want to be able to Add,update,delete Skill
      In order to update my profile details


@AddSkills
Scenario: Check if seller is able to add a new skill
	Given I an on the Skills tab
	And I have the Add New button
	And I have input Skill name "Java" and chosen Language level "Expert"
	When I click the Add button
	Then The new Language record should be added with the popuup message "has been added to your skills"
