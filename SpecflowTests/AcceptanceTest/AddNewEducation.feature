@SignedIn
Feature: AddNewEducation
	 As a Skill Trader
      I want to be able to Add,update,delete education
      In order to update my profile details


@AddEducation
Scenario: Check if seller is able to add a new education record
	Given I am on the Education tab
	And I have clicked the Add New button
	And I have input College/University Name "Oxford" and chosen Country of College/University "United Kingdom"
	And I have chosen Title "PHD", input Degree "Master" and chosen Year of graduation "2018"
	When I click the Add button
	Then The new education record should be added with the popup message "Education has been added"