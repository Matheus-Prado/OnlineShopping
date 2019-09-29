Feature: QuickView
	In order to know more about the product
	As a customer
	I want to open the quick view

@mytag
Scenario: View the product description
	Given I am on the homepage
		And I select an item to 'Quick view'
	When the site open the quick view page
	Then It should display a description

Scenario: Change image in quick view
	Given I am on the homepage
		And I select an item to 'Quick view'
	When the site open the quick view page
		And I pass the mouse over one of the small images
	Then the image displayed should change

Scenario: Share product on twitter
	Given I am on the homepage
		And I select an item to 'Quick view'
	When the site open the quick view page
		And I click to share the product on twitter
	Then a pop-up of twitter with a text to tweet should appear
