@SignedIn
Feature: SaveShareSkill
	Seller can save a valid service

Scenario: Check if seller is able to save a valid service
	Given I have clicked the Share Skill button
	And I have input Title "Manual Testing", Description "Functional" and Category "Fun & Lifestyle"
	And I have also input Subcategory "Gaming", Tags "Manual" and Skill-Exchange tags "Automation"
	When I click the Save button
	Then The service with Title 'Manual Testing' should be saved and navigate to the Manage Listings page
