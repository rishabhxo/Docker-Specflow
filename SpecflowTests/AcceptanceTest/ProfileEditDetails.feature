@SignedIn
Feature: ProfileEditDetails
	    Seller can edit the profile details

@SaveName
Scenario: Check if seller is able to edit the profile name
	Given I have clicked the dropdown icon of Name
	And I have input  First Name "Prabha" and Last Name "QA"
	When I click the Save button of Name
	Then The new name should be updated with the popup message "Name updated"

Scenario: Check if seller is able to edit the profile availability
	Given I have clicked the write icon of Availability
	When I have selected Availability type "Full Time"
	Then The new availability should be updated with the popup message "Availability updated"

Scenario: Check if seller is able to edit the profile hours
	Given I have clicked the write icon of Hours
	When I have selected Hours type "More than 30hours a week"
	Then The new hours should be updated with the popup message "Hours updated"

Scenario: Check if seller is able to edit the profile earn target
	Given I have clicked the write icon of Earn Target
	When I have selected Earn Target type "More than $1000 per month"
	Then The new earn target should be updated with the popup message "Earn Target updated"

@SaveDescription
Scenario: Check if seller is able to edit the profile description
	Given I have clicked the write icon of Description
	And I have input Description "Test Analyst experienced with Selenium, C#."
	When I click the Save button of Description 
	Then The new description should be updated with the popup message "Description has been saved successfully"
