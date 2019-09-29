Feature: Cart
	In order to buy something
	As a customer
	I want to add itens to my cart

@mytag
Scenario: Add items to the cart
	Given I am on the homepage
		And I select an item to 'Add to cart'
	When click to 'Proceed to checkout'
	Then the site send me to the shopping-cart summary page
		And the item should be on my cart

Scenario: Change the quantity of one item in the cart
	Given I am on the shopping-cart summary
		And there is a iten on my cart
	When I increase the quantity of the item
	Then the total products price should change
		And the total price should change

Scenario: Remove all item from the cart
	Given I am on the shopping-cart summary
		And there is a iten on my cart
	When I remove all items from my cart
	Then should appear the message 'Your shopping cart is empty.'