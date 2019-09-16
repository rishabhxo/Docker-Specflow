@SignedIn
Feature: AddNewCertifications
       As a Skill Trader
      I want to be able to Add,update,delete Certifications 
      In order to update my profile details

@AddCertifications
Scenario: Check if seller is able to add a new certification
	Given I am on the Certifications tab
	And I have clicked the Add New button
	And I have input Certificate or Award "Information Technology", Certified From "Adobe" and chosen Year "2018"
	When I click the Add button
	Then The new certification record should be added with the popup message "has been added to your certification"