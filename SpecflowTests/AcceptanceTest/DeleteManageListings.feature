@SignedIn
Feature: DeleteManageListings
      As a Skill Trader
      I want to be able to delete service added
	   Seller can delete all services of the last page

Scenario: Check if seller is able to delete all services of the last page
	Given I have clicked the Manage Listings tab
	And I have selected the last service of the last page
	When I click the Yes button of the popup delete dialog
	Then The last service should be deleted 
