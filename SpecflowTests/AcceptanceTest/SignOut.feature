@SignedIn
Feature: SignOut
	   Seller can sign out

Scenario: Check if seller is able to sign out
	Given I have clicked the Sign out button
	Then It should sign out to the Home page
