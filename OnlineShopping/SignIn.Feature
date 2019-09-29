Feature: SignIn
	In order to buy something
	As a customer
	I want to sign in to the site

@mytag
Scenario: Sign in on the online store
	Given I am on the homepage
		And I click to Sign In
	When I enter my email and password
	|email|password|
	|matheustaurinho@hotmail.com|password123|
		And I click Sign In
	Then My username should appear where the sign in button was

Scenario: Sign in without email and password
	Given I am on the homepage
		And I click to Sign In
	When I click Sign In
	Then should appear the error message 'There is 1 error An email address required.'

Scenario: Sign in with invalid password
	Given I am on the homepage
		And I click to Sign In
	When I enter my email and password
	|email|password|
	|matheustaurinho@hotmail.com|123|
		And I click Sign In
	Then should appear the error message 'There is 1 error Invalid password.'