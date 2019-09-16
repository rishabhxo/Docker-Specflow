Feature: Registration
	Seller can register a new account

Scenario: Check if seller is able to register a new account
	Given I have clicked the Join button on the Home page
	And I have input Frist name "ABC", Last name "ABC", Email address "XYZ@XYZ.XYZ"
	And I have also input Password "123456", Confirm Password "123456"
	And I have ticked the I agree to the terms and conditions checkbox
	When I click the Join button
	Then The new account should be registered with the popup message "Registration successful, Please verify your email!"
