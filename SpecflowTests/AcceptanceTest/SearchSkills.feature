@SignedIn
Feature: SearchSkills
	Seller can search skills by categories and filter them

Scenario: Check if seller is able to search skills by category
	Given I have input Search skills "Testing" 
	And I have clicked the search icon of Test
	When I have selected Category "Programming & Tech" and Subategory "QA"
	Then The selected category result should be showing

Scenario: Check if seller is able to search skills by filter
	Given I have input Search "QA" skill 
	And I have clicked the search icon of QA
	When I click the Onsite option
	Then The selected filter result should be showing

